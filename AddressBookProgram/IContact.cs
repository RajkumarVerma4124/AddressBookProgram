using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public interface IContact
    {
        void AddContactDetails(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailId);
        void ViewContact();
        void EditContact(string personName);
        void DeleteContact(string personName);
    }
}
