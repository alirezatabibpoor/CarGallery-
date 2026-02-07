using CarGallery.Domain.Entities;
using CarGallery.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarGallery.Infrastructure.Repositories;

public class CarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetAllAsync() => await _context.Cars.ToListAsync();
    public async Task<Car?> GetByIdAsync(int id) => await _context.Cars.FindAsync(id);
    public async Task AddAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }
}
