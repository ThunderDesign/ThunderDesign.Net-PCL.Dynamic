using SimpleContacts.Services;
using SimpleContacts.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleContacts.ViewModels
{
    public class ContactsXMLViewModel : DynamicViewModel
    {
        public override async Task<bool> LoadViewModelAsync(bool forceRefresh = false)
        {
            // Don't reload if we're already doing so...
            if (this.IsBusy)
            {
                return false;
            }

            try
            {
                // Show the "reload"-spinner and disable the reload-command (if needed).
                this.IsBusy = true;

                ViewModelData = await ContactsService.GetContactsXMLAsync(forceRefresh).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }
            return false;
        }
    }
}
