using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBook: IContact
    {
        //Creating a contact list
        private readonly List<Contact> contactList;
        private readonly Dictionary<string, AddressBook> addressContactBook;

        public AddressBook()
        {
            contactList = new List<Contact>();
            addressContactBook = new Dictionary<string, AddressBook>();
        }

        //Method to create contact(UC1) 
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailId, string bookName)
        {
            Contact personDetail = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, emailId);
            addressContactBook[bookName].contactList.Add(personDetail);
        }

        //Method to view contact
        public void ViewContact(string bookName)
        {
            int count = 1;
            foreach (var contact in addressContactBook[bookName].contactList)
            {
                Console.WriteLine("Person Details {0} ------> ",count);
                Console.WriteLine("First Name : {0} || Last Name : {1}", contact.firstName, contact.lastName);
                Console.WriteLine("Address : {0} ", contact.address);
                Console.WriteLine("City Name : {0} || State Name : {1} || ZipCode : {2}", contact.city, contact.state, contact.zip);
                Console.WriteLine("Phone Number : {0}", contact.phoneNumber);
                Console.WriteLine("Email Id : {0} ", contact.emailId);
                Console.ReadLine();
                count++;
            }
        }

        //Method to view single contact
        public void ViewContact(string personName, string bookName)
        {
            for (int i = 0; i < addressContactBook[bookName].contactList.Count; i++)
            {
                var contact = addressContactBook[bookName].contactList[i];
                if (contact.firstName == personName)
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

        //Method to edit contacts(UC3)
        public void EditContact(string personName, string bookName)
        {
            //Traversing the contact list
            for (int i = 0; i < addressContactBook[bookName].contactList.Count; i++)
            {
                var contact = addressContactBook[bookName].contactList[i];
                EditContactDetails.EditPersonDetails(contact, personName);
            }
        }

        //Method to delete contact details using first name(UC4)
        public void DeleteContact(string personName, string bookName) 
        {
            for(int i = 0; i < addressContactBook[bookName].contactList.Count; i++)
            {
                var contact = addressContactBook[bookName].contactList[i];
                if (contact.firstName == personName)
                {
                    Console.WriteLine("Record Of {0} Deleted Successfully", contact.firstName);
                    addressContactBook[bookName].contactList.RemoveAt(i);
                }
            }

        }

        //Refactor to add multiple Address Book to the System(UC6)
        public void AddAddressBook(string addBookName)
        {
            AddressBook addressBook = new AddressBook();
            addressContactBook.Add(addBookName, addressBook);
            Console.WriteLine("AddressBook Created.\n");
        }

        //For Checking If AddressBook Is Present Or Not(UC6)
        public void CheckAddressBook(string bookName)
        {
            foreach (var contact in addressContactBook)
            {
                if (contact.Key == bookName)
                {
                    Console.WriteLine("Switching To Book Name : "+bookName);
                    Console.ReadLine();
                    break;
                }        
                else
                {
                    Console.Write("Book Name Doesnt Exist");
                    Console.ReadLine();
                    break;
                }
                   
            }
        }

        //Returning the bookname with contact values to view(UC6 
        public Dictionary<string, AddressBook> GetAddressBook()
        {
            return addressContactBook;
        }
    }
}
