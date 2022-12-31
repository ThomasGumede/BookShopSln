using Core.Exceptions;
using System.Text;
using System.Text.Encodings.Web;
using System.Net.Mail;
using Data.Interfaces;
using Data.DTOs;
using Core;
using AutoMapper;
using Service.Interfaces;
using Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace Service;

public class AccountService : IAccountService
{
    // private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private User? _user;

    public AccountService(IMapper mapper, UserManager<User> userManager)
    {
        // _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        var user = _mapper.Map<User>(userRegisterDto);
        MailAddress userMail = new MailAddress(userRegisterDto.Email);
        user.UserName = userMail.User;
        var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
        if(result.Succeeded)
            await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

        return result;
    }

    public async Task<bool> ValidateUserAsync(UserLoginDto userLoginDto)
    {
        var userName = userLoginDto.Email;
        _user = await _userManager.FindByNameAsync(userName);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLoginDto.Password));
        // if (!result)
        //     _logger.LogWarn($"{nameof(ValidateUserAsync)}: Authentication failed. Wrong user name or password.");

        return result;
    }

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
