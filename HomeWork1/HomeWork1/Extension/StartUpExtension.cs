using FluentValidation;
using HomeWork1.Data;

namespace HomeWork1.web.Extension
{
    public static class StartUpExtension
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidator<Staff>, StaffValidator>();
        }
    }
}
