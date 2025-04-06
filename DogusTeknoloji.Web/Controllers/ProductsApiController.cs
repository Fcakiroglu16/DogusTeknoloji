using DogusTeknoloji.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji.Web.Controllers;

public class ProductsApiController(ProductApiService productApiService) : Controller
{
    public IActionResult Index()
    {
        ViewBag.products = productApiService.GetAll();
        return View();
    }
}