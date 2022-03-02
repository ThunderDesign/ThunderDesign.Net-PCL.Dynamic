using SimpleContacts.Interfaces;
using SimpleContacts.Models;
using System.Threading.Tasks;
using ThunderDesign.Net.Dynamic.Extentions;

namespace SimpleContacts.Services
{
    public class ContactsService
    {
        #region methods
        public async static Task<IDynamicModel> GetContactsXMLAsync(bool forceRefresh = false)
        {
            if ((_ContactsXML != null) && (forceRefresh = false))
                return _ContactsXML;
            else if (_ContactsXML == null)
                _ContactsXML = new DynamicModel();
            else if (forceRefresh)
                _ContactsXML.Clear();

            _ContactsXML.LoadFromXML(_ContactsXMLData);
            return _ContactsXML;
        }

        private const string _ContactsXMLData =
            "<Contacts>" +
            "  <Contact>" +
            "    <FirstName>Deanne</FirstName>" +
            "    <LastName>Beltran</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Kelly</FirstName>" +
            "    <LastName>Chase</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Elliott</FirstName>" +
            "    <LastName>Crawford</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Allan</FirstName>" +
            "    <LastName>Cross</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Tyson</FirstName>" +
            "    <LastName>Lawson</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Christine</FirstName>" +
            "    <LastName>Moss</LastName>" +
            "  </Contact>" +
            "  <Contact>" +
            "    <FirstName>Jerrod</FirstName>" +
            "    <LastName>Petersen</LastName>" +
            "  </Contact>" +
            "</Contacts>";

        #endregion
        #region variables
        private static DynamicModel _ContactsXML = null;
        #endregion
    }
}
