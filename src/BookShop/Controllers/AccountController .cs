using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Data.Interfaces;
using BookShop.Models;
using Data.Identity;
using Microsoft.AspNetCore.Authentication;

namespace BookShop.Controllers;


public class AccountController : Controller
{
    private readonly ILoggerManager _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(ILoggerManager logger, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<ViewResult> Login(string? returnUrl = null)
    {
        await HttpContext.SignOutAsync();
        var model = new LoginVM { ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            var userName = model.Email;
     
                if (IsValidEmail(model.Email))
                {
                     var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        userName = user.UserName;
                    }
            }
    
            var result = await _signInManager.PasswordSignInAsync(userName!, model.Password, model.RememberMe, lockoutOnFailure: false);

            if(result.Succeeded)
            {
                if(!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }else{
                    return RedirectToAction("Index", "Home");
                }
            }else{
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
        }

        return View(model);
    }


    [HttpGet]
    public ViewResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if(ModelState.IsValid)
        {
            MailAddress email = new MailAddress(model.Email);
            var userName = email.User;
            var user = new User
            {
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }else{
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout(string? returnUrl = null)
    {
        await _signInManager.SignOutAsync();

        if (returnUrl != null)
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    public ViewResult ForgotPassword()
    {
        // TODO
        return View();
    }

    public ViewResult ResetPassword()
    {
        // TODO
        return View();
    }

    [NonAction]
    private bool IsValidEmail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

}
