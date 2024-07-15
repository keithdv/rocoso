using System;
using System.Collections.Generic;
using System.Text;
using Rocoso.Core;

namespace Rocoso.Rules
{
    public class RuleProxy
    {

        public IValidateBase Target { get; set; }

        internal IRegisteredPropertyAccess TargetSet => (IRegisteredPropertyAccess)Target;



    }
}
