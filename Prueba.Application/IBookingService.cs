using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Application
{
    public interface IBookingService
    {
        Task DisableSeatAndCancelBooking(int bookingId);
        Task CancelBillboardAndReservations(int billboardId);
    }
}
