using System.Linq;
using System.Reflection;

namespace BlacksmithPress.Diabetes.Core.Common
{
    public abstract class ValueTypeBase : BindableBase
    {
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
                return this.GetType().GetTypeInfo().DeclaredProperties.All(property => property.GetValue(obj).Equals(property.GetValue(this)));
            return base.Equals(obj);
        }
    }
}
