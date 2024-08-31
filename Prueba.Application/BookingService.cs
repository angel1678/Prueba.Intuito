using Prueba.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Application
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<BookingEntity> _bookingRepository;
        private readonly IRepository<SeatEntity> _seatRepository;
        private readonly IRepository<BillboardEntity> _billboardRepository;
        public BookingService(IRepository<BookingEntity> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public BookingService(IRepository<BookingEntity> bookingRepository,
                              IRepository<SeatEntity> seatRepository,
                              IRepository<BillboardEntity> billboardRepository)
        {
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
            _billboardRepository = billboardRepository;
        }

        public async Task DisableSeatAndCancelBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null) throw new Exception("Reserva no encontrada.");

            booking.Status = false; 
            var seat = await _seatRepository.GetByIdAsync(booking.SeatId);
            seat.Status = false; 

            await _seatRepository.UpdateAsync(seat);
        }
        public async Task CancelBillboardAndReservations(int billboardId)
        {
            var billboard = await _billboardRepository.GetByIdAsync(billboardId);
            if (billboard == null)
                throw new Exception("Cartelera no encontrada.");

            if (billboard.Date < DateTime.Today)
                throw new CustomAttributeFormatException("No se puede cancelar funciones de la cartelera con fecha anterior a la actual.");

            var bookingsForBillboard = await _bookingRepository.GetBookingsForBillboardAsync(billboardId);

            foreach (var booking in bookingsForBillboard)
            {
                booking.Status = false; 
                await _bookingRepository.UpdateAsync(booking); 
                var seat = await _seatRepository.GetByIdAsync(booking.SeatId);
                if (seat != null)
                {
                    seat.Status = true; 
                    await _seatRepository.UpdateAsync(seat); 
                }
            }

            var customers = bookingsForBillboard.Select(b => b.Customer).Distinct();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Cliente afectado: {customer.Name} {customer.Lastname}");
            }
        }
    }
}
