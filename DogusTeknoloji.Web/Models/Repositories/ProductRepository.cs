using Microsoft.EntityFrameworkCore;

namespace DogusTeknoloji.Web.Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        //eager loading
        return _context.Products.Include(x => x.Category).ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}