using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.TripRecord;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripRecordController(ITripRecordService tripRecordService, IMapper mapper) : Controller
{
    [HttpGet("{tripRecordId:int}", Name = nameof(GetTripRecordById))]
    public ActionResult<TripRecordToGet> GetTripRecordById(int tripRecordId)
    {
        var tripRecordViewModel = tripRecordService.GetById(tripRecordId);
        if (tripRecordViewModel is null)
            return NotFound();
        var tripRecord = mapper.Map<TripRecordToGet>(tripRecordViewModel);
        return Ok(tripRecord);
    }

    [HttpGet]
    public ActionResult<IEnumerable<TripRecordToGet>> GetAllTripRecords()
    {
        var tripRecordViewModels = tripRecordService.GetAll().Select(mapper.Map<TripRecordToGet>);
        return Ok(tripRecordViewModels);
    }

    [HttpGet("GetByUserId/{userId:int}", Name = nameof(GetByUserId))]
    public ActionResult<IEnumerable<TripRecordToGet>> GetByUserId(int userId)
    {
        var tripRecordViewModels = tripRecordService.GetByUserId(userId);
        return Ok(tripRecordViewModels.Select(mapper.Map<TripRecordToGet>));
    }
    
    [HttpDelete("{tripRecordId:int}", Name = nameof(DeleteTripRecord))]
    public async Task<IActionResult> DeleteTripRecord(int tripRecordId)
    {
        await tripRecordService.DeleteAsync(new TripRecordViewModel {Id = tripRecordId});
        return Ok();
    }
}