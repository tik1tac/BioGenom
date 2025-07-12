using Biogenom.Shared;

using Microsoft.EntityFrameworkCore;

namespace Identity.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection service, IConfiguration config)
        {
            var connstring = config["Connection:ConnectionString"];
            service.AddDbContext<ApplicationContext>(opt =>
                     opt.UseNpgsql(connectionString: connstring));
        }

        public static void ConfigureCORS(this IServiceCollection service)
        {
            service.AddCors(opt =>
            {
                opt.AddPolicy(name: "Biogenom", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }
        public static void ConfigureServices(this IServiceCollection service)
        {

        }
    }
}
