using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Net;

namespace DebtCollection
{
    public interface IPeriodSetUp
    {
        ICollection<Period> GetPeriodList();

        void SavePeriodList(ICollection<Period> PeriodList);
    }

    [Export(typeof(IPeriodSetUp))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PeriodSetUp : IPeriodSetUp
    {
        #region Declarations
        #endregion Declarations

        public ICollection<Period> GetPeriodList()
        {
            var webrequest = (HttpWebRequest)WebRequest.Create("http://localhost:51373/api/period/periodlist");
            webrequest.Method = "GET";
            var webresponse = (HttpWebResponse)webrequest.GetResponse();


            var responseStream = webresponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var result = streamReader.ReadToEnd();
            var periodList = JsonConvert.DeserializeObject<List<Period>>(result);

            return periodList;
        }

        public void SavePeriodList(ICollection<Period> PeriodList)
        {
            //var accessService = IocManager.Resolve<IDebtCollectionAccess>(); 

            //var response = accessService.PersistPeriodList(new DebtCollectionAccess.Contracts.PersistPeriodListRequest
            //{
            //    PeriodList = transfer(PeriodList)
            //});

        }

        private ICollection<Period> transfer(ICollection<Period> PeriodList)
        {
            var periodList = PeriodList.Select(x => new Period
            {
                Id = x.Id,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                IsInvoiced = x.IsInvoiced,
                Name = x.Name,
                RunDate = x.RunDate
            }).ToList();

            return periodList;
        }      
    }
}
