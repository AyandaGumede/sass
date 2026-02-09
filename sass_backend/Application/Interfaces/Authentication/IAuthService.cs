using sass.Domain.Entities;
using sass.Application.DTOs.Authentication;

namespace sass.Application.Interfaces.Authentication
{
    public interface IAuthService
    {
        Task<AuthResultDTO> RegisterAsync(RegisterDTO register);
        Task<AuthResultDTO> LoginAsync(LoginDTO login);
    }

}
