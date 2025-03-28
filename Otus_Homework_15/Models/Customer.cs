namespace Otus_Homework_15.Models;

public record Customer : ICustomRecord
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}