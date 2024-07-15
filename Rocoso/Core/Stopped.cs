using Rocoso.Portal;
using System;

namespace Rocoso.Core
{

    public class Stopped : IDisposable
    {
        IPortalTarget Target { get; }
        public Stopped(IPortalTarget target)
        {
            this.Target = target;
        }

        public void Dispose()
        {
            Target.StartAllActions();
        }
    }


}
