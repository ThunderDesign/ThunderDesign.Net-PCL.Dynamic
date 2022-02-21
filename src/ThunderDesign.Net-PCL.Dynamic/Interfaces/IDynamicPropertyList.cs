using ThunderDesign.Net.Threading.Interfaces;

namespace ThunderDesign.Net.Dynamic.Interfaces
{
    public interface IDynamicPropertyList : IObservableDictionaryThreadSafe<string, IDynamicProperty>
    {
        void Add(IDynamicProperty value);
    }
}
