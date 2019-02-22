using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPGUI
{
    public partial class PaymentHistoryForm : MetroFramework.Forms.MetroForm
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }

        public PaymentHistoryForm()
        {
            InitializeComponent();
        }

        public void execute()
        {
            createDataTable();
            styleGrid(dgvPaymentHistory);
        }

        private void createDataTable()
        {
            var dataTable = DataTableHelper.GetDataTable(PaymentHistoryList);          
            dgvPaymentHistory.DataSource = dataTable;
        }

        private void styleGrid(DataGridView dataGridView, int? ColumnHeight = null)
        {

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

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9F, FontStyle.Bold);

            dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

    }
}
