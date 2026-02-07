using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarGallery.Infrastructure.Repositories;
using CarGallery.Domain.Entities;

[Authorize]
[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
    private readonly CarRepository _carRepo;

    public CarsController(CarRepository carRepo)
    {
        _carRepo = carRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _carRepo.GetAllAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCar([FromBody] Car car)
    {
        await _carRepo.AddAsync(car);
        return Ok(car);
    }
}
