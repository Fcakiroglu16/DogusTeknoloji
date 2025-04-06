using DogusTeknoloji.Web.Models.Repositories.Entities;
using DogusTeknoloji.Web.Models.Services.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DogusTeknoloji.Web.Models.Services;

public class UserService : IUserService
{
    private readonly RoleManager<AppRole> roleManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;

    public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
    }

    public bool CreateUser(CreateUserViewModel model)
    {
        var user = new AppUser
        {
            UserName = model.UserName,
            Email = model.Email,
            BirthDate = model.BirthDate
        };
        var result = userManager.CreateAsync(user, model.Password).Result;


        return result.Succeeded;
    }

    public bool SignIn(SignInViewModel model)
    {
        var hasUser = userManager.FindByEmailAsync(model.Email).Result;

        if (hasUser == null) return false;


        var result = signInManager.PasswordSignInAsync(hasUser.UserName!, model.Password, true, false).Result;
        return result.Succeeded;
    }

    public void SignOut()
    {
        signInManager.SignOutAsync();
    }
}