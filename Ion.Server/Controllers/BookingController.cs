using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.Booking;
using Ion.Server.RequestEntities.Bookings;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService bookingService, IMapper mapper) : Controller
{
    [HttpGet("{bookingId:int}", Name = nameof(GetBookingById))]
    public ActionResult<BookingToGet> GetBookingById(int bookingId)
    {
        var bookingViewModel = bookingService.GetById(bookingId);
        if (bookingViewModel is null)
            return NotFound();
        var bookingToGet = mapper.Map<BookingToGet>(bookingViewModel);
        
        return Ok(bookingToGet);
    }
    
    [HttpGet(Name = nameof(GetAllBookings))]
    public ActionResult<IEnumerable<BookingToGet>> GetAllBookings()
    {
        var bookingViewModels = bookingService.GetAll();
        
        return Ok(bookingViewModels);
    }
    
    [HttpPost(Name = nameof(CreateBooking))]
    public async Task<IActionResult> CreateBooking([FromBody] BookingToPost bookingToPost)
    {
        if (bookingToPost is null) 
            return BadRequest("Booking is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var bookingViewModel = mapper.Map<BookingViewModel>(bookingToPost);
        var createdBooking = await bookingService.AddAsync(bookingViewModel);
        
        return CreatedAtRoute(nameof(GetBookingById), new {bookingId = createdBooking.Id}, createdBooking.Id);
    }

    [HttpPatch("{bookingId:int}", Name = nameof(UpdateBooking))]
    public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] BookingToPatch bookingToPatch)
    {
        var bookingViewModel = mapper.Map<BookingViewModel>(bookingToPatch);
        bookingViewModel.Id = bookingId;
        await bookingService.UpdateAsync(bookingViewModel);
        
        return Ok();
    }

    [HttpDelete("{bookingId:int}", Name = nameof(DeleteBooking))]
    public async Task<IActionResult> DeleteBooking(int bookingId)
    {
        await bookingService.DeleteAsync(new BookingViewModel {Id = bookingId});
        
        return Ok();
    }
}