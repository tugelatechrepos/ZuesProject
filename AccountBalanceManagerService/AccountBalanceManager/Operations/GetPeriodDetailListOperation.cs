using AccountBalanceManager.Contracts;
using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Operations
{
    public interface IGetPeriodDetailListOperation
    {
        GetPeriodDetailListResponse GetPeriodDetailList(GetPeriodDetailListRequest Request);
    }

    public class GetPeriodDetailListOperation : IGetPeriodDetailListOperation
    {
        #region Declarations

        private GetPeriodDetailListRequest _Request;
        private GetPeriodDetailListResponse _Response;
        private List<DebtCollectionAccess.AccountBalance> _AccountBalanceList;
        private ICollection<Period> _PeriodList;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public GetPeriodDetailListResponse GetPeriodDetailList(GetPeriodDetailListRequest Request)
        {
            _Request = Request;
            _Response = new GetPeriodDetailListResponse { ValidationResults = new ValidationResults(), PeriodDetailList = new List<PeriodDetail>() };

            assignPeriodList();
            assignAccountBalanceList();
            assignPeriodDetailList();

            return _Response;
        }

        private void assignPeriodList()
        {
            var response = DebtCollectionAccessProxy.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest { CompanyId = _Request.CompanyId });

            _PeriodList = response.PeriodList;
        }

        public void assignAccountBalanceList()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            _AccountBalanceList = new List<DebtCollectionAccess.AccountBalance>();
            var periodIdList = _PeriodList.Select(x => x.Id).ToList();

            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new DebtCollectionAccess.Contracts.GetAccountBalanceListRequest
            {
                PeriodIdList = periodIdList,
                CompanyId = _Request.CompanyId
            });


            _AccountBalanceList.AddRange(response.AccountBalanceList);

        }

        private void assignPeriodDetailList()
        {
            if (_AccountBalanceList == null || !_AccountBalanceList.Any()) return;

            foreach (var period in _PeriodList)
            {
                var accountBalanceList = _AccountBalanceList.Where(x => x.PeriodId == period.Id);

                if (accountBalanceList == null || !accountBalanceList.Any()) continue;

                var totalOpeningBalance = accountBalanceList.Sum(x => x.OpeningBalance);
                var targetYield = totalOpeningBalance * 0.04M;
                var totalPaid = accountBalanceList.Sum(x => x.Paid);
                var remainingBalance = totalOpeningBalance - totalPaid;
                var status = totalPaid >= targetYield;

                var periodDetail = new PeriodDetail
                {
                    PeriodId = period.Id,
                    Name = period.Name,
                    TotalOpeningBalance = totalOpeningBalance,
                    RemainingBalance = remainingBalance.Value,
                    TargetYield = targetYield,
                    TotalPaid = totalPaid.Value,
                    Readiness = status
                };

                _Response.PeriodDetailList.Add(periodDetail);
            }

        }
    }
}
