using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace Euphoria_ecommerce.SeedData
{
    public static class DbSeedData
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdminsAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure Admin role exists
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Array of admins (each with unique password)
        var admins = new (ApplicationUser User, string Password)[] 
        { 
            (new ApplicationUser 
            {
            UserName = "abdulrahman.mustafa", Email = "abdulrahman.mustafa@gmail.com", EmailConfirmed = true,
            Role = "Admin", PhoneNumber = "+962788362101", PhoneNumberConfirmed = true, 
        }, "Abdulrahman@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "layla.salem", Email = "layla.salem@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362102", PhoneNumberConfirmed = true, 
    }, "Layla@123"),
    
    (new ApplicationUser
    {
        UserName = "aya.abdullah", Email = "aya.abdullah@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788067196", PhoneNumberConfirmed = true, 
    }, "Aya.Abdullah@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "sara.khaled", Email = "sara.khaled@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362104", PhoneNumberConfirmed = true, 
    }, "Sara@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "ahmad.fahad", Email = "ahmad.fahad@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362105", PhoneNumberConfirmed = true, 
    }, "Ahmad@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "noor.jaber", Email = "noor.jaber@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362106", PhoneNumberConfirmed = true, 
    }, "Noor@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "khaled.omar", Email = "khaled.omar@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362107", PhoneNumberConfirmed = true, 
    }, "Khaled@1Admin@23"),
    
    (new ApplicationUser
    {
        UserName = "reem.fares", Email = "reem.fares@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362108", PhoneNumberConfirmed = true, 
    }, "Reem@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "yousef.tariq", Email = "yousef.tariq@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362109", PhoneNumberConfirmed = true, 
    }, "Yousef@Admin@123"),
    
    (new ApplicationUser
    {
        UserName = "amina.hadi", Email = "amina.hadi@gmail.com", EmailConfirmed = true,
        Role = "Admin", PhoneNumber = "+962788362110", PhoneNumberConfirmed = true, 
    }, "Amina@Admin@123"),
};


        foreach (var (admin, password) in admins)
        {
            var exists = await userManager.FindByEmailAsync(admin.Email!);
            if (exists is null)
            {
                await userManager.CreateAsync(admin, password);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
        }
    }
}
