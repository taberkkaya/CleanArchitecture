using CleanArch.StarterKit.Application.Behaviors;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Repositories;
using CleanArch.StarterKit.Persistance.Context;
using CleanArch.StarterKit.Persistance.Repositories;
using CleanArch.StarterKit.Persistance.Services;
using CleanArch.StarterKit.WebApi.Middleware;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IExampleService,ExampleService>();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());

builder.Services.AddScoped<IExampleRepository,ExampleRepository>();

builder.Services.AddAutoMapper(typeof(CleanArch.StarterKit.Persistance.AssemblyReference).Assembly);

var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CleanArch.StarterKit.Application.AssemblyReference).Assembly);
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(CleanArch.StarterKit.Application.AssemblyReference).Assembly);

builder.Services
    .AddControllers()
    .AddApplicationPart(CleanArch.StarterKit.Presentation.AssemblyReference.Assembly);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
