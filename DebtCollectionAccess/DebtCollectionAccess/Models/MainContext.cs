using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DebtCollectionAccess
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientType> ClientType { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddress { get; set; }
        public virtual DbSet<CompanyClient> CompanyClient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Main;Username=postgres;Password=abcd@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<CompanyAddress>(entity =>
            {
                entity.Property(e => e.AddressLine).HasColumnType("character varying");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyAddress)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyId_Company");
            });

            modelBuilder.Entity<CompanyClient>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CompanyClientClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientId_Company");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyClientCompany)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyId_Company");
            });
        }
    }
}
