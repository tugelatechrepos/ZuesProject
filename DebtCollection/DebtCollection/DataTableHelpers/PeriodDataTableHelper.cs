using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public class PeriodDataTableHelper
    {
        public static DataTable GetPeriodDataTable(ICollection<Period> PeriodList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.ID);
            dataTable.Columns.Add(Constants.FROM_DATE);
            dataTable.Columns.Add(Constants.TO_DATE);
            dataTable.Columns.Add(Constants.RUN_DATE);

            if(PeriodList != null && PeriodList.Any())
            {
                foreach (var period in PeriodList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.ID] = period.Id;
                    dataRow[Constants.FROM_DATE] = period.FromDate;
                    dataRow[Constants.TO_DATE] = period.ToDate;
                    dataRow[Constants.RUN_DATE] = period.RunDate;

                    dataTable.Rows.Add(dataRow);
                }
            }          

            return dataTable;
        }
    }
}
