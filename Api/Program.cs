using Api.Data;
using Api.Models;
using Api.Repos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<Category>());
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<PostTag>());
});
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<PostRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();