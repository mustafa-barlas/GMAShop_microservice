var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();  // Ensure MVC Controllers are added
builder.Services.AddEndpointsApiExplorer(); // Enables API explorer for OpenAPI generation
builder.Services.AddSwaggerGen(); // Adds Swagger generation service

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development environment
    app.UseSwagger(); // Adds the Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); // Set the Swagger UI endpoint
        c.RoutePrefix = string.Empty; // Optional: set Swagger UI to be served at the root of the app
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers(); // Map your API controllers
app.Run();