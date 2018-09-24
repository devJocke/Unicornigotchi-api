using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnicornigotchiApi.DataModel {
    public partial class mobileRemoteDbContext : DbContext {
        public mobileRemoteDbContext() {
        }

        public mobileRemoteDbContext(DbContextOptions<mobileRemoteDbContext> options)
            : base(options) {
        }

        public DbSet<Blueprints> Blueprints { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Care> Care { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Play> Play { get; set; }
        public DbSet<Toilet> Toilet { get; set; }
        public DbSet<Unicorn> Unicorn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UnicornDbContext"].ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Unicorn>(entity => {
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


            });

            modelBuilder.Entity<Care>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");
            });

            modelBuilder.Entity<Discipline>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Angry)
                   .HasColumnName("angry")
                  .HasDefaultValueSql("('false')");
            });



            modelBuilder.Entity<Blueprints>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FishingShack).HasColumnName("fishingShack");

                entity.Property(e => e.Running).HasColumnName("running");
            });


            modelBuilder.Entity<Farm>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlueprintsId).HasColumnName("blueprintsId");

                entity.HasOne(d => d.Blueprints)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.BlueprintsId)
                    .HasConstraintName("blueprints_fk");
            });

            modelBuilder.Entity<Play>(entity => {

                entity.Property(e => e.Football)
                    .IsRequired()
                    .HasColumnName("football")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Hockey)
                    .IsRequired()
                    .HasColumnName("hockey")
                    .HasDefaultValueSql("('false')");
            });

            modelBuilder.Entity<Toilet>(entity => {

                entity.Property(e => e.Flush)
                    .HasColumnName("flush")
                    .HasDefaultValueSql("('false')");
            });
            modelBuilder.HasSequence("hibernate_sequence");
        }
    }
}
