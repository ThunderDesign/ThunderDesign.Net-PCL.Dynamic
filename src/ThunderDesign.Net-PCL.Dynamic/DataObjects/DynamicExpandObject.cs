using System.ComponentModel;
using ThunderDesign.Net.Dynamic.Collections;
using ThunderDesign.Net.Dynamic.Interfaces;
using ThunderDesign.Net.Threading.Extentions;
using ThunderDesign.Net.Threading.Objects;

namespace ThunderDesign.Net.Dynamic.DataObjects
{
    public class DynamicExpandObject : ThreadObject, IDynamicExpandObject
    {
        #region event handlers
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region properties
        public IDynamicPropertyList Properties
        {
            get { return this.GetProperty(ref _Properties, _Locker); }
            private set { _Properties = value; }
        }
        #endregion

        #region methods
        public virtual void OnPropertyChanged(string propertyName)
        {
            this.NotifyPropertyChanged(PropertyChanged, propertyName);
        }

        public virtual void Clear()
        {
            ((System.Collections.IDictionary)this.Properties).Clear();
        }
        #endregion

        #region variables
        protected IDynamicPropertyList _Properties = new DynamicPropertyList();
        #endregion
    }
}
