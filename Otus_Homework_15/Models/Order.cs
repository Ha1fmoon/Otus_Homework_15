namespace Otus_Homework_15.Models;

public record Order : ICustomRecord
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
}