using OLSoftwareApi.Models.Repository;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

// Add context
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});


// Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add Services
builder.Services.AddScoped<ILenguajesProgramacionRepository, LenguajesProgramacionRepository>();
builder.Services.AddScoped<IEstadosPruebaAspiranteRepository, EstadosPruebaAspiranteRepository>();
builder.Services.AddScoped<ITiposPruebasRepository, TiposPruebasRepository>();
builder.Services.AddScoped<INivelesConocimientoRepository, NivelesConocimientoRepository>();
builder.Services.AddScoped<IPreguntasRepository, PreguntasRepository>();
builder.Services.AddScoped<IPruebasRepository, PruebasRepository>();
builder.Services.AddScoped<IPruebasPreguntasRepository, PruebasPreguntasRepository>();
builder.Services.AddScoped<IAspirantesRepository, AspirantesRepository>();
builder.Services.AddScoped<IPruebaAspiranteRepository, PruebaAspiranteRepository>();
builder.Services.AddScoped<IRespuestaPruebaAspiranteRepository, RespuestaPruebaAspiranteRepository>();
builder.Services.AddScoped<IDetalleRepository, DetalleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
