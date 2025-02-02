using Sober.Application.Common.Interfaces.Persistence;
using Sober.Domain.Entities.User;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PortfolioDbContext _context;

        private static readonly List<User> _users = new();

        public UserRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _users.Add(user);
            _context.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
