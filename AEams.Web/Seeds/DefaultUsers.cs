using Microsoft.AspNetCore.Identity;

namespace AEams.Web.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin = new()
            {
                UserName = "admin",
                Email = "admin@aeams.com",
                FullName = "Admin",
                EmailConfirmed = true,
                NationalID = 0000000000,
                Nationality = "Private"
            };

            var user = await userManager.FindByNameAsync(admin.UserName);

            if (user is null)
            {
                await userManager.CreateAsync(admin, "P@ssword123");
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
            }
        }
    }
}
