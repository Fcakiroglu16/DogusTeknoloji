using DogusTeknoloji.Web.Models.Services;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji.Web.Controllers;

[Authorize]
public class ProductsController(IProductService productService) : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        // productList > Object > List<ProductViewModel>
        var products = productService.GetAll();

        ViewBag.productList = products;
        //ViewBag.Name = "Dogus Teknoloji";
        return View();
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

    [Authorize(Roles = "Admin")]
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