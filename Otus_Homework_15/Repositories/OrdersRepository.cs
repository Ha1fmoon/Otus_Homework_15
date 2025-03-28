using Dapper;
using Npgsql;
using Otus_Homework_15.Models;

namespace Otus_Homework_15.Repositories;

public class OrdersRepository
{
    public static IEnumerable<Order> GetOrdersByCustomerId(int customerId)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     product_id AS ProductId, 
                                     customer_id AS CustomerId, 
                                     quantity AS Quantity
                                 FROM orders
                                 WHERE customer_id = @customerId
                                 """;

            return connection.Query<Order>(query, new { customerId });
        }
    }

    public static IEnumerable<Order> GetOrdersByProductId(int productId)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     product_id AS ProductId, 
                                     customer_id AS CustomerId, 
                                     quantity AS Quantity
                                 FROM orders
                                 WHERE product_id = @productId
                                 """;

            return connection.Query<Order>(query, new { productId });
        }
    }
}