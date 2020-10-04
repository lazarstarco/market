using DataLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CategoryRepository
    {
        private string connectionString = new Connection().connectionString;

        public List<Category> GetCategories()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Category";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Category> listToReturn = new List<Category>();

                while (sqlDataReader.Read())
                {
                    Category category = new Category
                    {
                        Code = sqlDataReader.GetInt32(0),
                        Name = sqlDataReader.GetString(1),
                    };

                    listToReturn.Add(category);
                }

                return listToReturn;
            }
        }
        public int InsertCategory(Category category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Category (Code, Name) VALUES(" + string.Format(
                    "{0}, '{1}'", category.Code, category.Name) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int UpdateCategory(Category category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Category SET " +
                    "Name = '" + category.Name + "' " +
                    "WHERE Code = " + category.Code;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
