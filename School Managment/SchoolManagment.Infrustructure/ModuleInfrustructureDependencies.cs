using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Abstract.Procedures;
using SchoolManagment.Infrustructure.Abstract.Views;
using SchoolManagment.Infrustructure.InfrustructureBases;
using SchoolManagment.Infrustructure.Represatories;
using SchoolManagment.Infrustructure.Represatories.Procedures;
using SchoolManagment.Infrustructure.Represatories.Views;

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
            services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepository>();
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
