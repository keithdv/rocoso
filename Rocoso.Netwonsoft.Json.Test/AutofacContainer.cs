using Autofac;
using Autofac.Core;
using Rocoso.AuthorizationRules;
using Rocoso.Core;
using Rocoso.Portal;
using Rocoso.Portal.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Autofac.Builder;
using Rocoso.Rules;
using Rocoso.Netwonsoft.Json.Test.BaseTests;
using Rocoso.Netwonsoft.Json.Test.EditTests;
using Rocoso.Netwonsoft.Json.Test.ValidateTests;
using Rocoso.Newtonsoft.Json;
using Rocoso.Autofac;
using System.Reflection;

namespace Rocoso.Netwonsoft.Json.Test
{

    public static class AutofacContainer
    {

        private static IContainer Container;

        public static ILifetimeScope GetLifetimeScope()
        {

            if (Container == null)
            {
                var builder = new ContainerBuilder();

                // Run first - some of these definition need to be modified
                builder.RegisterModule(new RocosoCoreModule(Autofac.Portal.Local));

                builder.AutoRegisterAssemblyTypes(Assembly.GetExecutingAssembly());

                // Newtonsoft.Json
                builder.RegisterType<FatClientContractResolver>();
                builder.RegisterType<ListBaseCollectionConverter>();

                builder.RegisterType<DisposableDependencyList>();
                builder.RegisterType<DisposableDependency>().As<IDisposableDependency>().InstancePerLifetimeScope();

                builder.Register<MethodObject.CommandMethod>(cc =>
                {
                    var dd = cc.Resolve<Func<IDisposableDependency>>();
                    return i => MethodObject.CommendMethod_(i, dd());
                });

                builder.RegisterGeneric(typeof(RemoteMethodCall<,,>)).As(typeof(IRemoteMethod<,,>)).AsSelf();
                builder.RegisterType<MethodObject>();

                Container = builder.Build();
            }

            return Container.BeginLifetimeScope(Guid.NewGuid());

        }

    }
}
