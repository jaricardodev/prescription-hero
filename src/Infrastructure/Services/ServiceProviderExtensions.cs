using Cosmos.Abstracts.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IdentityRole = Cosmos.Identity.IdentityRole;
using IdentityUser = Cosmos.Identity.IdentityUser;
using IdentityClaim = Cosmos.Identity.IdentityClaim;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public static class ServiceProviderExtensions
    {
        public static readonly string AdminRole = "Admin";
        private static readonly string AdminEmail = "admin@email.com";
        private static readonly string AdminPassword = "Ab1234567*";
        private static readonly string[] sourceArray = [AdminRole, "Patient", "Prescriber"];

        public static async Task<IServiceProvider> SeedRoles(this IServiceProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider), "A service provider is required.");


            using var scope = provider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = await roleManager.Roles.ToListAsync();

            var createRolesTaks = sourceArray.Where(roleName => !roles.Any(role => role.Name == roleName))
                 .Select(roleName => roleManager.CreateAsync(new IdentityRole { Name = roleName, Claims = [new() { Type = ClaimTypes.Role, Value = roleName }] }));


            await Task.WhenAll(createRolesTaks);

            return provider;
        }

        public static async Task<IServiceProvider> SeedAdminUser(this IServiceProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider), "A service provider is required.");

            using var scope = provider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            if (await userManager.FindByEmailAsync(AdminEmail) == null)
            {
                var user = new IdentityUser
                {
                    Email = AdminEmail,
                    UserName = AdminEmail,
                    Claims = [                    
                        new() {Type = ClaimTypes.Name, Value = AdminEmail},
                        new() {Type = ClaimTypes.Email, Value = AdminEmail}
                    ]
                };

                await userManager.CreateAsync(user, AdminPassword);

                await userManager.AddToRoleAsync(user, AdminRole);
            }


            return provider;
        }
    }
}
