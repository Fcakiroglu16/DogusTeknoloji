using DogusTeknoloji.Web.Models.Services.ViewModels;

namespace DogusTeknoloji.Web.Models.Services;

public interface IUserService
{
    bool CreateUser(CreateUserViewModel model);
    bool SignIn(SignInViewModel model);

    void SignOut();
}