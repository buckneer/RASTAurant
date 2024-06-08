using RASTAurant.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RASTAurant
{
    public partial class RestaurantView : Form
    {

        private Image tableImage;
        private List<TablePosition> tablePositions;
        private int tableWidth = 100;
        private int tableHeight = 100;

        public RestaurantView()
        {
            InitializeComponent();
            LoadTableImage();
        }

        private void LoadTableImage()
        {
            try
            {
                tableImage = Image.FromFile("table.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        public void LoadLayout(Layout layout)
        {
            tablePositions = layout.TablePositions;
            this.Text = layout.Name;
            //this.Invalidate();  // Force the form to repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (tableImage == null)
            {
                e.Graphics.DrawString("Error loading table image.", this.Font, Brushes.Red, new PointF(10, 10));
                return;
            }

            if (tablePositions != null)
            {
                foreach (var position in tablePositions)
                {
                    Rectangle tableRect = new Rectangle(position.X, position.Y, tableWidth, tableHeight);
                    Button tableButton = new Button();
                    tableButton.Tag = position.Id; // Tag to identify the table number
                    tableButton.Location = new Point(position.X, position.Y);
                    tableButton.Size = new Size(tableWidth, tableHeight);
                    tableButton.BackgroundImage = tableImage;
                    tableButton.BackgroundImageLayout = ImageLayout.Stretch;
                    tableButton.Click += Table_Click;
                    Controls.Add(tableButton);

                }
            }
        }

        private void Table_Click(object sender, EventArgs e)
        {
           
            Control clickedControl = (Control)sender;
            int tableNumber = int.Parse(clickedControl.Tag.ToString());

           
            OrderForm orderForm = new OrderForm(tableNumber);
            orderForm.ShowDialog();

            
        }
    }
}
