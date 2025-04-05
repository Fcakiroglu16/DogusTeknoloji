namespace DogusTeknoloji.Web.Models.Services.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Price { get; set; } = null!;
    public int Stock { get; set; }

    public string CategoryName { get; set; } = null!;
}