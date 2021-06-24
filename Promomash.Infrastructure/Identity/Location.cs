namespace Promomash.Infrastructure.Identity
{
    public sealed class Location
    {
        public int CountryId { get; }
        public int ProvinceId { get; }

        private Location() { }

        public Location(int countryId, int provinceId)
        {
            CountryId = countryId;
            ProvinceId = provinceId;
        }
    }
}