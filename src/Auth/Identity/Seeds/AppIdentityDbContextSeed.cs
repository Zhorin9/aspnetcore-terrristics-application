using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Identity.Seeds
{
    public class AppIdentityDbContextSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppIdentityDbContext _ctx;

        public AppIdentityDbContextSeed(AppIdentityDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _ctx = ctx;
        }
        
        public async Task SeedAsync()
        {
            //Seed the main user
            ApplicationUser user = await _userManager.FindByEmailAsync("jaros.przemyslaw51@gmail.com");

            if(user == null)
            {
                user = new ApplicationUser()
                {
                    FirstName = "Przemyslaw",
                    LastName = "Jaros",
                    Email = "jaros.przemyslaw51@gmail.com",
                    UserName = "jaros.przemyslaw51@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }

                await _ctx.SaveChangesAsync();
            }        
        }
    }
}
