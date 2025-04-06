using Microsoft.AspNetCore.Identity;

namespace DogusTeknoloji.Web.Models.Repositories.Entities;

public class AppUser : IdentityUser<Guid>
{
    public DateTime BirthDate { get; set; }
}