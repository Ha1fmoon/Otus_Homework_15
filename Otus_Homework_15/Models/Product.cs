namespace Otus_Homework_15.Models;

public record Product : ICustomRecord
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public int Price { get; set; }
}