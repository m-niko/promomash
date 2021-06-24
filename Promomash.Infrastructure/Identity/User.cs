using Microsoft.AspNetCore.Identity;

namespace Promomash.Infrastructure.Identity
{
    public sealed class User : IdentityUser
    {
        private User(){}
        public User(string login, Location location, bool isAgreeToWorkForFood)
        {
            UserName = login;
            Email = login;
            Location = location;
            IsAgreeToWorkForFood = isAgreeToWorkForFood;
        }
        public Location Location { get; private set; }
        public bool IsAgreeToWorkForFood { get; private set; }
    }
}