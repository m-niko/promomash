
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Promomash.Domain.CountryAggregate;

namespace Promomash.Infrastructure.Identity
{
    public class CountryRepository : ICountryRepository
    {
        [NotNull] private readonly ApplicationIdentityDbContext _dbContext;

        public CountryRepository([NotNull] ApplicationIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Country> GetByIdAsync(int countryId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.Countries
                .Include(i => i.Provinces)
                .FirstAsync(c => c.Id == countryId, cancellationToken);
        }

        public Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.Countries.ToListAsync(cancellationToken);
        }
        
        public async Task AddAsync(Country country, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Countries.AddAsync(country, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Country country, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Remove(country);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}