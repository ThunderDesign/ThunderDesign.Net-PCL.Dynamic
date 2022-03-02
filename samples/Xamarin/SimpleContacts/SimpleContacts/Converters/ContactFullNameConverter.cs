using SimpleContacts.Interfaces;
using System;
using Xamarin.Forms;

namespace SimpleContacts.Converters
{
    public class ContactFullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            const string cLastName = "LastName";
            const string cFirstName = "FirstName";

            if (value == null)
                return null;

            if (!(value is IDynamicModel dynamicModel))
                throw new NotImplementedException();

            if (!(dynamicModel.Properties.ContainsKey(cLastName)))
                return null;

            if (!(dynamicModel.Properties.ContainsKey(cFirstName)))
                return null;

            return $"{dynamicModel.Properties[cLastName].Value}, {dynamicModel.Properties[cFirstName].Value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
