using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace DebtCollectionAccess
{
    public class IocManager
    {
        public static T Resolve<T>()
        {
            T resolvedType;
            var assemblies = new[] { typeof(T).GetTypeInfo().Assembly };
            var configuration = new ContainerConfiguration()
               .WithAssembly(typeof(T).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                resolvedType = container.GetExport<T>();
            }

            return resolvedType;
        }
    }
}
