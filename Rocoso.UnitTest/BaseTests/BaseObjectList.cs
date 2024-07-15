﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rocoso.UnitTest.BaseTests
{

    public interface IBaseObjectList : IListBase<IBaseObject>
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
    public class BaseObjectList : ListBase<BaseObjectList, IBaseObject>, IBaseObjectList
    {

        public BaseObjectList(IListBaseServices<BaseObjectList, IBaseObject> services) : base(services) { }

        public Guid Id
        {
            get { return Getter<Guid>(); }
            set { Setter(value); }
        }

        public string FirstName
        {
            get { return Getter<string>(); }
            set { Setter(value); }
        }

        public string LastName
        {
            get { return Getter<string>(); }
            set { Setter(value); }
        }


    }
}
