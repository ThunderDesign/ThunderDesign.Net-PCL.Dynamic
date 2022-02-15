using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ThunderDesign.Net.Dynamic.Interfaces;
using ThunderDesign.Net.Threading.Extentions;
using ThunderDesign.Net.Threading.Objects;

namespace ThunderDesign.Net.Dynamic.DataObjects
{
    public class DynamicProperty : ThreadObject, IDynamicProperty
    {
        #region constructors
        public DynamicProperty(string name) : base()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Parameter cannot be null", nameof(name));

            Name = name;
        }
        public DynamicProperty(string name, object value) : this(name)
        {
            Value = value;
        }
        #endregion

        #region event handlers
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region properties
        public string Name
        {
            get;
            private set;
        }

        public object? Value
        {
            get { return this.GetProperty(ref _Value, _Locker); }
            set { this.SetProperty(ref _Value, value, _Locker, true); }
        }
        #endregion

        #region methods
        public virtual void OnPropertyChanged(string propertyName)
        {
            this.NotifyPropertyChanged(PropertyChanged, propertyName);
        }
        #endregion

        #region variables
        protected object? _Value = null;
        #endregion
    }
}
