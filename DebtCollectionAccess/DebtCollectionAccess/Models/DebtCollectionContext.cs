using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DebtCollectionAccess
{
    public partial class DebtCollectionContext : DbContext
    {
        public DebtCollectionContext()
        {
        }

        public DebtCollectionContext(DbContextOptions<DebtCollectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountAod> AccountAod { get; set; }
        public virtual DbSet<AccountBalance> AccountBalance { get; set; }
        public virtual DbSet<AccountBalanceStatus> AccountBalanceStatus { get; set; }
        public virtual DbSet<AccountInception> AccountInception { get; set; }
        public virtual DbSet<AccountOpeningBalance> AccountOpeningBalance { get; set; }
        public virtual DbSet<AccountOwner> AccountOwner { get; set; }
        public virtual DbSet<AgencyCompany> AgencyCompany { get; set; }
        public virtual DbSet<Commission> Commission { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyDiscount> CompanyDiscount { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=DebtCollection;Username=postgres;Password=abcd@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AccountAod>(entity =>
            {
                entity.ToTable("AccountAOD");

                entity.Property(e => e.Amount).HasColumnType("numeric(8,0)");
            });

            modelBuilder.Entity<AccountBalance>(entity =>
            {
                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(8,0)");

                entity.Property(e => e.Paid).HasColumnType("numeric(8,0)");

                entity.Property(e => e.PromisedAmount).HasColumnType("numeric(8,0)");

                entity.Property(e => e.RemainingBalance).HasColumnType("numeric(8,0)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AccountBalance)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyId_Company");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.AccountBalance)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_OwnerId_Users");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.AccountBalance)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_PeriodId_Period");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AccountBalance)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusId_AccountBalanceStatus");
            });

            modelBuilder.Entity<AccountBalanceStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AccountInception>(entity =>
            {
                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<AccountOpeningBalance>(entity =>
            {
                entity.Property(e => e.OpeningBalance).HasColumnType("numeric(8,0)");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.AccountOpeningBalance)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodId_Period");
            });

            modelBuilder.Entity<AccountOwner>(entity =>
            {
                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.AccountOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerId_Owner");
            });

            modelBuilder.Entity<AgencyCompany>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.AgencyCompanyAgency)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgencyId_Company");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.AgencyCompanyClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientId_Company");
            });

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.Property(e => e.CommissionPercentage).HasColumnType("numeric(8,0)");

                entity.Property(e => e.HigherRange).HasColumnType("numeric(8,0)");

                entity.Property(e => e.LowerRange).HasColumnType("numeric(8,0)");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("Address Line 2")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.PrimaryEmail)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Vatpercentage).HasColumnName("VATPercentage");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyId_CompanyType");
            });

            modelBuilder.Entity<CompanyDiscount>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("numeric(8,0)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyDiscount)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyId_Company");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnType("jsonb");

                entity.Property(e => e.GeneratedOn).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyId_Company");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_PeriodId_Period");
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(8,0)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentMode).HasColumnType("character varying");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_InvoiceId_Invoice");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceId_Service");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RunDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Period)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyId_Company");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.HasSequence("Invoice_Id_seq");

            modelBuilder.HasSequence("PaymentHistory_Id_seq");

            modelBuilder.HasSequence("Service_Id_seq");

            modelBuilder.HasSequence("Users_Id_seq");
        }
    }
}
