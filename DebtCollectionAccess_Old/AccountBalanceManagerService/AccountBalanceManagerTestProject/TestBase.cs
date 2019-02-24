using AccountBalanceManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManagerTestProject
{
    public class TestBase
    {
        public TestBase()
        {
            initialize();
        }

        private void initialize()
        {
            var instance = IocManager.Instance;
        }
    }
}
