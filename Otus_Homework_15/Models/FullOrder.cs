namespace Otus_Homework_15.Models;

public class OrderFull
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ProductID { get; set; }
    public int ProductQuantity { get; set; }
    public decimal ProductPrice { get; set; }
}