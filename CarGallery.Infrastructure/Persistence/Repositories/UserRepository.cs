using CarGallery.Domain.Entities;
using CarGallery.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarGallery.Infrastructure.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
}
