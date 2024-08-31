using Microsoft.AspNetCore.Mvc;
using Prueba.Application;
using System.Reflection;

namespace Prueba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillboardsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BillboardsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("cancel-billboard")]
        public async Task<IActionResult> CancelBillboard([FromBody] int billboardId)
        {
            try
            {
                await _bookingService.CancelBillboardAndReservations(billboardId);
                return Ok();
            }
            catch (CustomAttributeFormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
