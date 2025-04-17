using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Represatories;
using SchoolManagment.Service.Abstracts;
using SchoolManagment.Service.Services;

namespace SchoolManagment.Service
{
    public static  class ModuleServiceDependencies
    {
        public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}
