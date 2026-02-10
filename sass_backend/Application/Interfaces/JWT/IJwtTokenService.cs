using sass.Domain.Entities;

namespace sass.Application.Interfaces.JWT
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
