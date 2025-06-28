using CleanArch.StarterKit.Application.Behaviors;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Persistance.Context;
using CleanArch.StarterKit.Persistance.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IExampleService,ExampleService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
