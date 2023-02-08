using E_Speed.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Speed.Services.Users;
using E_Speed.Models.Shipments;
using E_Speed.Services.Shipments;

namespace E_Speed.Data
{
    public class E_SpeedDbContext : IdentityDbContext<User, IdentityRole<int>, int>

    {
        public E_SpeedDbContext(DbContextOptions<E_SpeedDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShipmentRequest> ShipmentRequests { get; init; }

        public DbSet<Shipment> Shipments { get; init; }

        public DbSet<Office> Offices { get; init; }

        public DbSet<EmployeeOffice> EmployeeOffices { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasSequence<int>("ShipmentTrackingNumber")
                              .StartsAt(10000001).IncrementsBy(1);

            builder.Entity<Shipment>()
               .Property(x => x.TrackingNumber)
               .HasDefaultValueSql("NEXT VALUE FOR ShipmentTrackingNumber");

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

            builder
                .Entity<Shipment>()
                .HasOne(s => s.Sender)
                .WithMany(e => e.PersonalShipments)
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder
                .Entity<User>()
                .HasOne(e => e.Office)
                .WithMany(o => o.OfficeEmployees)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);*/

            base.OnModelCreating(builder);
        }

        public DbSet<E_Speed.Services.Shipments.ShipmentServiceModel> ShipmentServiceModel { get; set; }
    }
}