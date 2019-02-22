using DebtCollection.Core;
using DebtCollection.ServiceHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtCollection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            createAssemblyContainer();            
            Application.Run(new MainForm());
        }

        private static void createAssemblyContainer()
        {
            var instance = IOCManager.Instance;
        }
    }
}
