using FoodEstablishment.Domain.Entities;
using FoodEstablishment.Infrastructure.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace FoodEstablishment.Infrastructure.Database
{
    public class FoodEstablishmentDbContext : DbContext
    {
        public const string Schema = "ms_establishment";
        // todo: move this to ordering service
        public const string OrderingSchema = "ms_ordering";

        public FoodEstablishmentDbContext(DbContextOptions<FoodEstablishmentDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<FoodEstablishmentEntity> FoodEstablishments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLog> OrderLogs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foodEstTableBuider = modelBuilder.Entity<FoodEstablishmentEntity>().ToTable("FoodEstablishments", Schema);
            foodEstTableBuider
                .Property(p => p.EntityVersion)
                .HasColumnName("RowVersion")
                .IsConcurrencyToken();
            foodEstTableBuider
                .Property(p => p.Latitude)
                .HasColumnType("decimal(18,15)");
            foodEstTableBuider
                .Property(p => p.Longitude)
                .HasColumnType("decimal(18,15)");

            var orderTableBuilder = modelBuilder.Entity<Order>().ToTable("Orders", OrderingSchema);
            modelBuilder.HasSequence<long>("OrderIdSeq").IncrementsBy(5);
            orderTableBuilder
                .Property(p => p.Id)
                .UseHiLo("OrderIdSeq", OrderingSchema);
            orderTableBuilder
                .Property(p => p.EntityVersion)
                .HasColumnName("RowVersion")
                .IsConcurrencyToken();
            orderTableBuilder
                .Property(p => p.FromLatitude)
                .HasColumnType("decimal(18,15)");
            orderTableBuilder
                .Property(p => p.FromLongitude)
                .HasColumnType("decimal(18,15)");
            orderTableBuilder
                .Property(p => p.ShippingLatitude)
                .HasColumnType("decimal(18,15)");
            orderTableBuilder
                .Property(p => p.ShippingLongitude)
                .HasColumnType("decimal(18,15)");
            orderTableBuilder
                .Property(p => p.TotalAmount)
                .HasColumnType("decimal(12, 0)");

            var orderLogTableBuilder = modelBuilder.Entity<OrderLog>().ToTable("OrderLogs", OrderingSchema);
            orderLogTableBuilder
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();
        }
    }
}
