using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.InfrustructureBases;
using SchoolManagment.Infrustructure.Represatories;

namespace SchoolManagment.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddModuleInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
