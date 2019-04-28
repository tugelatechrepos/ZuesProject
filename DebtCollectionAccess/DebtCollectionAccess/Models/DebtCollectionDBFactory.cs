using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Models
{
    public class DebtCollectionDBFactory
    {
        public static TenantDebtCollectionDbContext GetDBContext(int TenantId)
        {
            var connection = $"Host=localhost;Database=DebtCollection_Copy;Username=postgres;Password=abcd@1234";
            return new TenantDebtCollectionDbContext(TenantId,connection);
        }
    }

    public class TenantDebtCollectionDbContext : DbContext
    {
        private int _TenantId;
        private string _Connection;

        public TenantDebtCollectionDbContext(int tenantId, string connection)
        {
            _TenantId = tenantId;
            _Connection = connection;           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_Connection);
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
    }
}
