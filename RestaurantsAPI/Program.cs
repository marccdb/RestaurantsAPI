using Microsoft.EntityFrameworkCore;
using Restaurants.API.Services;
using Restaurants.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<RestaurantsContext>(options =>
//     options.UseMongoDB(builder.Configuration.GetConnectionString("mongodbConnection"), "restaurants"));

builder.Services.AddDbContext<RestaurantsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserverConnection")));

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
