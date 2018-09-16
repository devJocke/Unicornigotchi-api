using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnicornigotchiApi.DataModel {
    public partial class mobileRemoteDbContext : DbContext {
        public mobileRemoteDbContext() {
        }

        public mobileRemoteDbContext(DbContextOptions<mobileRemoteDbContext> options)
            : base(options) {
        }

        public virtual DbSet<Blueprints> Blueprints { get; set; }
        public virtual DbSet<Care> Care { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<Play> Play { get; set; }
        public virtual DbSet<Toilet> Toilet { get; set; }
        public virtual DbSet<Unicorn> Unicorn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UnicornDbContext"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Blueprints>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FishingShack).HasColumnName("fishingShack");

                entity.Property(e => e.Running).HasColumnName("running");
            });

            modelBuilder.Entity<Care>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");

                entity.Property(e => e.PlayId).HasColumnName("playId");

                entity.Property(e => e.ToiletId).HasColumnName("toiletId");

                //entity.HasOne(d => d.Discipline)
                //    .WithMany(p => p.Care)
                //    .HasForeignKey(d => d.DisciplineId)
                //    .HasConstraintName("FK_Care_Discipline");

                //entity.HasOne(d => d.Play)
                //    .WithMany(p => p.Care)
                //    .HasForeignKey(d => d.PlayId)
                //    .HasConstraintName("FK_Care_Play");

                //entity.HasOne(d => d.Toilet)
                //    .WithMany(p => p.Care)
                //    .HasForeignKey(d => d.ToiletId)
                //    .HasConstraintName("FK_Care_Toilet");
            });

            modelBuilder.Entity<Discipline>(entity => {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Angry)
                    .HasColumnName("angry")
                    .HasDefaultValueSql("('false')");
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
                entity.Property(e => e.Id).HasColumnName("id");

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
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Flush)
                    .HasColumnName("flush")
                    .HasDefaultValueSql("('false')");
            });

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

                //entity.HasOne(d => d.Care)
                //    .WithMany(p => p.Unicorn)
                //    .HasForeignKey(d => d.CareId)
                //    .HasConstraintName("FK_Unicorn_Care");


            });

            modelBuilder.HasSequence("hibernate_sequence");
        }
    }
}
