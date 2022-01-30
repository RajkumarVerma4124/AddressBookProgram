using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public interface IContact
    {
        void AddContactDetails(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailId, string bookName);
        void ViewContact(string bookName);
        void ViewContact(string bookName, string personName);
        void EditContact(string personName, string bookName);
        void DeleteContact(string personName, string bookName);
        void AddAddressBook(string addBookName);
        void CheckAddressBook(string bookName);

    }
}
