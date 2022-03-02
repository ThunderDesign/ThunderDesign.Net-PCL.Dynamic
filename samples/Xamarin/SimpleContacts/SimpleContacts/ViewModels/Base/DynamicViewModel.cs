using SimpleContacts.Interfaces;
using System.ComponentModel;
using System.Threading.Tasks;
using ThunderDesign.Net.Threading.Extentions;
using ThunderDesign.Net.Threading.HelperClasses;
using ThunderDesign.Net.Threading.Objects;

namespace SimpleContacts.ViewModels.Base
{
    public abstract class DynamicViewModel : ThreadObject, IDynamicViewModel
    {
        #region constructors
        public DynamicViewModel() : base()
        {
            ThreadHelper.RunAndForget(async () => await LoadViewModelAsync(false).ConfigureAwait(false));
        }
        #endregion

        #region event handlers
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region properties
        public bool IsBusy
        {
            get { return this.GetProperty(ref _IsBusy, _Locker); }
            set { this.SetProperty(ref _IsBusy, value, _Locker, PropertyChanged); }
        }

        public IDynamicModel ViewModelData
        {
            get { return this.GetProperty(ref _ViewModelData, _Locker); }
            set { this.SetProperty(ref _ViewModelData, value, _Locker, true); }
        }
        #endregion

        #region methods
        public abstract Task<bool> LoadViewModelAsync(bool forceRefresh = false);

        public virtual void OnPropertyChanged(string propertyName)
        {
            this.NotifyPropertyChanged(PropertyChanged, propertyName);
        }
        #endregion

        #region variables
        protected bool _IsBusy = false;
        protected IDynamicModel _ViewModelData;
        #endregion
    }
}
