using CEM.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace CEM.DAL
{
    public static class ApplicationContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationContext context)
        {
            #region ROLES
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }).ConfigureAwait(false);

                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }).ConfigureAwait(false);
            }
            #endregion ROLES

            #region DEFAULT USER
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.co.za",
                FirstName = "Admin",
                LastName = "User",
                IsActive = true
            };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Password1!").ConfigureAwait(false);
                await userManager.AddToRoleAsync(defaultUser, "Admin").ConfigureAwait(false);
            }
            #endregion DEFAULT USER

            #region DEFAULT EMPLOYEE
            var employeeUser = new ApplicationUser
            {
                UserName = "Employee1",
                Email = "employee1@user.co.za",
                FirstName = "Employee",
                LastName = "User",
                IsActive = true
            };

            if (userManager.Users.All(u => u.UserName != employeeUser.UserName))
            {
                await userManager.CreateAsync(employeeUser, "Password1!").ConfigureAwait(false);
                await userManager.AddToRoleAsync(employeeUser, "Employee").ConfigureAwait(false);

                var defaultEmployee = new Employee
                {
                    UserId = employeeUser.Id,
                    IsActive = true
                };

                await context.AddAsync(defaultEmployee).ConfigureAwait(false);
            }
            #endregion DEFAULT EMPLOYEE

            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
