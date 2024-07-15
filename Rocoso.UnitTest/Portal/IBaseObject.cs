﻿using System;

namespace Rocoso.UnitTest.ObjectPortal
{
    public interface IBaseObject : IBase
    {
        int IntCriteria { get; }
        Guid GuidCriteria { get; }
        object[] MultipleCriteria { get; }
        bool CreateCalled { get; set; }
        bool CreateChildCalled { get; set; }
        bool FetchCalled { get; set; }
        bool FetchChildCalled { get; set; }

    }
}