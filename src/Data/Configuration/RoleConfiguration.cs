using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Data.Identity;

namespace Data.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Name = Roles.Basic.ToString(),
                NormalizedName = Roles.Basic.ToString().ToUpper()
            },
            new IdentityRole
            {
                Name = Roles.Moderator.ToString(),
                NormalizedName = Roles.Moderator.ToString().ToUpper()
            },
            new IdentityRole
            {
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper()
            },
            new IdentityRole
            {
                Name = Roles.SuperAdmin.ToString(),
                NormalizedName = Roles.SuperAdmin.ToString().ToUpper()
            }
        );
    }
}
