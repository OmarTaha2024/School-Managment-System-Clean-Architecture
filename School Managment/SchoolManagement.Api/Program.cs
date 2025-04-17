using Microsoft.EntityFrameworkCore;
using SchoolManagment.Core;
using SchoolManagment.Infrustructure;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Data;
using SchoolManagment.Infrustructure.Represatories;
using SchoolManagment.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Connection SQL
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#region Dependency injection
builder.Services.AddModuleInfrustructureDependencies().AddModuleServiceDependencies().AddModuleCoreDependencies();
#endregion
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
