using AccountBalanceManager.Contracts;
using DebtCollection.DataTableHelpers;
using DebtCollection.ServiceHelpers;
using DebtCollection.ViewModel;
using DebtCollectionAccess;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtCollection
{
    public partial class frmInvoice : MaterialForm
    {
        private DebtCollectionAccess.Period _Period;
        private ICollection<AccountBalanceManager.Contracts.InvoiceDetail> _InvoiceDetailList;
        private List<InvoiceDataForGrid> _InvoiceListDataGrid;
        private int? _InvoiceId;

        public int PeriodId { get; set; }
        public IPeriodHelper PeriodHelper { get; set; }
        public IInvoiceHelper InvoiceHelper { get; set; }
        public int CompanyId { get; set; }

        public frmInvoice()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
            Primary.BlueGrey100, Primary.BlueGrey200, Primary.BlueGrey400,
            Accent.Blue400, TextShade.BLACK);
        }

        public void Execute()
        {
            assignPeriod();
            assignPeriodText();
            assignInvoiceList();         
        }

        private void assignPeriod()
        {
            var periodListResponse = PeriodHelper.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest
            {
                PeriodIdList = new List<int> { PeriodId }
            });

           _Period =  periodListResponse.PeriodList.FirstOrDefault();
        }

        private void assignPeriodText()
        {
            lblPeriodText.Text = $"Period : {_Period.Name}";
        }

        private void assignInvoiceList()
        {
            lblInvoiceStatus.Visible = true;
            lblInvoiceStatus.Text = "Getting Invoice List...Please wait";

            bgGetInvoiceList.RunWorkerAsync();           
        }

        private void assignInvoiceListDataGrid()
        {
            if (_InvoiceDetailList == null || !_InvoiceDetailList.Any()) return;

            _InvoiceListDataGrid = new List<InvoiceDataForGrid>();

            foreach (var invoiceDetail in _InvoiceDetailList)
            {
                var count = invoiceDetail.InvoiceLineItemList.Count();
                var invoiceId = invoiceDetail.InvoiceId;
                var date = invoiceDetail.GeneratedOn;
                var Yield = invoiceDetail.InvoiceLineItemList.Sum(x => x.Yield) / count;
                var Commission = invoiceDetail.InvoiceLineItemList.Sum(x => x.CommissionPercentage) / count;
                var totalOpeningBal = invoiceDetail.InvoiceLineItemList.Sum(x => x.TotalOpeningBalance);
                var totalPaid = invoiceDetail.InvoiceLineItemList.Sum(x => x.TotalPaid);
                var InvoiceTotal = invoiceDetail.InvoiceLineItemList.Sum(x => x.Amount);

                var invoiceDataForGrid = new InvoiceDataForGrid
                {
                    Id = invoiceId,
                    Date = date,
                    TotalOpeningBalance = totalOpeningBal,
                    TotalPaid = totalPaid,
                    YieldPercentage = $"{Math.Round(Yield, 2, MidpointRounding.AwayFromZero)}",
                    CommisionOnYield = Commission,
                    InvoiceTotal = InvoiceTotal
                };

                _InvoiceListDataGrid.Add(invoiceDataForGrid);
            }

            dgvInvoiceList.Columns.Clear();
            var dataTable = InvoiceDataTableHelper.GetInvoiceDataTable(_InvoiceListDataGrid);
            dgvInvoiceList.DataSource = dataTable;
            dgvInvoiceList.Visible = true;
            StyleGridHelper.StyleGrid(dgvInvoiceList);
        }

        private void bgGetInvoiceList_DoWork(object sender, DoWorkEventArgs e)
        {
            var invoiceListResponse = InvoiceHelper.GetInvoiceList(new DebtCollectionAccess.Contracts.GetInvoiceListRequest
            {
                PeriodIdList = new List<int> { _Period.Id },
                CompanyId = CompanyId
            });
            _InvoiceDetailList = invoiceListResponse.InvoiceDetailList;
        }

        private void bgGetInvoiceList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_InvoiceDetailList == null || !_InvoiceDetailList.Any())
            {
                btnGenerateInvoice_Click(null, null);
                return;
            }

            assignInvoiceListDataGrid();
            lblInvoiceStatus.Visible = false;
        }

        private void bgGenerateInvoice_DoWork(object sender, DoWorkEventArgs e)
        {
            var generateInvoiceResponse = InvoiceHelper.GenerateInvoice(new GenerateInvoiceRequest
            {
                PeriodId = _Period.Id,
                CompanyId = CompanyId
            });

           _InvoiceId = generateInvoiceResponse.InvoiceId;
        }

        private void bgGenerateInvoice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblInvoiceStatus.Text = "";
            if (!_InvoiceId.HasValue)
            {
                MessageBox.Show("There was an error while previewing Invoice", "Invoice Preview", MessageBoxButtons.OK);
                return;
            }

            assignInvoiceList();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            lblInvoiceStatus.Text = "Generating Invoice.. Please Wait";
            bgGenerateInvoice.RunWorkerAsync();
        }

    }
}
