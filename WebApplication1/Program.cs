using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication1.Data;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Define a CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.log",rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddDbContext<LinktreeDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("LinktreeConnection"));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
