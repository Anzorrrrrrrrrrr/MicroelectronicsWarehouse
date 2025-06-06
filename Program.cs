using MicroelectronicsWarehouse.Data;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Repositories;
using Microsoft.EntityFrameworkCore;
using MicroelectronicsWarehouse.Services;
using MicroelectronicsWarehouse.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();




var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Додає Swagger UI
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
