namespace DogusTeknoloji2.API.Models.Repositories;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int CategoryId { get; set; }

    public bool IsPublished { get; set; }

    // Navigation property for the related Category entity
    public Category Category { get; set; } = null!;
}