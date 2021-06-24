using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Promomash.Domain.CountryAggregate;
using Promomash.Infrastructure.Identity.EntityConfigurations;

namespace Promomash.Infrastructure.Identity
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User>
    {
        public DbSet<Country> Countries { get; set; }
        
        public ApplicationIdentityDbContext(DbContextOptions options) : base(options){ } 
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserEntityConfigurations());
        }
    }
}