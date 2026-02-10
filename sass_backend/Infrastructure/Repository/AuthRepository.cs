using sass.Domain.Interfaces;
using sass.Infrastructure.Data;
using sass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace sass.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(User register)
        {
            await _context.Users.AddAsync(register);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAddressAsync(string emailAddress)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u=> u.EmailAddress == emailAddress);
            if(existingUser != null)
                return existingUser;
            return null;
        }
    }
}