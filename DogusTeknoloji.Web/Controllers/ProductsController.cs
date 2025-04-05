using DogusTeknoloji.Web.Models.Services;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji.Web.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    public IActionResult Index()
    {
        var products = productService.GetAll();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var createProductViewModel = productService.CreateViewModel();
        return View(createProductViewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateProductViewModel createProductViewModel)
    {
        if (!ModelState.IsValid) return View(productService.CreateViewModel(createProductViewModel));
        productService.Create(createProductViewModel);


        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        productService.Remove(id);


        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(productService.EditViewModel(id));
    }

    [HttpPost]
    public IActionResult Edit(EditProductViewModel editProductViewModel)
    {
        if (!ModelState.IsValid) return View(productService.EditViewModel(editProductViewModel));

        productService.Update(editProductViewModel);
        return RedirectToAction("Index");
    }
}