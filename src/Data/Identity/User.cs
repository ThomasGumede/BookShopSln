using Microsoft.AspNetCore.Identity;

namespace Data.Identity;

public class User : IdentityUser
{
    public string? UserImageUri { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}