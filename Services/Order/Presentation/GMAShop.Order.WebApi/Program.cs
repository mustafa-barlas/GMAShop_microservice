using GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using GMAShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Application.Services;
using GMAShop.Order.Persistence.Contexts;
using GMAShop.Order.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

#region

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => // ******
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceOrder";
});

builder.Services.AddScoped<OrderContext>(); 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressHandler>();
builder.Services.AddScoped<UpdateAddressHandler>();
builder.Services.AddScoped<RemoveAddressHandler>();

builder.Services.AddScoped<GetOrderDetailCommandHandler>();
builder.Services.AddScoped<GetOrderDetailByIdCommandHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailQueryHandler>();
builder.Services.AddScoped<RemoveOrderDetailQueryHandler>();


#endregion

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();