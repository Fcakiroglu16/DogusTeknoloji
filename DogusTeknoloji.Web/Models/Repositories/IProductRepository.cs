namespace DogusTeknoloji.Web.Models.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
}