using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Prueba.Application;
using Prueba.Domain;
using Prueba.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        // Especifica los protocolos TLS permitidos
        httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 |
                                      System.Security.Authentication.SslProtocols.Tls13;
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Registro de repositorios
builder.Services.AddScoped<IRepository<BookingEntity>, BookingRepository>();
builder.Services.AddScoped<IRepository<SeatEntity>, Repository<SeatEntity>>();
builder.Services.AddScoped<IRepository<BillboardEntity>, Repository<BillboardEntity>>();

// Registro de servicios
builder.Services.AddScoped<IBookingService, BookingService>();

// Otras configuraciones
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
