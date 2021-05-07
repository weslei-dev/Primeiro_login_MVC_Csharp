using Dapper;
using Login_MVC_.Models;
using System.Data.SqlClient;

namespace Login_MVC_.Repositorios
{
    public class AccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository()
        {
            _connectionString = "Server=WESLEI04;Database=BDD_Primeiro_Login;Trusted_Connection=True;";
        }

        public Account Verify(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.QueryFirstOrDefault<Account>(@"SELECT Name, Password 
                                                                FROM UserName 
                                                               WHERE Name = @Name 
                                                                AND Password = @Password", param: account);

                return result;
            }
        }
    }
}