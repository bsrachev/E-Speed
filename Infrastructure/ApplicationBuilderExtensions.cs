using E_Speed.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Speed.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<E_SpeedDbContext>();

            data.Database.Migrate();

            return app;
        }
    }
}
