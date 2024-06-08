using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RASTAurant.Database.Models;
using System;

namespace RASTAurant.Database
{
    


    public sealed class DatabaseConnection
    {
        private static DatabaseConnection _instance = null;
        private static readonly object _lock = new object();
        private MySqlConnection _connection;




        private string _connectionString = "server=localhost;userid=root;password=;database=restaurant";

        private DatabaseConnection()
        {
            _connection = new MySqlConnection(_connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                    return _instance;
                }
            }
        }

        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Example method to execute a query
        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            return cmd.ExecuteReader();
        }

        public List<Layout> GetAllLayouts()
        {
            List<Layout> layouts = new List<Layout>();
            try
            {
                OpenConnection();

                string query = "SELECT l.Id, l.Name, tp.X, tp.Y, tp.TId FROM Layouts l " +
                               "LEFT JOIN TablePositions tp ON l.Id = tp.LayoutId " +
                               "ORDER BY l.Id";
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                Layout currentLayout = null;
                while (reader.Read())
                {
                    int layoutId = reader.GetInt32("Id");
                    string layoutName = reader.GetString("Name");
                    int tableId = reader.GetInt32("TId");
                    int x = reader.GetInt32("X");
                    int y = reader.GetInt32("Y");

                    if (currentLayout == null || currentLayout.Id != layoutId)
                    {
                        if (currentLayout != null)
                        {
                            layouts.Add(currentLayout);
                        }

                        currentLayout = new Layout
                        {
                            Id = layoutId,
                            Name = layoutName,
                            TablePositions = new List<TablePosition>()
                        };
                    }

                    currentLayout.TablePositions.Add(new TablePosition(tableId , x, y));
                }

                if (currentLayout != null)
                {
                    layouts.Add(currentLayout);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return layouts;
        }

        public List<Order> GetOrdersForTable(int tableId)
        {
            List<Order> orders = new List<Order>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM Orders WHERE TableId = @TableId";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.Parameters.AddWithValue("@TableId", tableId);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int orderId = reader.GetInt32("OrderId");
                    string item = reader.GetString("Item");
                    decimal price = reader.GetDecimal("Price");

                    Order order = new Order(orderId, tableId, item, price);
                    orders.Add(order);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return orders;
        }

    }




}
