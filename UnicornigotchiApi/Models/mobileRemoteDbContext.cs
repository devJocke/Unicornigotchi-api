using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnicornigotchiApi.Models
{
    public partial class mobileRemoteDbContext : DbContext
    {
        public mobileRemoteDbContext()
        {
        }

        public mobileRemoteDbContext(DbContextOptions<mobileRemoteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blueprints> Blueprints { get; set; }
        public virtual DbSet<Care> Care { get; set; }
        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<Unicorn> Unicorn { get; set; }

        // Unable to generate entity type for table 'dbo.Discipline'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Toilet'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Play'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tcp:85.226.127.160;Initial Catalog=mobileRemoteDb;Persist Security Info=True;User ID=JockesSQLserver;Password=hx3pDa!-W");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blueprints>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FishingShack).HasColumnName("fishingShack");

                entity.Property(e => e.Running).HasColumnName("running");
            });

            modelBuilder.Entity<Care>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlueprintsId).HasColumnName("blueprintsId");

                entity.HasOne(d => d.Blueprints)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.BlueprintsId)
                    .HasConstraintName("blueprints_fk");
            });

            modelBuilder.Entity<Unicorn>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CareId).HasColumnName("careId");

                entity.Property(e => e.FarmId).HasColumnName("farmId");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdName)
                    .HasColumnName("thirdName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Care)
                    .WithMany(p => p.Unicorn)
                    .HasForeignKey(d => d.CareId)
                    .HasConstraintName("FK_Unicorn_Care");
            });

            modelBuilder.HasSequence("hibernate_sequence");
        }
    }
}
