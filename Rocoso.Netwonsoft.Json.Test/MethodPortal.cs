﻿using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rocoso.Netwonsoft.Json.Test
{

    public class MethodObject
    {
        public delegate int CommandMethod(int number);

        public static int CommendMethod_(int number, IDisposableDependency dependency)
        {
            Assert.IsNotNull(dependency);
            return number * 10;
        }
    }

    public interface IRemoteMethod
    {
        void Execute();
    }
    public interface IRemoteMethod<S, P, T> : IRemoteMethod where S : Delegate
    {
        P Param { get; set; }
    }

    /// <summary>
    /// Serialize the parameters there
    /// Than serialize the result back
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class RemoteMethodCall<S, P, T> : IRemoteMethod<S, P, T>
        where S : Delegate
    {

        public RemoteMethodCall(S method)
        {
            this.Method = method;
        }

        private S Method { get; }

        public P Param { get; set; }

        public T Return { get; set; }

        public void Execute()
        {
            Return = (T)Method.Method.Invoke(Method.Target, new object[1] { Param });
        }

    }



    [TestClass]
    public class MethodPortalTests
    {
        private ILifetimeScope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            scope = AutofacContainer.GetLifetimeScope();
        }

        [TestMethod]
        public void MethodPortalTest()
        {

            var client = scope.Resolve<IRemoteMethod<MethodObject.CommandMethod, int, int>>();

            client.Param = 10;

            var sendJson = JsonConvert.SerializeObject(client, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                ContractResolver = scope.Resolve<FatClientContractResolver>()
            });

            var server = JsonConvert.DeserializeObject<IRemoteMethod>(sendJson, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = scope.Resolve<FatClientContractResolver>()
            });

            server.Execute();

            var returnJson = JsonConvert.SerializeObject(server, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                ContractResolver = scope.Resolve<FatClientContractResolver>()
            });

            var clientResult = JsonConvert.DeserializeObject<IRemoteMethod<MethodObject.CommandMethod, int, int>>(returnJson, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = scope.Resolve<FatClientContractResolver>()
            });

        }


        [TestMethod]
        public void MethodPortal_Serialize_Client()
        {

        }
    }
}
