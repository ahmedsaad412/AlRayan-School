using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AlRayan.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AlRayan.Data
{
    public static class Seeding
    {


        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                string[] roles = new string[] { "Admin", "Teatcher", "Student" };

                try
                {
                    foreach (string role in roles)
                    {
                        var roleStore = new RoleStore<IdentityRole>(context);

                        if (!context.Roles.Any(r => r.Name == role))
                        {
                            roleStore.CreateAsync(new IdentityRole(role));
                        }
                    }


                    var user = new ApplicationUser
                    {
                        FirstName = "Sara",
                        LastName = "ahmed",
                        Email = "Admin1@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        UserName = "Admin1",
                        NormalizedUserName = "ADMIN1",
                        PhoneNumber = "01019149241",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                        
                    };


                    if (!context.Users.Any(u => u.UserName == user.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(user, "secret");
                        user.PasswordHash = hashed;

                        var userStore = new UserStore<ApplicationUser>(context);
                        var result = userStore.CreateAsync(user);
                    }

                    AssignRoles((IServiceProvider)scope, user.Email, roles);

                    context.SaveChangesAsync();

                }
                catch (Exception)
                {

                    throw;
                }
                return app;

            }
            static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
            {
                UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.AddToRolesAsync(user, roles);

                return result;
            }

        }

    }
}
