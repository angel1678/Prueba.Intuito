using Microsoft.AspNetCore.Mvc;
using Prueba.Application;

namespace Prueba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public SeatsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("disable-seat")]
        public async Task<IActionResult> DisableSeat([FromBody] int bookingId)
        {
            await _bookingService.DisableSeatAndCancelBooking(bookingId);
            return Ok();
        }
    }
}
