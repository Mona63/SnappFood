using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SnappFood.API.Filters;
using SnappFood.Core;
using SnappFood.Core.Entities;
using SnappFood.Infrastructure;
using SnappFood.Infrastructure.UnitOfWork;
using SnappFood.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ValidateModelAttribute>();
builder.Services.AddDbContext<SalesDbContext>(options =>
                                      options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IReadOnlyRepository<Product>, CachedProductRepository>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProcurementService, ProcurementService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

app.Run();
