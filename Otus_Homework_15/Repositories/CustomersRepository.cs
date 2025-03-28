using Dapper;
using Npgsql;

namespace Otus_Homework_15;

public class CustomerRepository
{
    public static IEnumerable<Customer> GetCustomers()
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     first_name AS FirstName, 
                                     last_name AS LastName, 
                                     age AS Age 
                                 FROM customers 
                                 """;
            
            return connection.Query<Customer>(query);
        }
    }

    public static Customer? GetCustomerById(int id)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     first_name AS FirstName, 
                                     last_name AS LastName, 
                                     age AS Age 
                                 FROM customers
                                 WHERE id = @id
                                 """;
            
            return connection.QueryFirstOrDefault<Customer>(query, new { id });
        }
    }

    public static IEnumerable<Customer> GetCustomersByNamePart(string namePart)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     first_name AS FirstName, 
                                     last_name AS LastName, 
                                     age AS Age 
                                 FROM customers
                                 WHERE first_name LIKE '%' || @namePart || '%' OR last_name LIKE '%' || @namePart || '%'
                                 """;
            
            return connection.Query<Customer>(query, new { namePart });
        }
    }
}