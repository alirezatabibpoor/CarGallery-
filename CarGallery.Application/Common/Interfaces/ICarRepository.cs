using CarGallery.Domain.Entities;
namespace CarGallery.Application.Common.Interfaces;
public interface ICarRepository
{
    Task AddAsync(Car car);
    Task<List<Car>> GetAllAsync();
}