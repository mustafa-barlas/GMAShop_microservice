using System.IdentityModel.Tokens.Jwt;
using GMAShop.Basket.LoginServices;
using GMAShop.Basket.Services;
using GMAShop.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var require = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); // ********
JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Remove("sub");

// JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => // ******
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceBasket";
});

builder.Services.AddHttpContextAccessor(); // ****************
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
}); // ******************

builder.Services.AddControllers(opt => { opt.Filters.Add(new AuthorizeFilter(require)); }); // *************

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); //***************
app.UseAuthorization(); //***************

app.MapControllers();

app.Run();