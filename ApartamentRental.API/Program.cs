using ApartamentRental.API.Controllers;
using ApartamentRental.Core.Services;
using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.ApartmentRental.db",
        sqlOptions => sqlOptions.MigrationsAssembly("ApartmentRental.Infrastructure")
    )
);

builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//builder.Services.AddScoped<IBaseEntityRepository, BaseEntityRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ILandlordRepository, LandlordRepository>();
//builder.Services.AddScoped<ILandLordService, LandLordService>();
//builder.Services.AddScoped<ControllererBase, ApartmentController>();
//builder.Services.AddScoped<ControllerBase, LandLordController>();
builder.Services.AddScoped<ILandLordService, LandLordService>();
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