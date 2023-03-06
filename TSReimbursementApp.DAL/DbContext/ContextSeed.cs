using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.DbContext
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FullName="Admin Ji",
                Bank="BOB",
                BankAccNumber=123456789,
                PANNumber=0581,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }

            }
        }
        public static async Task SeedBasicAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed basic User
            var basicUser = new ApplicationUser
            {
                UserName = "t@gmail.com",
                Email = "t@gmail.com",
                FullName = "Tushar Saxena",
                Bank = "HDFC",
                BankAccNumber = 123408754,
                PANNumber = 2342,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != basicUser.Id))
            {
                var user = await userManager.FindByEmailAsync(basicUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(basicUser, "123Pa$$word");
                    await userManager.AddToRoleAsync(basicUser, Enums.Roles.Basic.ToString());
                }

            }
        }
    }
}
