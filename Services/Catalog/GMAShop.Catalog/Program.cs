using System.Reflection;
using GMAShop.Catalog.Services.CategoryServices;
using GMAShop.Catalog.Services.ProductDetailServices;
using GMAShop.Catalog.Services.ProductImageServices;
using GMAShop.Catalog.Services.ProductServices;
using GMAShop.Catalog.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
