using DogusTeknoloji.Web.Models.Services.Dtos;
using DogusTeknoloji.Web.Models.Services.ViewModels;

namespace DogusTeknoloji.Web.Models.Services;

public class ProductApiService(HttpClient client)
{
    public List<ProductViewModel> GetAll()
    {
        var response = client.GetAsync("/api/products").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<List<ProductDto>>().Result;

            var products = new List<ProductViewModel>();
            foreach (var item in result)
                products.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Stock = item.Stock,
                    CategoryName = item.CategoryName,
                    IsPublished = item.IsPublished
                });

            return products;
        }

        throw new Exception("Api'den veri alınamadı.");
    }
}