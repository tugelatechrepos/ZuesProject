using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IPaymentHistoryPayloadDao
    {
        ValidationResults PersistPaymentHistoryPayloadList(ICollection<PaymentHistoryPayload> PaymentHistoryPayloadList, ValidationResults ValidationResults);

        ICollection<PaymentHistoryPayload> GetPaymentHistoryPayloadList(int PaymentHistoryPayloadPeriodId, int Skip, int Take);
    }

    public class PaymentHistoryPayloadDao : IPaymentHistoryPayloadDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ValidationResults PersistPaymentHistoryPayloadList(ICollection<PaymentHistoryPayload> PaymentHistoryPayloadList, ValidationResults ValidationResults)
        {            
            ValidationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.PaymentHistoryPayload.AddRange(PaymentHistoryPayloadList);
                    _DbContext.SaveChanges();
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

            return ValidationResults;
        }

        public ICollection<PaymentHistoryPayload> GetPaymentHistoryPayloadList(int PaymentHistoryPayloadPeriodId, int Skip, int Take)
        {
            ICollection<PaymentHistoryPayload> paymentHistoryPayloadList = null;
            var validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.PaymentHistoryPayload.AsQueryable();
                    query = query.Where(x => x.PaymentHistoryPayloadPeriodId == PaymentHistoryPayloadPeriodId);
                    query = query.Skip(Skip).Take(Take);
                    paymentHistoryPayloadList = query.ToList();
                }
            }
            catch (Exception ex)
            {
                validationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }

            return paymentHistoryPayloadList;
        }
    }
}
