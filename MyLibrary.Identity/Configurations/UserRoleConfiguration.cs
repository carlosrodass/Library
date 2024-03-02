using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyLibrary.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                new IdentityUserRole<string>
                {
                    //Admin
                    RoleId = "f2b29f6c-8d2e-45a6-9d8c-3f54fe34913d",
                    UserId = "a7e1c3d0-9b25-4788-82f3-2c6d59a5d18d"
                },
                new IdentityUserRole<string>
                {
                    //User
                    RoleId = "5ce79a81-4a6f-4c88-bf7a-4b1dd2f273fb",
                    UserId = "6f4e2f7b-150d-43af-8d8b-1e5e9962c0fd"
                }


                );
        }
    }
}
