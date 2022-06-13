using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var demoUser = new ApplicationUser()
            {
                Email = Authorization.DEFAULT_USER_EMAIL,
                UserName = Authorization.DEFAULT_USER_EMAIL,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(demoUser, Authorization.DEFAULD_PASSWORD);

            var adminUser = new ApplicationUser()
            {
                Email = Authorization.DEFAULT_ADMIN_EMAIL,
                UserName = Authorization.DEFAULT_ADMIN_EMAIL,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(adminUser, Authorization.DEFAULD_PASSWORD);
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.ADMINISTRATOR));
            await userManager.AddToRoleAsync(adminUser,Authorization.Roles.ADMINISTRATOR);
        }
    }
}
