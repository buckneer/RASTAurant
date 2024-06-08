using MySql.Data.MySqlClient;
using RASTAurant.Database.Models;
using RASTAurant.Database;

namespace RASTAurant
{



    public partial class LayoutCreate : Form
    {

        public event EventHandler LayoutSaved;

        Image table;
        List<Table> tables = new List<Table>();
        Table currentDraggingTable = null;
        int height = 100;
        int width = 100;

        int gridSize = 20;

        public LayoutCreate()
        {
            InitializeComponent();

            table = Image.FromFile("table.png");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            this.Invalidate();
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);
            foreach (var table in tables)
            {
                if (table.Rect.Contains(mousePosition))
                {
                    table.Dragging = true;
                    currentDraggingTable = table;
                    label1.Text = "Dragging image";
                    break;
                }
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (currentDraggingTable != null && currentDraggingTable.Dragging)
            {
                currentDraggingTable.Position = new Point(e.X - (width / 2), e.Y - (height / 2));
                // Snap to grid
                currentDraggingTable.Position = SnapToGrid(currentDraggingTable.Position);
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (currentDraggingTable != null && currentDraggingTable.Dragging)
            {
                currentDraggingTable.Dragging = false;
                // Snap to grid
                currentDraggingTable.Position = SnapToGrid(currentDraggingTable.Position);
                label1.Text = "Image Dropped @ " + currentDraggingTable.Position.ToString();
                currentDraggingTable = null;
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            foreach (var table in tables)
            {
                Pen outline;
                if (table.Dragging)
                {
                    outline = new Pen(Color.Yellow, 6);
                }
                else
                {
                    outline = new Pen(Color.Transparent, 6);
                }

                e.Graphics.DrawRectangle(outline, table.Rect);
                e.Graphics.DrawImage(this.table, table.Position.X, table.Position.Y, width, height);
            }
        }

        private Point SnapToGrid(Point point)
        {
            int x = (point.X + gridSize / 2) / gridSize * gridSize;
            int y = (point.Y + gridSize / 2) / gridSize * gridSize;
            return new Point(x, y);
        }

        private void newTable_Click(object sender, EventArgs e)
        {
            if (tables.Count < 10)
            {
                tables.Add(new Table(new Point(0, 0), width, height));
                label1.Text = "New table added. Total tables: " + tables.Count;
            }
            else
            {
                label1.Text = "Cannot add more than 10 tables.";
            }
        }

        private void saveLayout_Click(object sender, EventArgs e)
        {
            string layoutName = layoutNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(layoutName))
            {
                MessageBox.Show("Please enter a name for the layout.");
                return;
            }

            Layout layout = new Layout { Name = layoutName };
            foreach (var table in tables)
            {
                layout.TablePositions.Add(new TablePosition(table.Position.X, table.Position.Y));
            }

            SaveLayoutToDatabase(layout);
            MessageBox.Show("Layout saved successfully.");
            OnLayoutSaved(EventArgs.Empty);
            this.Close();
        }

        protected virtual void OnLayoutSaved(EventArgs e)
        {
            LayoutSaved?.Invoke(this, e);
        }

        private void SaveLayoutToDatabase(Layout layout)
        {
            try
            {
                DatabaseConnection.Instance.OpenConnection();

                // Insert layout name into Layouts table
                string insertLayoutQuery = "INSERT INTO Layouts (Name) VALUES (@Name)";
                MySqlCommand cmd = new MySqlCommand(insertLayoutQuery, DatabaseConnection.Instance.Connection);
                cmd.Parameters.AddWithValue("@Name", layout.Name);
                cmd.ExecuteNonQuery();

                // Get the id of the inserted layout
                long layoutId = cmd.LastInsertedId;

                // Insert table positions into TablePositions table
                foreach (var tablePosition in layout.TablePositions)
                {
                    string insertPositionQuery = "INSERT INTO TablePositions (LayoutId, X, Y) VALUES (@LayoutId, @X, @Y)";
                    cmd = new MySqlCommand(insertPositionQuery, DatabaseConnection.Instance.Connection);
                    cmd.Parameters.AddWithValue("@LayoutId", layoutId);
                    cmd.Parameters.AddWithValue("@X", tablePosition.X);
                    cmd.Parameters.AddWithValue("@Y", tablePosition.Y);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                DatabaseConnection.Instance.CloseConnection();
            }
        }
    }

    class Table
    {
        public Point Position { get; set; }
        public Rectangle Rect
        {
            get { return new Rectangle(Position.X, Position.Y, Width, Height); }
        }
        public bool Dragging { get; set; } = false;
        public int Width { get; }
        public int Height { get; }

        public Table(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }
}
