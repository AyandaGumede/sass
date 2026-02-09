using sass.Domain.Entities;

namespace sass.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task RegisterAsync(User user);

        Task<User?> GetUserByEmailAddressAsync(string emailAddress);
    }
}
