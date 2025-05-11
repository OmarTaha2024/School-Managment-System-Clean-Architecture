using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Results;
using SchoolManagment.Service.Abstracts;
using SchoolManagment.Service.Services;
using System.Collections.Concurrent;

namespace SchoolManagment.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<ConcurrentDictionary<string, RefreshToken>>();

            return services;
        }
    }
}
