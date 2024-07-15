using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rocoso.Portal
{
    public interface IRemoteMethodPortal<D> where D : Delegate
    {

        Task<T> Execute<T>(params object[] p);

    }

}
