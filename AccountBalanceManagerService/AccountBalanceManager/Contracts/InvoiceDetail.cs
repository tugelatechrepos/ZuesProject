using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManager.Contracts
{
    public class InvoiceDetail
    {
        public int InvoiceId { get; set; }

        public DateTime GeneratedOn { get; set; }

        public int? PeriodId { get; set; }

        public ICollection<InvoiceLineItem> InvoiceLineItemList { get; set; }

        public ICollection<Expense> ExpenseList { get; set; }

        public ICollection<InvoiceServiceView> InvoiceServiceViewList { get; set; }
    }

    public class InvoiceLineItem
    {
        public int PeriodId { get; set; }
        public string Description { get; set; }
        public int NumberOfAccounts { get; set; }
        public ICollection<int> AccountIdList { get; set; }
        public decimal TotalOpeningBalance { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Yield { get; set; }
        public decimal CommissionPercentage { get; set; }
        public decimal Amount { get; set; }
    }

    public class Expense
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class InvoiceServiceView
    {
        public int PeriodId { get; set; }
        public string Description { get; set; }
       
        public ICollection<ServiceDetail> ServiceDetailList { get; set; }

        public decimal TotalOpeningBalance { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Yield { get; set; }
        public decimal CommissionPercentage { get; set; }
        public decimal Amount { get; set; }
    }

    public class ServiceDetail
    {
        public long ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int NumberOfAccounts { get; set; }
        public ICollection<int> AccountIdList { get; set; }
        public decimal Amount { get; set; }
    }
}