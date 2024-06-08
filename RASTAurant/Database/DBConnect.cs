using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RASTAurant.Database
{
    internal class DBConnect
    {
        private static MySqlConnection dbConnection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "username";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            dbConnection = new MySqlConnection(connectionString);
            return dbConnection;
        }
    }
}
