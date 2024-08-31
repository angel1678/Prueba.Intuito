using Prueba.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infrastructure
{
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        Task<IEnumerable<BookingEntity>> GetHorrorBookingsAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SeatAvailabilityDto>> GetSeatAvailabilityForTodayAsync();
    }
}
