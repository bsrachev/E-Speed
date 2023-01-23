using E_Speed.Data;
using E_Speed.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static E_Speed.Data.DataConstants.Roles;

namespace E_Speed.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            MigrateDatabase(serviceProvider);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<E_SpeedDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var officeEmployeeRole = new IdentityRole { Name = OfficeEmployeeRoleName };

                    await roleManager.CreateAsync(officeEmployeeRole);

                    var deliveryEmployeeRole = new IdentityRole { Name = DeliveryEmployeeRoleName };

                    await roleManager.CreateAsync(deliveryEmployeeRole);

                    var adminRole = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(adminRole);

                    var user = new User
                    {
                        Email = "admin@bankorders.com",
                        UserName = "Admin",
                        FullName = "E-Speed Admin"
                    };

                    await userManager.CreateAsync(user, "theadmin");

                    await userManager.AddToRoleAsync(user, adminRole.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
