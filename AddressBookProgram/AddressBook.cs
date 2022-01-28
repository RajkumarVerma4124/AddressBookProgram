using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBook
    {
        //Creating a contact list
        List<Contact> contactList;

        public AddressBook()
        {
            contactList = new List<Contact>();
        }

        //Method to create contact(UC1) 
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailId)
        {
            Contact personDetail = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, emailId);
            contactList.Add(personDetail);
        }

        //Method to view contact
        public void ViewContact()
        {
            foreach (var contact in contactList)
            {
                Console.WriteLine("First Name : {0} || Last Name : {1}", contact.firstName, contact.lastName);
                Console.WriteLine("Address : {0} ", contact.address);
                Console.WriteLine("City Name : {0} || State Name : {1} || ZipCode : {2}", contact.city, contact.state, contact.zip);
                Console.WriteLine("Phone Number : {0}", contact.phoneNumber);
                Console.WriteLine("Email Id : {0} ", contact.emailId);
                Console.ReadLine();
            }
        }
    }
}
