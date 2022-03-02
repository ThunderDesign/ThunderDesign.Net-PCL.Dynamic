using SimpleContacts.Interfaces;
using SimpleContacts.ViewModels.Base;
using System.Windows.Input;
using ThunderDesign.Net.Threading.HelperClasses;
using Xamarin.Forms;

namespace SimpleContacts.Views.Base
{
    public abstract class DynamicView<T> : ContentPage where T : DynamicViewModel, new()
    {
        #region constructors
        public DynamicView() : base()
        {
            ViewModel = new T();
            BindingContext = ViewModel;
            RefreshViewCommand = new Command(OnRefreshViewCommand);
        }
        #endregion

        #region properties
        public IDynamicViewModel ViewModel { get; protected set; }
        public ICommand RefreshViewCommand { get; protected set; }
        #endregion

        #region methods
        protected virtual void OnRefreshViewCommand()
        {
            ThreadHelper.RunAndForget(async () => await ViewModel.LoadViewModelAsync(true).ConfigureAwait(false));
        }
        #endregion
    }
}
