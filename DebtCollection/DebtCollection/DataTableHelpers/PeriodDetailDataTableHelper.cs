﻿using DebtCollection.ViewModel;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtCollection.DataTableHelpers
{
    public class PeriodDetailDataTableHelper
    {
        public static DataTable GetDataTable(ICollection<AccountBalanceManager.Contracts.PeriodDetail> PeriodDetailList)
        {
            var periodDetailDataTable = new DataTable();

            periodDetailDataTable.Columns.Add(Constants.PERIOD_ID);
            periodDetailDataTable.Columns.Add(Constants.PERIOD_NAME);
            periodDetailDataTable.Columns.Add(Constants.OPENING_BALANCE);
            periodDetailDataTable.Columns.Add(Constants.TARGET_YIELD);
            periodDetailDataTable.Columns.Add(Constants.TOTAL_PAID);
            periodDetailDataTable.Columns.Add(Constants.CLOSING_BALANCE);
            periodDetailDataTable.Columns.Add(Constants.TARGET_METRIC);           


            foreach (var periodDetail in PeriodDetailList)
            {
                var dataRow = periodDetailDataTable.NewRow();

                dataRow[Constants.PERIOD_ID] = periodDetail.PeriodId;
                dataRow[Constants.PERIOD_NAME] = periodDetail.Name;
                dataRow[Constants.OPENING_BALANCE] = $"R {Math.Round(periodDetail.TotalOpeningBalance, 2, MidpointRounding.AwayFromZero)}";
                dataRow[Constants.TARGET_YIELD] = $"R {Math.Round(periodDetail.TargetYield, 2, MidpointRounding.AwayFromZero)}";
                dataRow[Constants.TOTAL_PAID] = $"R {Math.Round(periodDetail.TotalPaid, 2, MidpointRounding.AwayFromZero)}";
                dataRow[Constants.CLOSING_BALANCE] = $"R {Math.Round(periodDetail.RemainingBalance, 2, MidpointRounding.AwayFromZero)}";
                dataRow[Constants.TARGET_METRIC] = periodDetail.Readiness ? "Yes" : "No";

                periodDetailDataTable.Rows.Add(dataRow);
            }

            return periodDetailDataTable;
        }
    }
}
