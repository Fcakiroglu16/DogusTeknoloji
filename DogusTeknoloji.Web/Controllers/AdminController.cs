using DogusTeknoloji.Web.Models.Repositories.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DogusTeknoloji.Web.Controllers;

public class AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : Controller
{
    public IActionResult Index()
    {
        var roleToCreateResult = roleManager.CreateAsync(new AppRole { Name = "Admin" }).Result;

        if (roleToCreateResult.Succeeded)
        {
            var hasUser = userManager.FindByEmailAsync("fcakiroglu16@outlook.com").Result;

            if (hasUser is not null) userManager.AddToRoleAsync(hasUser, "Admin").Wait();
        }


        return View();
    }
}