using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Service.Abstracts;
using SchoolManagment.Service.Services;
using System.Reflection;

namespace SchoolManagment.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddModuleCoreDependencies(this IServiceCollection services)
        {
            // Configuration of Mediator 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
