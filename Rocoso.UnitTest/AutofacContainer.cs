using Autofac;
using Autofac.Core;
using Rocoso.AuthorizationRules;
using Rocoso.Core;
using Rocoso.Portal;
using Rocoso.Portal.Core;
using Rocoso.UnitTest.ObjectPortal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Autofac.Builder;
using Rocoso.Rules;
using Rocoso.UnitTest.Portal;
using Rocoso.Autofac;
using System.Reflection;

namespace Rocoso.UnitTest
{

    public static class AutofacContainer
    {


        private static IContainer Container;
        private static IContainer LocalPortalContainer;

        public static ILifetimeScope GetLifetimeScope(bool localPortal = false)
        {

            if (Container == null)
            {

                IContainer CreateContainer(Autofac.Portal portal)
                {
                    var builder = new ContainerBuilder();

                    builder.RegisterModule(new Rocoso.Autofac.RocosoCoreModule(portal));


                    if(portal == Autofac.Portal.NoPortal)
                    {
                        builder.RegisterGeneric(typeof(MockReceivePortal<>)).As(typeof(IReceivePortal<>)).AsSelf().InstancePerLifetimeScope();
                        builder.RegisterGeneric(typeof(MockReceivePortalChild<>)).As(typeof(IReceivePortalChild<>)).AsSelf().InstancePerLifetimeScope();
                        builder.RegisterGeneric(typeof(MockSendReceivePortal<>)).As(typeof(ISendReceivePortal<>)).AsSelf().InstancePerLifetimeScope();
                        builder.RegisterGeneric(typeof(MockSendReceivePortalChild<>)).As(typeof(ISendReceivePortalChild<>)).AsSelf().InstancePerLifetimeScope();
                    }
                        
                        
                    builder.AutoRegisterAssemblyTypes(Assembly.GetExecutingAssembly());

                    // Unit Test Library
                    builder.RegisterType<BaseTests.Authorization.AuthorizationGrantedRule>().As<BaseTests.Authorization.IAuthorizationGrantedRule>().InstancePerLifetimeScope(); // Not normal - Lifetimescope so the results can be validated
                    builder.RegisterType<BaseTests.Authorization.AuthorizationGrantedAsyncRule>().As<BaseTests.Authorization.IAuthorizationGrantedAsyncRule>().InstancePerLifetimeScope(); // Not normal - Lifetimescope so the results can be validated
                    builder.RegisterType<BaseTests.Authorization.AuthorizationGrantedDependencyRule>().As<BaseTests.Authorization.IAuthorizationGrantedDependencyRule>().InstancePerLifetimeScope(); // Not normal - Lifetimescope so the results can be validated

                    builder.RegisterType<Objects.DisposableDependency>().As<Objects.IDisposableDependency>();
                    builder.RegisterType<Objects.DisposableDependencyList>().InstancePerLifetimeScope();

                    builder.Register<MethodObject.Execute>(cc =>
                    {
                        var dd = cc.Resolve<Func<Objects.IDisposableDependency>>();
                        return i => MethodObject.ExecuteServer(i, dd());
                    });

                    builder.Register<IReadOnlyList<PersonObjects.PersonDto>>(cc =>
                    {
                        return PersonObjects.PersonDto.Data();
                    }).SingleInstance();

                    return builder.Build();
                }

                Container = CreateContainer(Autofac.Portal.NoPortal);
                LocalPortalContainer = CreateContainer(Autofac.Portal.Local);

            }

            if (!localPortal)
            {
                return Container.BeginLifetimeScope();
            }
            else
            {
                return LocalPortalContainer.BeginLifetimeScope();
            }

        }

    }
}
