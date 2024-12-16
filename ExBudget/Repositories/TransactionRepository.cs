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
    public class TransactionRepository
    {
        private readonly string connectionString = AppConfig.CONNECTION_STRING;
        public List<Transaction> GetAll()
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM transactions ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }

        public List<Transaction> GetAllByCategoty(Category category)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM transactions WHERE category_id = @category_id  ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_id", category.Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }

        public List<Transaction> GetAllByCategotyFromDate(Category category, DateTime date)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM transactions WHERE category_id = @category_id AND transaction_date >= @date  ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_id", category.Id);
                        command.Parameters.AddWithValue("@date", date.Date);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }

        internal List<Transaction> GetAllByCategotyFromDateToDate(Category category, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "" +
                        "SELECT * " +
                        "FROM transactions " +
                        "WHERE category_id = @category_id " +
                        "AND transaction_date >= @from_date " +
                        "AND transaction_date < @to_date " +
                        "ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category_id", category.Id);
                        command.Parameters.AddWithValue("@from_date", fromDate.Date);
                        command.Parameters.AddWithValue("@to_date", toDate.Date.AddDays(1));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }
        public List<Transaction> GetAllFromDateToDate(DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "" +
                        "SELECT * " +
                        "FROM transactions " +
                        "WHERE transaction_date >= @from_date " +
                        "AND transaction_date < @to_date " +
                        "ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@from_date", fromDate.Date);
                        command.Parameters.AddWithValue("@to_date", toDate.Date.AddDays(1));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }

        public List<Transaction> GetAllFromDate(DateTime date)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM transactions WHERE transaction_date >= @date  ORDER BY transaction_date DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@date", date.Date);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                transactions.Add(transaction);
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

            return transactions;
        }

        

        public Transaction FindById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM transactions WHERE id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Category = GetCategory(reader.GetInt32(4))
                                };

                                connection.Close();
                                return transaction;
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


        public bool Create(Transaction transaction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql =
                        "INSERT INTO transactions " +
                        "(transaction_description, amount, transaction_date, category_id)" +
                        "VALUES " +
                        "(@transaction_description, @amount, @transaction_date, @category_id);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transaction_description", transaction.Description);
                        command.Parameters.AddWithValue("@amount", transaction.Amount);
                        command.Parameters.AddWithValue("@transaction_date", transaction.TransactionDate);
                        command.Parameters.AddWithValue("@category_id", transaction.Category.Id);

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
        public bool Update(Transaction transaction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "UPDATE transactions " +
                        "SET " +
                        "transaction_description=@transaction_description, " +
                        "amount=@amount, " +
                        "transaction_date=@transaction_date, " +
                        "category_id=@category_id " +
                        "WHERE id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transaction_description", transaction.Description);
                        command.Parameters.AddWithValue("@amount", transaction.Amount);
                        command.Parameters.AddWithValue("@transaction_date", transaction.TransactionDate);
                        command.Parameters.AddWithValue("@category_id", transaction.Category.Id);
                        command.Parameters.AddWithValue("@id", transaction.Id);

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

                    string sql = "DELETE FROM transactions WHERE id=@id;";
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


        private Category GetCategory(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Category category = categoryRepository.FindById(id);
            return category ?? throw new Exception("Category is null");
        }

        
    }
}
