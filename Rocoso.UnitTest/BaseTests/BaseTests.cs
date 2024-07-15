﻿using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rocoso.UnitTest.BaseTests
{
    [TestClass]
    public class BaseTests
    {
        private ILifetimeScope scope;
        private IBaseObject single;

        [TestInitialize]
        public void TestInitialize()
        {
            scope = AutofacContainer.GetLifetimeScope();
            single = scope.Resolve<IBaseObject>();
        }
        [TestMethod]
        public void Base_Construct()
        {
            var name = single.FirstName;
        }

        [TestMethod]
        public void Base_Set()
        {
            single.Id = Guid.NewGuid();
            single.FirstName = Guid.NewGuid().ToString();
            single.LastName = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public void Base_SetGet()
        {
            var id = single.Id = Guid.NewGuid();
            var firstName = single.FirstName = Guid.NewGuid().ToString();
            var lastName = single.LastName = Guid.NewGuid().ToString();

            Assert.AreEqual(id, single.Id);
            Assert.AreEqual(firstName, single.FirstName);
            Assert.AreEqual(lastName, single.LastName);
        }

        [TestMethod]
        public void Base_Set_Inherited_Type_Setter()
        {
            var B = new B();
            single.TestPropertyType = B;
        }

        [TestMethod]
        public void Base_Set_Inherited_Type_LoadProperty()
        {
            var B = new B();
            single.LoadPropertyTest(B);
        }

        [TestMethod]
        public void Base_Set_Parent()
        {
            var child = scope.Resolve<IBaseObject>();
            single.Child = child;
            Assert.AreSame(single, child.Parent);
        }
    }
}
