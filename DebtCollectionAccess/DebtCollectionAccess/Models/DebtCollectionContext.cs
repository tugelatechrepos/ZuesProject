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
        public virtual DbSet<Commission> Commission { get; set; }
        public virtual DbSet<CompanyDiscount> CompanyDiscount { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<PaymentHistoryPayload> PaymentHistoryPayload { get; set; }
        public virtual DbSet<PaymentHistoryPayloadPeriod> PaymentHistoryPayloadPeriod { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.Property(e => e.CommissionPercentage).HasColumnType("numeric(8,0)");

                entity.Property(e => e.HigherRange).HasColumnType("numeric(8,0)");

                entity.Property(e => e.LowerRange).HasColumnType("numeric(8,0)");
            });

            modelBuilder.Entity<CompanyDiscount>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("numeric(8,0)");
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

            modelBuilder.Entity<PaymentHistoryPayload>(entity =>
            {
                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnType("json");

                entity.HasOne(d => d.PaymentHistoryPayloadPeriod)
                    .WithMany(p => p.PaymentHistoryPayload)
                    .HasForeignKey(d => d.PaymentHistoryPayloadPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentHistoryPayloadPeriodId_PaymentHistoryPayloadPeriod");
            });

            modelBuilder.Entity<PaymentHistoryPayloadPeriod>(entity =>
            {
                entity.Property(e => e.RunDate).HasColumnType("date");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RunDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");
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
