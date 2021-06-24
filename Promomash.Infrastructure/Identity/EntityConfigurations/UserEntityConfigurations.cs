using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Promomash.Infrastructure.Identity.EntityConfigurations
{
    public class UserEntityConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(u => u.Location, navigationBuilder =>
            {
                navigationBuilder.Property(p => p.CountryId).IsRequired();
                navigationBuilder.Property(p => p.ProvinceId).IsRequired();
            });
        }
    }
}