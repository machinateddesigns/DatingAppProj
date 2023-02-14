using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // removed in tutorial
builder.Services.AddSwaggerGen(); // removed in tutorial

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // removed in tutorial
{ // removed in tutorial
    app.UseSwagger(); // removed in tutorial
    app.UseSwaggerUI(); // removed in tutorial
} // removed in tutorial

app.UseHttpsRedirection(); // removed in tutorial

app.UseAuthorization(); // removed in tutorial

app.MapControllers();

app.Run();
