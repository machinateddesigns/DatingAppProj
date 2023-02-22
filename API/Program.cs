using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);

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

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//these must come after cors, but before mapcontrollers
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
