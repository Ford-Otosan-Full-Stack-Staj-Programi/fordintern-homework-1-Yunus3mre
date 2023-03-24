using HomeWork1.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWork1.web.Extension
{
    public static class StartupDbContextExtension
    {
        public static void AddDbContextDI(this IServiceCollection services,IConfiguration configuration)
        {
            var dbConfig = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfig));
        }
    }
}
