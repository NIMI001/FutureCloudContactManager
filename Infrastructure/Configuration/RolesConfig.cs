using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutureCloudContactManager.Infrastructure.Configuration
{
    public class RolesConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "NewUser",
                    NormalizedName ="NEWUSER"
                },
                new IdentityRole
                {
                    Name ="SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
                );
        }
    }
}
