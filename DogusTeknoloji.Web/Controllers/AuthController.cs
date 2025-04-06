using DogusTeknoloji.Web.Models.Services;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji.Web.Controllers;

public class AuthController(IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = userService.CreateUser(model);
            if (result) return RedirectToAction("SignIn", "Auth");
            ModelState.AddModelError("", "Kullanıcı oluşturulamadı.");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = userService.SignIn(model);
            if (result) return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Email veya şifre yanlış");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult SignOut()
    {
        userService.SignOut();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}