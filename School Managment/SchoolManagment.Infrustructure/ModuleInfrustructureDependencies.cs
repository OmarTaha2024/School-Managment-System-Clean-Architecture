using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Represatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddModuleInfrustructureDependencies(this IServiceCollection services )
        {
            services.AddTransient<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
