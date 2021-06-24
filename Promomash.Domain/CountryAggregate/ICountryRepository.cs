using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Promomash.Domain.CountryAggregate
{
    public interface ICountryRepository
    {
        Task<Country> GetByIdAsync(int countryId, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task AddAsync(Country country, CancellationToken cancellationToken = default(CancellationToken));
        Task RemoveAsync(Country country, CancellationToken cancellationToken = default(CancellationToken));
    }
}