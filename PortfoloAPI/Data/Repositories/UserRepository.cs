using PortfolioAPI.Data;
using PortfoloAPI.Data.Entitites;

namespace PortfoloAPI.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User? Authenticate(string username, string passsword)
        {
            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == passsword);

            return userToAuthenticate;
        }
    }
}
