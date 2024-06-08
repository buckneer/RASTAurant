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
using RASTAurant.Database.Models;
using MySql.Data.MySqlClient;

namespace RASTAurant
{
    public partial class OrderForm : Form
    {

        private int tableId;
        private List<Order> orders;
        private DatabaseConnection databaseConnection;


        public OrderForm(int tableNumber)
        {
            InitializeComponent();
            this.tableId = tableNumber;
            databaseConnection = DatabaseConnection.Instance;
            LoadOrders();
        }

        private void LoadOrders()
        {
            orders = databaseConnection.GetOrdersForTable(tableId);
            DisplayOrders();
            CalculateTotalPrice();
        }

        private void DisplayOrders()
        {
            // Clear existing rows
            dataGridView1.Rows.Clear();

            // Add orders to DataGridView
            foreach (var order in orders)
            {
                dataGridView1.Rows.Add(order.Item, order.Price);
            }
        }

        private void CalculateTotalPrice()
        {
            // Calculate total price and display it in the UI
            // Example:
            decimal totalPrice = orders.Sum(order => order.Price);
            totalLabel.Text = $"Total: {totalPrice:C}";
        }


        private void addButton_Click_1(object sender, EventArgs e)
        {
            // Retrieve input values for new order from UI
            string newItem = newItemTextBox.Text;
            decimal newPrice = decimal.Parse(newPriceTextBox.Text);

            // Add new order to the database
            try
            {
                databaseConnection.OpenConnection();
                string query = "INSERT INTO Orders (TableId, Item, Price) VALUES (@TableId, @Item, @Price)";
                MySqlCommand command = new MySqlCommand(query, databaseConnection.Connection);
                command.Parameters.AddWithValue("@TableId", tableId);
                command.Parameters.AddWithValue("@Item", newItem);
                command.Parameters.AddWithValue("@Price", newPrice);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // If insertion was successful, reload orders and update UI
                    LoadOrders();
                    MessageBox.Show("New order added successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add new order.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }
        }

        private void clearOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                databaseConnection.OpenConnection();
                string query = "DELETE FROM Orders WHERE TableId=@TableId";
                MySqlCommand command = new MySqlCommand(query, databaseConnection.Connection);
                command.Parameters.AddWithValue("@TableId", tableId);
                
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    
                    LoadOrders();
                    MessageBox.Show("Table Cleared");
                }
                else
                {
                    MessageBox.Show("Failed to add new order.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }
        }
    }
}
