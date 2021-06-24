using Ardalis.GuardClauses;
using Promomash.Domain.SeedWork;

namespace Promomash.Domain.CountryAggregate
{
    public sealed class Province: Entity
    {
        private Province(){}
        
        public Province(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }
        public string Name { get; private set; }
    }
}