using GMAShop.Catalog.Services.AboutServices;
using GMAShop.Catalog.Services.BrandServices;
using GMAShop.Catalog.Services.CategoryServices;
using GMAShop.Catalog.Services.ContactServices;
using GMAShop.Catalog.Services.FeatureServices;
using GMAShop.Catalog.Services.FeatureSliderServices;
using GMAShop.Catalog.Services.OfferDiscountServices;
using GMAShop.Catalog.Services.ProductDetailServices;
using GMAShop.Catalog.Services.ProductImageServices;
using GMAShop.Catalog.Services.ProductServices;
using GMAShop.Catalog.Services.SpecialOfferServices;
using GMAShop.Catalog.Services.StatisticServices;
using GMAShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GMAShop.Catalog.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => // ******
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCatalog";
});

builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory
        (options => options.RegisterModule(new AutofacModule())));


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
app.UseAuthentication(); //***************
app.UseAuthorization();

app.MapControllers();

app.Run();