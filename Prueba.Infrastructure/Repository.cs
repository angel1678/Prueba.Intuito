﻿using Microsoft.EntityFrameworkCore;
using Prueba.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) { await _context.Set<T>().AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _context.Set<T>().Update(entity); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(T entity) { _context.Set<T>().Remove(entity); await _context.SaveChangesAsync(); }
        public async Task<IEnumerable<BookingEntity>> GetHorrorBookingsAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings
                .Include(b => b.Billboard)
                .ThenInclude(b => b.Movie)
                .Where(b => b.Billboard.Movie.Genre == MovieGenreEnum.HORROR
                            && b.Date >= startDate
                            && b.Date <= endDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<SeatAvailabilityDto>> GetSeatAvailabilityForTodayAsync()
        {
            var today = DateTime.Today;

            var availability = await _context.Seats
                .Include(s => s.Room)
                .GroupJoin(
                    _context.Bookings.Where(b => b.Date.Date == today),
                    seat => seat.Id,
                    booking => booking.SeatId,
                    (seat, bookings) => new
                    {
                        seat.Room.Name,
                        SeatNumber = seat.Number,
                        IsOccupied = bookings.Any()
                    })
                .GroupBy(s => s.Name)
                .Select(g => new SeatAvailabilityDto
                {
                    RoomName = g.Key,
                    AvailableSeats = g.Count(s => !s.IsOccupied),
                    OccupiedSeats = g.Count(s => s.IsOccupied)
                })
                .ToListAsync();

            return availability;
        }
        public async Task<IEnumerable<BookingEntity>> GetBookingsForBillboardAsync(int billboardId)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Where(b => b.BillboardId == billboardId)
                .ToListAsync();
        }
    }
}