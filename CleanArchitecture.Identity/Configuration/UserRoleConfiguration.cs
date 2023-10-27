using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "defffecd-2f7d-44d5-9f16-5fc671ae4f73",
                    UserId = "cd31b6b6-819f-4d49-b5fb-52bb25d5e990"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2df4ebdb-45e8-4fcb-a71e-692711068fed",
                    UserId = "13cbab57-63dd-4693-958b-c49f8ecd51f5"
                }
            );

        }
    }
}
