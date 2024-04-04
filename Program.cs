using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Repository.Implementations;
using GSBAppartement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository
builder.Services.AddScoped<IAppartementRepository, AppartementRepository>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
try
{
    context.Database.CanConnect();
    Console.WriteLine("Database connection successful.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting to database: {ex.Message}");
}

app.MapGet("/", () => "Hello World!");

// Get all appartements
app.MapGet("/appartements", async (IAppartementRepository repository) =>
{
    var appartements = await repository.GetAllAsync();
    return Results.Ok(appartements);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Other middleware and endpoint configuration...

app.Run();
