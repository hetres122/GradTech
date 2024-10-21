using GradTech.DAL.DbAll.Entities;
using Microsoft.EntityFrameworkCore;


namespace GradTech.DAL.DbAll
{
    public class DalContext : DbContext
    {
        public DalContext(DbContextOptions<DalContext> options)
            : base(options)
        {
        }

        public DbSet<Unit> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AdditionalOption> AdditionalOptions { get; set; }
        public DbSet<ReservationAdditionalOption> ReservationAdditionalOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservationAdditionalOption>()
                .HasKey(ra => new { ra.ReservationId, ra.AdditionalOptionId });

            modelBuilder.Entity<ReservationAdditionalOption>()
                .HasOne(ra => ra.Reservation)
                .WithMany(r => r.ReservationAdditionalOptions)
                .HasForeignKey(ra => ra.ReservationId);

            modelBuilder.Entity<ReservationAdditionalOption>()
                .HasOne(ra => ra.AdditionalOption)
                .WithMany(a => a.ReservationAdditionalOptions)
                .HasForeignKey(ra => ra.AdditionalOptionId);
        }
    }
}