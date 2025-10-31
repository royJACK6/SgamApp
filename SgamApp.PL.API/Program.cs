using Microsoft.EntityFrameworkCore;
using SgamApp.BLL.Interfaces;
using SgamApp.BLL.Services;
using SgamApp.DAL;
using SgamApp.DAL.Interfaces;
using SgamApp.DAL.Repositories;
using SgamApp.PL.API.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SgamAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'SgamAppDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

builder.Services.AddScoped<IGlossaryService, GlossaryService>();
builder.Services.AddScoped(typeof(IService<>), typeof(Service<,>));

builder.Services.AddScoped<IGlossaryRepository, GlossaryRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
