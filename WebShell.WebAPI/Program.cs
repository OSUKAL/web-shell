using Microsoft.EntityFrameworkCore;
using WebShell.Application.Middlewares.Mapper;
using WebShell.Application.Services;
using WebShell.Domain.Models;
using WebShell.Infrastructure.Data;
using WebShell.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(IEnumerable<CommandGetProfile>),
    typeof(CommandPostProfile));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICommandRepository<CommandModel>, CommandRepository>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<ICommandService, CommandService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();