var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This line registers all controllers with the dependency injection container.
builder.Services.AddControllers();

// Add services for API documentation (Swagger/OpenAPI).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // These lines are for enabling Swagger UI to test the API.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); // This line is crucial for enabling authorization in your app.

// This line maps the routes from all your controllers.
app.MapControllers();

app.Run();
