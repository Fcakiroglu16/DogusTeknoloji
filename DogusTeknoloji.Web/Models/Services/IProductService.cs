using DogusTeknoloji.Web.Models.Services.ViewModels;

namespace DogusTeknoloji.Web.Models.Services;

public interface IProductService
{
    List<ProductViewModel> GetAll();

    CreateProductViewModel CreateViewModel();

    CreateProductViewModel CreateViewModel(CreateProductViewModel createProductViewModel);

    void Create(CreateProductViewModel createProductViewModel);


    ProductViewModel? GetById(int id);
    EditProductViewModel? EditViewModel(int id);

    EditProductViewModel? EditViewModel(EditProductViewModel editProductViewModel);
    void Remove(int id);
    void Update(EditProductViewModel editProductViewModel);
}