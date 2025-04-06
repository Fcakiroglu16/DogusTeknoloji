namespace DogusTeknoloji.Web.Models.Services.ViewModels;

public class CreateUserViewModel
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Password { get; set; } = null!;
}