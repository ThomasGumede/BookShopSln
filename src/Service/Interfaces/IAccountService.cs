using Data.DTOs;
using Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace Service.Interfaces;

public interface IAccountService
{
    Task<IdentityResult> RegisterUserAsync(UserRegisterDto userRegisterDto);
}
