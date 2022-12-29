using CQRSApi.Models;
using CQRSApi.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
 builder.Services.AddDbContext<UserDetailsContext>(options =>
         options.UseSqlServer("data source=LAPTOP-HDDS2EQ6;initial catalog=model;User ID=home; Password = Home123?; TrustServerCertificate=True"));
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepo, UserRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

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
app.UseCors("AllowAnyCorsPolicy");

app.Run();

 