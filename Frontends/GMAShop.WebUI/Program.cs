using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GMAShop.WebUI.Handlers;
using GMAShop.WebUI.Services.CatalogServices.About;
using GMAShop.WebUI.Services.CatalogServices.Brand;
using GMAShop.WebUI.Services.CatalogServices.Category;
using GMAShop.WebUI.Services.CatalogServices.Contact;
using GMAShop.WebUI.Services.CatalogServices.Feature;
using GMAShop.WebUI.Services.CatalogServices.FeatureSlider;
using GMAShop.WebUI.Services.CatalogServices.OfferDiscount;
using GMAShop.WebUI.Services.CatalogServices.Product;
using GMAShop.WebUI.Services.CatalogServices.ProductDetail;
using GMAShop.WebUI.Services.CatalogServices.ProductImage;
using GMAShop.WebUI.Services.CatalogServices.SpecialOffer;
using GMAShop.WebUI.Services.Concrete;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.UserIdentityServices;
using GMAShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(
    JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.LogoutPath = "/Login/LogOut/";
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "GMAShopJwt";
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "GMAShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();


var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddHttpClient<IUserService, UserService>(opt => { opt.BaseAddress = new Uri(values.IdentityServer); })
    .AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IUserIdentityService, UserIdentityService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServer);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


// builder.Services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Message.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IDiscountStatisticService, DiscountStatisticService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Discount.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
// {
//     opt.BaseAddress = new Uri(values.IdentityServerUrl);
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Basket.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IOrderOderingService, OrderOderingService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Order.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Order.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Discount.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Cargo.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Cargo.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Cargo.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//
// builder.Services.AddHttpClient<IMessageService, MessageService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Message.Path}");
// }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
// {
//     opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Comment.Path}");
// }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.Ocelot}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();