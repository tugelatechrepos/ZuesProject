using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtCollection
{
    public partial class InvoicePreview : Form
    {
        private List<PaymentHistory> _PaymentHistoryList;
        private Period _Period;
        private List<InvoiceDataPreview> _InvoiceDataPreviewList;
        private DataTable _InvoiceLineItemListDataTable;
        private DataTable _ExpenseDataTable;
        private Invoice _Invoice;
        private InvoiceDetail _InvoiceDetail;
        private ICollection<Expense> _ExpenseList;
        private decimal _PaymentTotalWithoutExpenses;
        private decimal _ExpenseTotal;

        public InvoiceDataPreviewRequest InvoiceDataPreviewRequest { get; set; }

        public InvoicePreview()
        {
            InitializeComponent();
        }

        public void newExecute()
        {
            _InvoiceDetail = InvoiceDataPreviewRequest.InvoiceDetail;
            _ExpenseList = InvoiceDataPreviewRequest.InvoiceDetail.ExpenseList;

            assignInvoiceLineItemListDataTable();
            assignDataTableToExpenseGrid();
            styleGrids();
            assignCalculatedFields();
        }

        private void styleGrids()
        {
            styleGrid(dgvPaymentLineItems, 25);
            styleGrid(dgvExpense);
        }

        private void assignInvoiceLineItemListDataTable()
        {
            if (_InvoiceDetail.InvoiceLineItemList == null || !_InvoiceDetail.InvoiceLineItemList.Any()) return;

            _InvoiceLineItemListDataTable = new DataTable();
            _InvoiceLineItemListDataTable.Columns.Add(Constants.DESCRIPTION);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.TOTAL_ACCOUNTS);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.OPENING_BALANCE);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.TOTAL_PAID);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.YIELD_PERCENTAGE);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.COMMISSION_PERCENTAGE);
            _InvoiceLineItemListDataTable.Columns.Add(Constants.TOTAL_AMOUNT);


            foreach (var invoiceLineItem in _InvoiceDetail.InvoiceLineItemList)
            {
                var dataRow = _InvoiceLineItemListDataTable.NewRow();
                dataRow[Constants.DESCRIPTION] = invoiceLineItem.Description;
                dataRow[Constants.TOTAL_ACCOUNTS] = invoiceLineItem.NumberOfAccounts;
                dataRow[Constants.OPENING_BALANCE] = invoiceLineItem.TotalOpeningBalance;
                dataRow[Constants.TOTAL_PAID] = invoiceLineItem.TotalPaid;
                dataRow[Constants.YIELD_PERCENTAGE] = Math.Round(invoiceLineItem.Yield, 2, MidpointRounding.AwayFromZero);
                dataRow[Constants.COMMISSION_PERCENTAGE] = invoiceLineItem.CommissionPercentage;
                dataRow[Constants.TOTAL_AMOUNT] = Math.Round(invoiceLineItem.Amount, 2, MidpointRounding.AwayFromZero);

                _InvoiceLineItemListDataTable.Rows.Add(dataRow);
            }

            dgvPaymentLineItems.DataSource = _InvoiceLineItemListDataTable;

        }     

        private void styleGrid(DataGridView dataGridView, int? ColumnHeight = null)
        {
            dataGridView.BorderStyle = BorderStyle.FixedSingle;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.BackgroundColor = Color.White;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowTemplate.Height = 20;

            if (ColumnHeight.HasValue)
                dataGridView.ColumnHeadersHeight = ColumnHeight.Value;

            //dgvPeriod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9F, FontStyle.Bold);

            dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void assignDataTableToExpenseGrid()
        {
            _ExpenseDataTable = new DataTable();
            _ExpenseDataTable.Columns.Add(Constants.DESCRIPTION);
            _ExpenseDataTable.Columns.Add(Constants.QUANTITY);
            _ExpenseDataTable.Columns.Add(Constants.AMOUNT);
            _ExpenseDataTable.Columns.Add(Constants.VAT);

            if (_ExpenseList != null && _ExpenseList.Any())
            {
                foreach (var expense in _ExpenseList)
                {
                    var dataRow = _ExpenseDataTable.NewRow();
                    dataRow[Constants.DESCRIPTION] = expense.Description;
                    dataRow[Constants.QUANTITY] = expense.Quantity;
                    dataRow[Constants.AMOUNT] = Math.Round(expense.Amount, 2, MidpointRounding.AwayFromZero);
                    dataRow[Constants.VAT] = Math.Round(expense.Vat, 2, MidpointRounding.AwayFromZero);

                    _ExpenseDataTable.Rows.Add(dataRow);
                }
            }

            dgvExpense.DataSource = _ExpenseDataTable;

        }

        private void btnSaveExpenses_Click(object sender, EventArgs e)
        {
            var expenseList = new List<Expense>();

            foreach (DataGridViewRow expenseRow in dgvExpense.Rows)
            {
                var expense = new Expense();

                var description = Convert.ToString(expenseRow.Cells[0].Value);
                var quantity = expenseRow.Cells[1].Value != DBNull.Value ? Convert.ToInt32(expenseRow.Cells[1].Value) : 1;
                var amount = expenseRow.Cells[2].Value != DBNull.Value ? Convert.ToDecimal(expenseRow.Cells[2].Value) : 0;
                var vat = expenseRow.Cells[3].Value != DBNull.Value ? Convert.ToDecimal(expenseRow.Cells[3].Value) : 0;
                if (amount == 0) continue;
                var totalAmount = (amount * quantity) + vat;

                expense.Description = description;
                expense.Quantity = quantity;
                expense.Amount = amount;
                expense.Vat = vat;
                expense.TotalAmount = totalAmount;

                expenseList.Add(expense);
            }

            _InvoiceDetail.ExpenseList = expenseList;

            persistInvoice();

            MessageBox.Show("Expenses Saved successfully", "Save Expenses", MessageBoxButtons.OK);

            this.Close();
        }

        private void persistInvoice()
        {
            var invoiceDetailJson = JsonConvert.SerializeObject(_InvoiceDetail);
            var invoice = new Invoice
            {
                Id = _InvoiceDetail.InvoiceId,
                GeneratedOn = _InvoiceDetail.GeneratedOn,
                PeriodId = _InvoiceDetail.PeriodId,
                Detail = invoiceDetailJson
            };

            var response = InvoiceDataPreviewRequest.InvoiceHelper.PersistInvoice(new PersistInvoiceRequest
            {
                Invoice = invoice
            });

        }

        private void assignCalculatedFields()
        {
            var expenseList = new List<Expense>();

            foreach(DataGridViewRow expenseRow in dgvExpense.Rows)
            {
                var expense = new Expense();

                var description = Convert.ToString(expenseRow.Cells[0].Value);
                var quantity = expenseRow.Cells[1].Value != DBNull.Value ? Convert.ToInt32(expenseRow.Cells[1].Value) : 1;
                var amount = expenseRow.Cells[2].Value != DBNull.Value ? Convert.ToDecimal(expenseRow.Cells[2].Value) : 0;
                var vat = expenseRow.Cells[3].Value != DBNull.Value ? Convert.ToDecimal(expenseRow.Cells[3].Value) : 0;

                if (amount == 0.0M) continue;

                expense.Description = description;
                expense.Quantity = quantity;
                expense.Amount = amount;
                expense.Vat = vat;

                expenseList.Add(expense);
            }

            var expenseLineItemTotalList = expenseList?.Select(x => new { ExpenselineItemtotal = x.Amount * x.Quantity });

            var expenseTotal = expenseLineItemTotalList?.Sum(x => x.ExpenselineItemtotal) ?? 0.0M;
            var VatTotal = expenseList?.Sum(x => x.Vat) ?? 0.0M;

            var invoiceLineItemListTotal = _InvoiceDetail.InvoiceLineItemList.Sum(x => x.Amount);

            var newTotal = (invoiceLineItemListTotal + expenseTotal);
            var NetTotal = newTotal + VatTotal;

            lblTotal.Text = $"R {Convert.ToString(Math.Round(newTotal, 2, MidpointRounding.AwayFromZero))}";
            lblVat.Text = VatTotal == 0.0M ? "" : $"R {Convert.ToString(Math.Round(VatTotal, 2, MidpointRounding.AwayFromZero))}";
            lblNet.Text = $"R {Convert.ToString(Math.Round(NetTotal, 2, MidpointRounding.AwayFromZero))}";
        }

        private void dgvExpense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            assignCalculatedFields();
        }

        private void dgvExpense_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            assignCalculatedFields();
        }

        /* PRINT DOCUMENT WILL DO IT LATER

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var expenseList = new List<Expense>();
            var invoiceDataPreviewList = new List<InvoiceDataPreview>();

            foreach (DataGridViewRow row in dgvExpense.Rows)
            {
                var expense = new Expense();

                expense.Description = row.Cells["Description"]?.Value != DBNull.Value ? Convert.ToString(row.Cells["Description"]?.Value) : "";
                expense.Quantity = row.Cells["Quantity"]?.Value != DBNull.Value ? Convert.ToInt32(row.Cells["Quantity"]?.Value) : 0;
                expense.Amount = row.Cells["Amount"]?.Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Amount"].Value) : 0.0M;
                expense.Vat = row.Cells["VAT %"]?.Value != DBNull.Value ? Convert.ToDecimal(Convert.ToDecimal(row.Cells["VAT %"].Value)) : 0.0M;

                if (expense.Amount == 0.0M) continue;
                expenseList.Add(expense);
            }


            foreach (DataGridViewRow row in dgvPaymentLineItems.Rows)
            {
                var invoiceLineItems = new InvoiceDataPreview();

                invoiceLineItems.Description = row.Cells["Description"]?.Value != DBNull.Value ? Convert.ToString(row.Cells["Description"]?.Value) : "";
                invoiceLineItems.Quantity = row.Cells["Quantity"]?.Value != DBNull.Value ? Convert.ToInt32(row.Cells["Quantity"]?.Value) : 0;
                invoiceLineItems.Amount = row.Cells["Amount"]?.Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Amount"].Value) : 0.0M;
                invoiceLineItems.Commission = row.Cells["Commission"]?.Value != DBNull.Value ? Convert.ToDecimal(Convert.ToDecimal(row.Cells["Commission"].Value)) : 0.0M;

                if (invoiceLineItems.Amount == 0.0M) continue;
                invoiceDataPreviewList.Add(invoiceLineItems);
            }

            var expenseDataTable = getExpenseDataTable(expenseList);
            var InvoicePreviewDataTable = getInvoicePreviewDataTable(invoiceDataPreviewList);

            var invoiceDocumentForm = new InvoiceDocumentForm();
            invoiceDocumentForm.Request = new InvoiceDocumentRequest
            {
                InvoiceLineItemDataTable = InvoicePreviewDataTable,
                ExpenseLineItemDataTable = expenseDataTable,
                InvoiceId = _Invoice.Id,
                Total = lblTotal.Text,
                TotalVat = string.IsNullOrEmpty(lblVat.Text) ? "0.0" : lblVat.Text,
                Net = lblNet.Text,
                CurrentPeriod = $"{_Period.FromDate.ToString("dd/MM/yyyy")} - {_Period.ToDate.ToString("dd/MM/yyyy")}"
            };

            invoiceDocumentForm.ExecutePreview();
            invoiceDocumentForm.ShowDialog();
        }

        private DataTable getExpenseDataTable(ICollection<Expense> ExpenseList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Amount");
            dataTable.Columns.Add("VAT");


            foreach (var expense in ExpenseList)
            {
                var dataRow = dataTable.NewRow();
                dataRow["Description"] = expense.Description;
                dataRow["Quantity"] = expense.Quantity;
                dataRow["Amount"] = Math.Round(expense.Amount, 2, MidpointRounding.AwayFromZero);
                dataRow["VAT"] = Math.Round(expense.Vat, 2, MidpointRounding.AwayFromZero);

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;

        }

        private DataTable getInvoicePreviewDataTable(ICollection<InvoiceDataPreview> InvoiceDataPreviewList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Amount");
            dataTable.Columns.Add("Commission");


            foreach (var invoicePreview in InvoiceDataPreviewList)
            {
                var dataRow = dataTable.NewRow();
                dataRow["Description"] = invoicePreview.Description;
                dataRow["Quantity"] = invoicePreview.Quantity;
                dataRow["Amount"] = Math.Round(invoicePreview.Amount, 2, MidpointRounding.AwayFromZero);
                dataRow["Commission"] = Math.Round(invoicePreview.Commission, 2, MidpointRounding.AwayFromZero);

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

    */

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
