using SimpleContacts.ViewModels;
using SimpleContacts.Views.Base;
using Xamarin.Forms.Xaml;

namespace SimpleContacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsXMLView : DynamicView<ContactsXMLViewModel>
    {
        public ContactsXMLView()
        {
            InitializeComponent();
        }
    }
}