using Sober.Domain.Entities.User;

namespace Sober.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
        Task<bool> VerifyPasswordAsync(User user, string password);
    }
}
