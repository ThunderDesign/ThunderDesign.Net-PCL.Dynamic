using ThunderDesign.Net.Dynamic.Interfaces;
using ThunderDesign.Net.Threading.Collections;

namespace ThunderDesign.Net.Dynamic.Collections
{
    public class DynamicExpandObjectList<T> : ObservableCollectionThreadSafe<T>, IDynamicExpandObjectList<T> where T : IDynamicExpandObject
    {
    }
}
