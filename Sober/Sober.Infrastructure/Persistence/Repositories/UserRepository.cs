using Microsoft.AspNetCore.Identity;
using Authentication.Application.Common.Interfaces.Persistence;
using Authentication.Domain.Entities.User;
using Authentication.Infrastructure.Persistence;

namespace Authentication.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PortfolioDbContext _context;

    private static readonly List<User> _users = new();
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(PortfolioDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
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

    public async Task<bool> VerifyPasswordAsync(User user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}
