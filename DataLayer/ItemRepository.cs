using System.Collections.Generic;
using DataLayer.Models;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ItemRepository
    {
        private string connectionString = new Connection().connectionString;

        public List<Item> GetItems()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Item";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Item> listToReturn = new List<Item>();

                while (sqlDataReader.Read())
                {
                    Item item = new Item
                    {
                        Code = sqlDataReader.GetString(0),
                        Quantity = sqlDataReader.GetInt32(1),
                        UserCode = sqlDataReader.GetInt32(2),
                        ProductCode = sqlDataReader.GetInt32(3)
                    };

                    listToReturn.Add(item);
                }

                return listToReturn;
            }
        }
        public int InsertItem(Item item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Item (Code, Quantity, UserCode, ProductCode) VALUES(" + string.Format(
                    "'{0}', {1}, {2}, {3}", item.Code, item.Quantity, item.UserCode, item.ProductCode) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }




        public List<Item> GetItemsByCode(int code)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Item WHERE UserCode = " + code;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Item> listToReturn = new List<Item>();

                while (sqlDataReader.Read())
                {
                    Item item = new Item
                    {
                        Code = sqlDataReader.GetString(0),
                        Quantity = sqlDataReader.GetInt32(1),
                        UserCode = sqlDataReader.GetInt32(2),
                        ProductCode = sqlDataReader.GetInt32(3)
                    };

                    listToReturn.Add(item);
                }

                return listToReturn;
            }
        }
        public List<Item> GetItemsByDate(string date)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Item WHERE Code LIKE '" + date + "%'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Item> listToReturn = new List<Item>();

                while (sqlDataReader.Read())
                {
                    Item item = new Item
                    {
                        Code = sqlDataReader.GetString(0),
                        Quantity = sqlDataReader.GetInt32(1),
                        UserCode = sqlDataReader.GetInt32(2),
                        ProductCode = sqlDataReader.GetInt32(3)
                    };

                    listToReturn.Add(item);
                }

                return listToReturn;
            }
        }
        public List<Item> GetItemsByCategory(int category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Item WHERE ProductCode LIKE '" + category + "____'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Item> listToReturn = new List<Item>();

                while (sqlDataReader.Read())
                {
                    Item item = new Item
                    {
                        Code = sqlDataReader.GetString(0),
                        Quantity = sqlDataReader.GetInt32(1),
                        UserCode = sqlDataReader.GetInt32(2),
                        ProductCode = sqlDataReader.GetInt32(3)
                    };

                    listToReturn.Add(item);
                }

                return listToReturn;
            }
        }
        public List<Item> GetItemsByProduct(int product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Item WHERE ProductCode = " + product;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Item> listToReturn = new List<Item>();

                while (sqlDataReader.Read())
                {
                    Item item = new Item
                    {
                        Code = sqlDataReader.GetString(0),
                        Quantity = sqlDataReader.GetInt32(1),
                        UserCode = sqlDataReader.GetInt32(2),
                        ProductCode = sqlDataReader.GetInt32(3)
                    };

                    listToReturn.Add(item);
                }

                return listToReturn;
            }
        }
    }
}