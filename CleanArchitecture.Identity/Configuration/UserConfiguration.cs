using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "cd31b6b6-819f-4d49-b5fb-52bb25d5e990",
                    Email = "rubsanchez@outlook.es",
                    NormalizedEmail = "rubsanchez@outlook.es",
                    Name = "Rubén",
                    Surname = "Sánchez",
                    UserName = "rubsanchez",
                    NormalizedUserName = "rubsanchez",
                    PasswordHash = hasher.HashPassword(null, "RubSanchez2023&"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "13cbab57-63dd-4693-958b-c49f8ecd51f5",
                    Email = "bvillora@outlook.es",
                    NormalizedEmail = "bvillora@outlook.es",
                    Name = "Borja",
                    Surname = "Villora",
                    UserName = "bvillora",
                    NormalizedUserName = "bvillora",
                    PasswordHash = hasher.HashPassword(null, "BVillora2023&"),
                    EmailConfirmed = true
                }
           );
        }
    }
}
