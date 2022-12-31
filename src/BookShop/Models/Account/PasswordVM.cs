using System.ComponentModel.DataAnnotations;

namespace BookShop.Models;

public class PasswordVM
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;
}


