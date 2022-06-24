using Microsoft.EntityFrameworkCore;
using ScrumManagement.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"));
});
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
