using DogusTeknoloji.Web.Models.Services;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    //GET https://localhost:7092/api/Products
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = productService.GetAll();


        return Ok(products);
    }

    //[HttpGet("/api/categories")]
    //public IActionResult GetCategories()
    //{
    //    var products = productService.GetAll();


    //    return Ok(products);
    //}
}