using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IPaymentHistoryPayloadPeriodDao
    {
        ValidationResults PersistPaymentHistoryPayloadPeriod(PaymentHistoryPayloadPeriod PaymentHistoryPayloadPeriod,ValidationResults ValidationResults = null);

        PaymentHistoryPayloadPeriod GetPaymentHistoryPayloadPeriod(DateTime PeriodDate, int CompanyId, int ClientId, ValidationResults ValidationResults);
    }

    public class PaymentHistoryPayloadPeriodDao : IPaymentHistoryPayloadPeriodDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ValidationResults PersistPaymentHistoryPayloadPeriod(PaymentHistoryPayloadPeriod PaymentHistoryPayloadPeriod,ValidationResults ValidationResults = null)
        {
            ValidationResults = new ValidationResults();
            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.PaymentHistoryPayloadPeriod.Add(PaymentHistoryPayloadPeriod);
                    _DbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ValidationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }

            return ValidationResults;
        }

        public PaymentHistoryPayloadPeriod GetPaymentHistoryPayloadPeriod(DateTime PeriodDate, int CompanyId,int ClientId,ValidationResults ValidationResults)
        {
            ValidationResults = new ValidationResults();
            PaymentHistoryPayloadPeriod paymentHistoryPayloadPeriod = null;
            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.PaymentHistoryPayloadPeriod.AsQueryable();
                    paymentHistoryPayloadPeriod = query.FirstOrDefault(x => x.RunDate == PeriodDate && x.CompanyId == CompanyId && x.ClientId == ClientId);
                }
            }
            catch (Exception ex)
            {
                ValidationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }

            return paymentHistoryPayloadPeriod;
        }
    }
}
