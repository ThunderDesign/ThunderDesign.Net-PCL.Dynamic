using System;
using System.Collections.Generic;
using System.Text;
using ThunderDesign.Net.Threading.Interfaces;

namespace ThunderDesign.Net.Dynamic.Interfaces
{
    public interface IDynamicExpandObject : IBindableObject
    {
        IDynamicPropertyList Properties { get; }
        void Clear();
    }
}
