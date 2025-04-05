using DogusTeknoloji.Web.Models.Repositories;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusTeknoloji.Web.Models.Services;

public class ProductService : IProductService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public List<ProductViewModel> GetAll()
    {
        var productList = _productRepository.GetAll();

        var productViewModelList = new List<ProductViewModel>();

        foreach (var product in productList)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = (product.Price * 1.20m).ToString("C"),
                Stock = product.Stock,
                CategoryName = product.Category.Name
            };
            productViewModelList.Add(productViewModel);
        }

        return productViewModelList;
    }

    public CreateProductViewModel CreateViewModel()
    {
        var categories = _categoryRepository.GetAll();

        var createProductViewModel = new CreateProductViewModel();

        createProductViewModel.CategoryList = new SelectList(categories, "Id", "Name");


        return createProductViewModel;
    }

    public CreateProductViewModel CreateViewModel(CreateProductViewModel createProductViewModel)
    {
        var categories = _categoryRepository.GetAll();
        createProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", createProductViewModel.CategoryId);

        return createProductViewModel;
    }


    public void Create(CreateProductViewModel createProductViewModel)
    {
        var product = new Product
        {
            Name = createProductViewModel.Name!,
            Description = createProductViewModel.Description,
            Price = createProductViewModel.Price!.Value,
            Stock = createProductViewModel.Stock!.Value,
            CategoryId = createProductViewModel.CategoryId!.Value
        };
        _productRepository.Add(product);
    }


    public ProductViewModel? GetById(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null) return null!;
        var productViewModel = new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = (product.Price * 1.20m).ToString("C"),
            Stock = product.Stock,
            CategoryName = product.Category.Name
        };
        return productViewModel;
    }

    public void Remove(int id)
    {
        var product = _productRepository.GetById(id);
        if (product != null) _productRepository.Delete(product);
    }

    public EditProductViewModel? EditViewModel(int id)
    {
        var product = _productRepository.GetById(id);


        if (product == null) return null;
        var categories = _categoryRepository.GetAll();
        var editProductViewModel = new EditProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };
        editProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", editProductViewModel.CategoryId);
        return editProductViewModel;
    }


    public void Update(EditProductViewModel editProductViewModel)
    {
        var product = _productRepository.GetById(editProductViewModel.Id);
        if (product == null) return;

        product.Name = editProductViewModel.Name!;
        product.Description = editProductViewModel.Description;
        product.Price = editProductViewModel.Price!.Value;
        product.Stock = editProductViewModel.Stock!.Value;
        product.CategoryId = editProductViewModel.CategoryId!.Value;
        _productRepository.Update(product);
    }

    public EditProductViewModel? EditViewModel(EditProductViewModel editProductViewModel)
    {
        var categories = _categoryRepository.GetAll();
        editProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", editProductViewModel.CategoryId);
        return editProductViewModel;
    }
}