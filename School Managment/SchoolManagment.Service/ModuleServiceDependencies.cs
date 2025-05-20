using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Results;
using SchoolManagment.Service.Abstracts;
using SchoolManagment.Service.AuthServices.Implementations;
using SchoolManagment.Service.AuthServices.Interfaces;
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
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddSingleton<ConcurrentDictionary<string, RefreshToken>>();

            return services;
        }
    }
}
