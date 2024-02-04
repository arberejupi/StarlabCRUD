using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using StarlabsCRUD.Data;
using StarlabsCRUD.Repositories;
using StarlabsCRUD.Services;
using AutoMapper;
using StarlabsCRUD.Model;
using StarlabsCRUD.MappingProfile;
using FluentValidation.AspNetCore;
using StarlabsCRUD.Validator;
using StarlabsCRUD.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<DataContext>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
builder.Services.AddTransient<IValidator<PersonDto>, PersonDtoValidator>();

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

// Example AutoMapper configuration in Startup.cs or a dedicated configuration file
builder.Services.AddAutoMapper(typeof(YourMappingProfile));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IValidator<PersonDto>, PersonDtoValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
