using Dapper;
using Npgsql;
using Otus_Homework_15.Models;

namespace Otus_Homework_15.Repositories;

public class ProductsRepository
{
    public static IEnumerable<Product> GetProductList()
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     name AS Name, 
                                     description AS Description, 
                                     stock_quantity AS StockQuantity,
                                     price AS Price
                                 FROM products
                                 """;

            return connection.Query<Product>(query);
        }
    }

    public static Product? GetProductById(int id)
    {
        using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
        {
            const string query = """
                                 SELECT 
                                     id AS Id, 
                                     name AS Name, 
                                     description AS Description, 
                                     stock_quantity AS StockQuantity,
                                     price AS Price
                                 FROM products
                                 WHERE id = @id
                                 """;

            return connection.QueryFirstOrDefault<Product>(query);
        }
    }
}