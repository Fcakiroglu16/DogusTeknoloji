using DogusTeknoloji.Web.Models.Services.ViewModels;
using DogusTeknoloji2.API.Models.Repositories;
using DogusTeknoloji2.API.Models.Services.Dtos;
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

    public List<ProductDto> GetAll()
    {
        var productList = _productRepository.GetAll();

        var productViewModelList = new List<ProductDto>();

        foreach (var product in productList)
        {
            var productViewModel = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = (product.Price * 1.20m).ToString("C"),
                Stock = product.Stock,
                CategoryName = product.Category.Name,
                IsPublished = product.IsPublished
            };
            productViewModelList.Add(productViewModel);
        }

        return productViewModelList;
    }

    public CreateProductDto CreateViewModel()
    {
        var categories = _categoryRepository.GetAll();

        var createProductViewModel = new CreateProductDto();

        createProductViewModel.CategoryList = new SelectList(categories, "Id", "Name");


        return createProductViewModel;
    }

    public CreateProductDto CreateViewModel(CreateProductDto createProductViewModel)
    {
        var categories = _categoryRepository.GetAll();
        createProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", createProductViewModel.CategoryId);

        return createProductViewModel;
    }


    public void Create(CreateProductDto createProductViewModel)
    {
        var product = new Product
        {
            Name = createProductViewModel.Name!,
            Description = createProductViewModel.Description,
            Price = createProductViewModel.Price!.Value,
            Stock = createProductViewModel.Stock!.Value,
            CategoryId = createProductViewModel.CategoryId!.Value,
            IsPublished = createProductViewModel.IsPublished
        };
        _productRepository.Add(product);
    }


    public ProductDto? GetById(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null) return null!;
        var productViewModel = new ProductDto
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

    public EditProductDto? EditViewModel(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null) return null;
        var categories = _categoryRepository.GetAll();
        var editProductViewModel = new EditProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            IsPublished = product.IsPublished
        };
        editProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", editProductViewModel.CategoryId);
        return editProductViewModel;
    }


    public void Update(EditProductDto editProductViewModel)
    {
        var product = _productRepository.GetById(editProductViewModel.Id);
        if (product == null) return;

        product.Name = editProductViewModel.Name!;
        product.Description = editProductViewModel.Description;
        product.Price = editProductViewModel.Price!.Value;
        product.Stock = editProductViewModel.Stock!.Value;
        product.CategoryId = editProductViewModel.CategoryId!.Value;
        product.IsPublished = editProductViewModel.IsPublished;
        _productRepository.Update(product);
    }

    public EditProductDto? EditViewModel(EditProductDto editProductViewModel)
    {
        var categories = _categoryRepository.GetAll();
        editProductViewModel.CategoryList = new SelectList(categories, "Id", "Name", editProductViewModel.CategoryId);
        return editProductViewModel;
    }
}