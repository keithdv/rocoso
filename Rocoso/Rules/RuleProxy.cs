using System;
using System.Collections.Generic;
using System.Text;

namespace Rocoso.Rules
{
    public class RuleProxy
    {

        public IValidateBase Target { get; set; }

        internal IPropertyAccess TargetSet => (IPropertyAccess)Target;



    }
}
