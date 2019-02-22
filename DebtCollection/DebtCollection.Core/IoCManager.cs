using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.Core
{
    public class IOCManager
    {
        private static IContainer _Container;
        private static IOCManager _IocManager;

        public static IOCManager Instance
        {
            get
            {
                if (_IocManager != null) return _IocManager;
                _IocManager = new IOCManager();
                return _IocManager;
            }

        }

        private IOCManager()
        {
            initialize();
        }

        private void initialize()
        {
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();

            var builder = new ContainerBuilder();
            foreach (var assembly in assemblyList)
            {
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().PropertiesAutowired();
            }

            _Container = builder.Build();            
        }

        public static T Resolve<T>()
        {
            var type = _Container.Resolve<T>();
            return type;
        }
    }
}
