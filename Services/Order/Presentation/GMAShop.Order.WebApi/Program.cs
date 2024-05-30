using GMAShop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;
using GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Application.Services;
using GMAShop.Order.Persistence.Contexts;
using GMAShop.Order.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => // ******
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceOrder";
});


// Add services to the container.

builder.Services.AddTransient<GetAddressQueryHandler>();
builder.Services.AddTransient<GetAddressByIdQueryHandler>();
builder.Services.AddTransient<CreateAddressHandler>();
builder.Services.AddTransient<UpdateAddressHandler>();
builder.Services.AddTransient<RemoveAddressHandler>();

builder.Services.AddTransient<GetOrderDetailCommandHandler>();
builder.Services.AddTransient<GetOrderDetailByIdCommandHandler>();
builder.Services.AddTransient<CreateOrderDetailCommandHandler>();
builder.Services.AddTransient<UpdateOrderDetailQueryHandler>();
builder.Services.AddTransient<RemoveOrderDetailQueryHandler>();
builder.Services.AddTransient<OrderContext>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

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