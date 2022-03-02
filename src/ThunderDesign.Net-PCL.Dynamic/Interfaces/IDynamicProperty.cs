using ThunderDesign.Net.Threading.Interfaces;

namespace ThunderDesign.Net.Dynamic.Interfaces
{
    public interface IDynamicProperty : IBindableObject
    {
        #region properties
        string Name { get; }
        object Value { get; set; }
        #endregion
    }
}
