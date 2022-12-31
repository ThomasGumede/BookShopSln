using Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Identity.SeedIdentity;

public static class SeedContext
{
    public static async Task SeedSuperAdminAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            FirstName = "Thomas",
            LastName = "Gumede",
            UserImageUri = "images/account/superadmin/img1.jpg",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                var results = await userManager.CreateAsync(defaultUser, "Admin123@");
                if (results.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }

            }

        }
    }

    public static async Task SeedAdminAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var adminUser = new User
        {
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            FirstName = "Wandile",
            LastName = "Gumede",
            UserImageUri = "images/account/admin/img1.jpg",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != adminUser.Id))
        {
            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var results = await userManager.CreateAsync(adminUser, "Admin123@");
                if (results.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                }

            }

        }
    }

    public static async Task SeedBasicAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var basicUser = new User
        {
            UserName = "basic@gmail.com",
            Email = "basic@gmail.com",
            FirstName = "Basic",
            LastName = "User",
            UserImageUri = "images/account/basic/img1.jpg",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != basicUser.Id))
        {
            var user = await userManager.FindByEmailAsync(basicUser.Email);
            if (user == null)
            {
                var results = await userManager.CreateAsync(basicUser, "Basic123@");
                if (results.Succeeded)
                {
                    await userManager.AddToRoleAsync(basicUser, Roles.Admin.ToString());
                }

            }

        }
    }
}


