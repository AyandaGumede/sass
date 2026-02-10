using sass.Domain.Entities;
using sass.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using sass.Application.Interfaces.JWT;
using sass.Application.DTOs.Authentication;
using sass.Application.Interfaces.Authentication;
using BCrypt.Net;

namespace sass.Application.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IAuthRepository authRepository, IJwtTokenService jwtTokenService)
        {
            _authRepository = authRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthResultDTO> RegisterAsync(RegisterDTO dto)
        {
            var user = await _authRepository.GetUserByEmailAddressAsync(dto.EmailAddress);
            if (user != null)
                return new AuthResultDTO
                {
                    Success = false,
                    Errors = new[] { "User already exist" }
                };

            var passwordHashed = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                EmailAddress = dto.EmailAddress,
                PasswordHash = passwordHashed,
            };
            await _authRepository.RegisterAsync(newUser);

            var token = _jwtTokenService.GenerateToken(newUser);

            return new AuthResultDTO
            {
                Success = true,
                Token = token
            };
        }

        public async Task<AuthResultDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _authRepository.GetUserByEmailAddressAsync(dto.EmailAddress);

            if (user == null)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Errors = new[] { "Invalid email or password" }
                };
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!validPassword)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Errors = new[] { "Invalid email or password" }
                };
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new AuthResultDTO
            {
                Success = true,
                Token = token
            };
        }
    }
}
