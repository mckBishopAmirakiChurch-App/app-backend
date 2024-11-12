// Program.cs
using ChurchAppBibleAPI.Data;
using ChurchAppBibleAPI.Repositories;
using ChurchAppBibleAPI.Services;
using ChurchAppBibleAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server and retry logic
builder.Services.AddDbContext<BibleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            );
            // Add command timeout
            sqlOptions.CommandTimeout(30);
        });
});

// Register repositories and services for Dependency Injection
builder.Services.AddScoped<IBibleRepository, BibleRepository>();
builder.Services.AddScoped<IBibleService, BibleService>();

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

// Add error handling middleware
app.UseExceptionHandler("/error");

app.Run();