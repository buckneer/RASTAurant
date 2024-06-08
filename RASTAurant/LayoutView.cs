using RASTAurant.Database.Models;
using RASTAurant.Database;
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
    public partial class LayoutView : Form
    {
        public LayoutView()
        {
            InitializeComponent();
            LoadLayouts();
        }



        private void LoadLayouts()
        {
            // Clear existing items before loading layouts
            listBoxLayouts.Items.Clear();

            List<Layout> layouts = DatabaseConnection.Instance.GetAllLayouts();

            foreach (var layout in layouts)
            {
                listBoxLayouts.Items.Add(layout);
            }

            listBoxLayouts.DisplayMember = "Name";
        }

        private void listBoxLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLayouts.SelectedItem is Layout selectedLayout)
            {
                textBoxLayoutDetails.Text = $"Layout Name: {selectedLayout.Name}\r\n";
                textBoxLayoutDetails.Text += $"Number of Tables: {selectedLayout.TablePositions.Count}\r\n";
            }
        }

        private void listBoxLayouts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxLayouts.SelectedItem is Layout selectedLayout)
            {
                OpenLayoutInNewForm(selectedLayout);
            }
        }

        private void OpenLayoutInNewForm(Layout layout)
        {
            RestaurantView layoutDisplayForm = new RestaurantView();
            layoutDisplayForm.LoadLayout(layout);
            layoutDisplayForm.Show();
            //this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void newLayoutButton_Click(object sender, EventArgs e)
        {
            
            LayoutCreate layoutCreateForm = new LayoutCreate();

            layoutCreateForm.LayoutSaved += LayoutCreateForm_LayoutSaved;

            layoutCreateForm.ShowDialog();
        }

        private void LayoutCreateForm_LayoutSaved(object sender, EventArgs e)
        {
            LoadLayouts();
        }
    }
}
