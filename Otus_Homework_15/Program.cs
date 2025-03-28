using System.Text;
using Otus_Homework_15.Models;
using Otus_Homework_15.Repositories;

namespace Otus_Homework_15;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Customers table.");
        Console.WriteLine("1. Get all customers:");
        Console.WriteLine(GetCustomers());
        Console.WriteLine("2. Get customer by ID = 1:");
        Console.WriteLine(GetCustomerById(1));
        Console.WriteLine("3. Get customers by name part (search string = 'ва'):");
        Console.WriteLine(GetCustomersByNamePart("ва"));

        Console.WriteLine("Orders table.");
        Console.WriteLine("1. Get orders by customer ID = 4:");
        Console.WriteLine(GetOrdersByCustomerId(4));
        Console.WriteLine("2. Get orders by product ID = 1:");
        Console.WriteLine(GetOrdersByProductId(1));

        Console.WriteLine("Products table.");
        Console.WriteLine("1. Get all products:");
        Console.WriteLine(GetProductList());
        Console.WriteLine("2. Get product by ID = 1:");
        Console.WriteLine(GetProductById(1));

        Console.WriteLine("Full order query (Homework 14, product ID = 1):");
        Console.WriteLine(GetOrdersByCustomQuery(1));
    }

    private static string? GetCustomers()
    {
        var customers = CustomersRepository.GetCustomers().ToList();

        return ConvertListToString(customers);
    }

    private static string? GetCustomerById(int id)
    {
        var customer = CustomersRepository.GetCustomerById(id);

        return customer?.ToString();
    }

    private static string? GetCustomersByNamePart(string namePart)
    {
        var customers = CustomersRepository.GetCustomersByNamePart(namePart).ToList();

        return ConvertListToString(customers);
    }

    private static string? GetOrdersByCustomerId(int customerId)
    {
        var orders = OrdersRepository.GetOrdersByCustomerId(customerId).ToList();

        return ConvertListToString(orders);
    }

    private static string? GetOrdersByProductId(int productId)
    {
        var orders = OrdersRepository.GetOrdersByProductId(productId).ToList();

        return ConvertListToString(orders);
    }

    private static string? GetProductList()
    {
        var products = ProductsRepository.GetProductList().ToList();

        return ConvertListToString(products);
    }

    private static string? GetProductById(int id)
    {
        var product = ProductsRepository.GetProductById(id);

        return product?.ToString();
    }

    private static string? GetOrdersByCustomQuery(int productId)
    {
        var orders = FullOrderRepository.GetOrdersByProductId(productId).ToList();

        return ConvertListToString(orders);
    }

    private static string? ConvertListToString<T>(List<T>? list)
        where T : ICustomRecord
    {
        if (list == null || list.Count == 0)
            return null;

        var sb = new StringBuilder();
        foreach (var item in list) sb.AppendLine(item.ToString());
        return sb.ToString();
    }
}