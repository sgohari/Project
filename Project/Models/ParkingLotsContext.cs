using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Models
{
    public partial class ParkingLotsContext : DbContext
    {
        public ParkingLotsContext()
        {
        }

        public ParkingLotsContext(DbContextOptions<ParkingLotsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParkingLot> ParkingLot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sqlserver.cogpggmozdc7.us-east-1.rds.amazonaws.com,1433;database=ParkingLots;User ID=nacer;Password=amin2005;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.HasKey(e => e.LotId);

                entity.Property(e => e.LotId)
                    .HasColumnName("LotID")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.LotCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LotDailyRate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.LotHourlyRate).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.LotMonthlyRate).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.LotName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LotStreetName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LotWeeklyRate).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LotYearlyRate).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.SpotId)
                    .IsRequired()
                    .HasColumnName("SpotID")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });
        }
    }
}
