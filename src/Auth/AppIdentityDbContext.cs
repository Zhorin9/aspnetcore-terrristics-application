using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auth
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region MySql max lenght field definitions  

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(85);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(85);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(85);
                entity.Property(m => m.EmailConfirmed).HasConversion(new BoolToZeroOneConverter<int>());
                entity.Property(m => m.PhoneNumberConfirmed).HasConversion(new BoolToZeroOneConverter<int>());
                entity.Property(m => m.TwoFactorEnabled).HasConversion(new BoolToZeroOneConverter<int>());
                entity.Property(m => m.LockoutEnabled).HasConversion(new BoolToZeroOneConverter<int>());
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(85);
                entity.Property(m => m.NormalizedName).HasMaxLength(85);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(85);
                entity.Property(m => m.ProviderKey).HasMaxLength(85);
                entity.Property(m => m.UserId).HasMaxLength(85);
            });
            
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(85);
                entity.Property(m => m.RoleId).HasMaxLength(85);
            });      
            
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(85);
                entity.Property(m => m.LoginProvider).HasMaxLength(85);
                entity.Property(m => m.Name).HasMaxLength(85);
            });  
            
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(85);
                entity.Property(m => m.UserId).HasMaxLength(85);
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(85);
                entity.Property(m => m.RoleId).HasMaxLength(85);
            });
            #endregion
        }
    }
}
