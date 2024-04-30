using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.Car;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(ICarService carService, IMapper mapper) : Controller
{
    [HttpGet("{carId:int}", Name = nameof(GetCarById))]
    public ActionResult<CarToGet> GetCarById(int carId)
    {
        var carViewModel = carService.GetById(carId);
        if (carViewModel is null)
            return NotFound();
        var carToGet = mapper.Map<CarToGet>(carViewModel);
        return Ok(carToGet);
    }
    
    [HttpGet(Name = nameof(GetAllCars))]
    public ActionResult<IEnumerable<CarToGet>> GetAllCars()
    {
        var carViewModels = carService.GetAll();
        return Ok(carViewModels);
    }
    
    [HttpPost(Name = nameof(CreateCar))]
    public async Task<IActionResult> CreateCar([FromBody] CarToPost carToPost)
    {
        if (carToPost is null) 
            return BadRequest("Car is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var carViewModel = mapper.Map<CarViewModel>(carToPost);
        var createdCar = await carService.AddAsync(carViewModel);
        return CreatedAtRoute(nameof(GetCarById), new {carID = createdCar.Id}, createdCar.Id);
    }

    [HttpPatch("{carId:int}", Name = nameof(UpdateCar))]
    public async Task<IActionResult> UpdateCar(int carId, [FromBody] CarToPatch carToPatch)
    {
        var carViewModel = mapper.Map<CarViewModel>(carToPatch);
        carViewModel.Id = carId;
        await carService.UpdateAsync(carViewModel);
        return Ok();
    }

    [HttpDelete("{carId:int}", Name = nameof(DeleteCar))]
    public async Task<IActionResult> DeleteCar(int carId)
    {
        await carService.DeleteAsync(new CarViewModel {Id = carId});
        return Ok();
    }
}