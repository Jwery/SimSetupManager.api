using Microsoft.EntityFrameworkCore;
using SimSetupManager.Api.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Enregistrement du DbContext avec sa chaîne de connexion
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Configutation du CORS pour permettre les requêtes depuis le frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Le port par défaut d'Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // La nouvelle interface visuelle remplaçant Swagger
}

app.UseCors("AllowAngularDev"); // <-- Doit être placé AVANT UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();