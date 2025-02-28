using ShinovaIrinaKt_31_22.Services;

namespace ShinovaIrinaKt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<TeacherService, TeacherServiceImpl>();
            services.AddScoped<SubjectService, SubjectServiceImpl>();
            return services;
        }
    }
}
