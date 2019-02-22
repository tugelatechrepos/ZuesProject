using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPGUI
{
    public partial class SAPGUILoginForm : Form//: MetroFramework.Forms.MetroForm
    {
        public SAPGUILoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtUserName;
            this.Focus();          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            if (!validate()) return;
            this.Hide();
            new AccountForm().ShowDialog();            
        }

        private bool validate()
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty", "Validation", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
