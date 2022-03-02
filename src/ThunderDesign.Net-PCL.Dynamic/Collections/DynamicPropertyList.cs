using System;
using System.Collections.Generic;
using ThunderDesign.Net.Dynamic.Interfaces;
using ThunderDesign.Net.Threading.Collections;

namespace ThunderDesign.Net.Dynamic.Collections
{
    public class DynamicPropertyList : ObservableDictionaryThreadSafe<string, IDynamicProperty>, IDynamicPropertyList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Obsolete>")]
        [Obsolete("This is not supported in this class.", true)]
        private new void Add(string key, IDynamicProperty value)
        {
            //Hiding base.Add(TKey key, TValue value);
        }

        void IDictionary<string, IDynamicProperty>.Add(string key, IDynamicProperty value)
        {
            this.Add(value);
        }

        public void Add(IDynamicProperty value)
        {
            base.Add(value.Name, value);
        }
    }
}
