using Dapper;
using Npgsql;
using Otus_Homework_15.Models;

namespace Otus_Homework_15.Repositories;

public class FullOrderRepository
{
    public static IEnumerable<FullOrder> GetOrdersByProductId(int productId)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     c.id AS CustomerID,
                                     c.first_name AS FirstName,
                                     c.last_name AS LastName,
                                     o.product_id AS ProductID,
                                     o.quantity AS ProductQuantity,
                                     p.price AS ProductPrice
                                 FROM orders o
                                 JOIN customers c ON o.customer_id = c.id
                                 JOIN products p ON o.product_id = p.id
                                 WHERE c.Age > 30
                                   AND o.product_id = @ProductId;
                                 """;

            return connection.Query<FullOrder>(query, new { productId });
        }
    }
}