﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Rocoso.Portal
{
    public interface IPortalTarget
    {
        Task<IDisposable> StopAllActions();
        void StartAllActions();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPortalEditTarget : IPortalTarget
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        void MarkAsChild();

        [EditorBrowsable(EditorBrowsableState.Never)]
        void MarkNew();

        [EditorBrowsable(EditorBrowsableState.Never)]
        void MarkOld();

        [EditorBrowsable(EditorBrowsableState.Never)]
        void MarkUnmodified();
        [EditorBrowsable(EditorBrowsableState.Never)]
        void MarkDeleted();

    }

}
