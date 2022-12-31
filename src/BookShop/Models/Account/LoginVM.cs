using System.ComponentModel.DataAnnotations;

namespace BookShop.Models;

public class LoginVM
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; } = string.Empty;
}
