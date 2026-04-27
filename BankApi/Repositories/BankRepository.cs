using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BankApi.Repositories
{
 
    public class BankRepository : IAccountRepository
    {

        private readonly IConfiguration _configuration;

        public BankRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Add(BankAccount acc)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query = "INSERT INTO Accounts (Balance, AccountType) VALUES (@balance, @acctype) SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@balance", acc.Balance);
                cmd.Parameters.AddWithValue("@acctype", acc.GetType().Name);

                int id = Convert.ToInt32(cmd.ExecuteScalar());

                string accNo = "ACC" + id;

                acc.SetAccountNumber(accNo);
            }
        }


        public BankAccount? GetbyAccountNumber(string accountNumber)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Accounts WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, connection);

                int id = int.Parse(accountNumber.Replace("ACC", ""));
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string accNo = "ACC" + reader["Id"].ToString();
                    decimal balance = (decimal)reader["Balance"];
                    string type = reader["AccountType"].ToString();


                    BankAccount acc;

                    if (type == "SavingAccount")
                    {
                        acc = new SavingAccount(accNo);

                    }
                    else if (type == "CurrentAccount")
                    {
                        acc = new CurrentAccount(accNo);
                    }
                    else if (type == "StudentAccount")
                    {
                        acc = new StudentAccount(accNo);
                    }
                    else
                    {
                        throw new Exception("Invalid account type");
                    }
                    acc.SetBalance(balance);

                    return acc;

                }
            }

            return null;
        }
        public void UpdateBalance(string accountNumber, decimal amount)
        {
            string connectionString = "Server=SANAN\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Accounts SET Balance = @amount WHERE Id = @id";

                int id = int.Parse(accountNumber.Replace("ACC", ""));

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("Balance Update Failed");
                }
            }
        }

        public void TransferBalance(string fromAccount, string toAccount, decimal amount)
        {
            string connection = "Server=SANAN\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;";

            int fromId = int.Parse(fromAccount.Replace("ACC", ""));
            int toId = int.Parse(toAccount.Replace("ACC", ""));

            using (SqlConnection cn = new SqlConnection(connection))
            {
                cn.Open();

                SqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    string withdrawQuery = "UPDATE Accounts SET Balance = Balance - @amount WHERE Id = @fromId";
                    string depositQuery = "UPDATE Accounts SET Balance = Balance + @amount WHERE Id = @toId";

                    SqlCommand withdrawCmd = new SqlCommand(withdrawQuery, cn, transaction);
                    SqlCommand depositCmd = new SqlCommand(depositQuery, cn, transaction);

                    withdrawCmd.Parameters.AddWithValue("@amount", amount);
                    withdrawCmd.Parameters.AddWithValue("@fromId", fromId);

                    depositCmd.Parameters.AddWithValue("@amount", amount);
                    depositCmd.Parameters.AddWithValue("@toId", toId);

                    withdrawCmd.ExecuteNonQuery();
                    depositCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


    }
}
