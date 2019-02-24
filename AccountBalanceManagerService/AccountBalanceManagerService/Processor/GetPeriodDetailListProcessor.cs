using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccountBalanceManagerService.Models;

namespace AccountBalanceManagerService.Processor
{
    public interface IGetPeriodDetailListProcessor
    {
        GetPeriodDetailListProcessorResponse GetPeriodDetailList(GetPeriodDetailListProcessorRequest Request);
    }

    public class GetPeriodDetailListProcessorRequest
    {
       
    }

    public class GetPeriodDetailListProcessorResponse
    {
        public ICollection<PeriodDetail> PeriodDetailList { get; set; }
    }

    public class GetPeriodDetailListProcessor : IGetPeriodDetailListProcessor
    {
        #region Declarations

        private GetPeriodDetailListProcessorRequest _Request;
        private GetPeriodDetailListProcessorResponse _Response;
        private List<AccountBalance> _AccountBalanceList;
        private ICollection<Period> _PeriodList;

        public IAccountBalanceProcessor AccountBalanceProcessor { get; set; }
        public IPeriodProcessor PeriodProcessor { get; set; }

        #endregion Declarations

        public GetPeriodDetailListProcessorResponse GetPeriodDetailList(GetPeriodDetailListProcessorRequest Request)
        {
            _Request = Request;
            _Response = new GetPeriodDetailListProcessorResponse { PeriodDetailList = new List<PeriodDetail>() };

            assignPeriodList();
            assignAccountBalanceList();
            assignPeriodDetailList();

            return _Response;
        }

        private void assignPeriodList()
        {
            var response = PeriodProcessor.GetPeriodList(new GetPeriodListRequest());

            _PeriodList = response.PeriodList;
        }

        public void assignAccountBalanceList()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            _AccountBalanceList = new List<AccountBalance>();
            var periodIdList = _PeriodList.Select(x => x.Id).ToList();

            var response = AccountBalanceProcessor.GetAccountBalanceList(new GetAccountBalanceListRequest
            {
                PeriodIdList = periodIdList
            });

            _AccountBalanceList.AddRange(response.AccountBalanceList);
          
        }

        private void assignPeriodDetailList()
        {
            if (_AccountBalanceList == null || !_AccountBalanceList.Any()) return;

            foreach(var period in _PeriodList)
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
                    TotalOpeningBalance = totalOpeningBalance.Value,
                    RemainingBalance = remainingBalance.Value,
                    TargetYield = targetYield.Value,
                    TotalPaid = totalPaid.Value,
                    Readiness = status
                };

                _Response.PeriodDetailList.Add(periodDetail);
            }

        }
    }
}