using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AccountBalanceManagerService
{
    public class IocManager
    {
        private static IContainer _Container;
        private static IocManager _IocManager;

        public static IocManager Instance
        {
            get
            {
                if (_IocManager != null) return _IocManager;
                _IocManager = new IocManager();
                return _IocManager;
            }

        }

        private IocManager()
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