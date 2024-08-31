using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba.Domain;

namespace Prueba.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<BillboardEntity> Billboards { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = xxx; database = PRUEBA; Trusted_Connection = true"); // Reemplaza con tu cadena de conexión
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(c => c.DocumentNumber)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
