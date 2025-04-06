namespace DogusTeknoloji.Web.Models.Services.ViewModels;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Price { get; set; } = null!;
    public int Stock { get; set; }

    public string CategoryName { get; set; } = null!;
    public bool IsPublished { get; set; }
}