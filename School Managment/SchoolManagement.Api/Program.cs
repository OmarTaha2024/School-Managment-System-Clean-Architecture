using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagment.Core;
using SchoolManagment.Core.MiddleWare;
using SchoolManagment.Infrustructure;
using SchoolManagment.Infrustructure.Data;
using SchoolManagment.Service;
using System.Globalization;
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

#region Localization
builder.Services.AddLocalization(opt =>
    {
        opt.ResourcesPath = "";
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
    {
        List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
        };

        options.DefaultRequestCulture = new RequestCulture("ar-EG");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });

#endregion

#region Allow Cors
var Cors = "_Cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
# region Localization MiddleWare
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors(Cors);
app.UseAuthorization();

app.MapControllers();

app.Run();
