using DogusTeknoloji.Web.Models.Services.ViewModels;
using DogusTeknoloji2.API.Models.Services.Dtos;

namespace DogusTeknoloji.Web.Models.Services;

public interface IProductService
{
    List<ProductDto> GetAll();

    CreateProductDto CreateViewModel();

    CreateProductDto CreateViewModel(CreateProductDto createProductViewModel);

    void Create(CreateProductDto createProductViewModel);


    ProductDto? GetById(int id);
    EditProductDto? EditViewModel(int id);

    EditProductDto? EditViewModel(EditProductDto editProductViewModel);
    void Remove(int id);
    void Update(EditProductDto editProductViewModel);
}