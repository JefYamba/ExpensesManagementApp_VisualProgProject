using ExBudget.Config;
using ExBudget.Models;
using ExBudget.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Repositories
{
    public class CategoryRepository
    {
        private readonly string connectionString = AppConfig.CONNECTION_STRING;
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM categories ORDER BY category_name ASC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    TransactionType = EnumUtil.ToEnum<TransactionType>(reader.GetString(2)),
                                };

                                categories.Add(category);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }

            return categories;
        }
        public List<Category> GetAllByType(TransactionType transactionType)
        {
            // SELECT * FROM transactions WHERE transaction_date >= @date  ORDER BY transaction_date DESC
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM categories WHERE transaction_type = @transaction_type ORDER BY category_name ASC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transaction_type", transactionType.ToString());
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    TransactionType = EnumUtil.ToEnum<TransactionType>(reader.GetString(2)),
                                };

                                categories.Add(category);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }

            return categories;
        }

        public Category FindById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM categories WHERE id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    TransactionType = EnumUtil.ToEnum<TransactionType>(reader.GetString(2)),
                                };

                                connection.Close();
                                return category;
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return null;
        }

        internal Category FindByNameAndType(string name, TransactionType transactionType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM categories WHERE category_name=@category_name AND transaction_type=@transaction_type;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_name", name);
                        command.Parameters.AddWithValue("@transaction_type", transactionType.ToString());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    TransactionType = EnumUtil.ToEnum<TransactionType>(reader.GetString(2)),
                                };

                                connection.Close();
                                return category;
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return null;
        }

        public bool Create(Category category)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql =
                        "INSERT INTO categories " +
                        "(category_name, transaction_type)" +
                        "VALUES " +
                        "(@category_name, @transaction_type);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_name", category.Name);
                        command.Parameters.AddWithValue("@transaction_type", category.TransactionType.ToString());

                        command.ExecuteNonQuery();

                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return false;
        }
        public bool Update(Category category)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "UPDATE categories " +
                        "SET " +
                        "category_name=@category_name, " +
                        "transaction_type=@transaction_type " +
                        "WHERE id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_name", category.Name);
                        command.Parameters.AddWithValue("@transaction_type", category.TransactionType.ToString());
                        command.Parameters.AddWithValue("@id", category.Id);

                        command.ExecuteNonQuery();

                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM categories WHERE id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return false;
        }

        
    }
}
