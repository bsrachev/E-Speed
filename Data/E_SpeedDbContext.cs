using E_Speed.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Speed.Data
{
    public class E_SpeedDbContext : IdentityDbContext<User, IdentityRole<int>, int>

    {
        public E_SpeedDbContext(DbContextOptions<E_SpeedDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; init; }

        public DbSet<Office> Offices { get; init; }

        public DbSet<EmployeeOffice> EmployeeOffices { get; init; }

        //public DbSet<Client> Clients { get; init; }

        //public DbSet<DeliveryEmployee> DeliveryEmployees { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Shipment>()
                .HasOne(s => s.ProcessedByOfficeEmployee)
                .WithMany(e => e.ShipmentsProcessed)
                .HasForeignKey(s => s.ProcessedByOfficeEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Shipment>()
                .HasOne(s => s.AssignedToDeliveryEmployee)
                .WithMany(e => e.ShipmentsAssigned)
                .HasForeignKey(s => s.AssignedToDeliveryEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder
                .Entity<User>()
                .HasOne(e => e.Office)
                .WithMany(o => o.OfficeEmployees)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);*/

            base.OnModelCreating(builder);
        }
    }
}