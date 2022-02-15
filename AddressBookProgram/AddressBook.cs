using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    /// <summary>
    /// Creating The Address Book For Adding Multiple Books And Multiple Person
    /// </summary>
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
            try
            {
                Contact personDetail = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, emailId);
                if (CheckDuplicateEntry(personDetail, bookName))
                {
                    Console.WriteLine("Person Already Exits In The Book");
                }
                else
                {      
                    addressContactBook[bookName].contactList.Add(personDetail);
                    Console.WriteLine("Added Contact SuccessFully\n");                   
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Method to view contact
        public void ViewContact(string bookName)
        {
            int count = 1;
            foreach (var contact in addressContactBook[bookName].contactList)
            {
                Console.WriteLine("Person Details Of {0} ------> ",contact.firstName);
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
            foreach (var contact in  addressContactBook[bookName].contactList)
            {
                if (contact.firstName.Equals(personName))
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
            for (int i = 0; i < addressContactBook[bookName].contactList.Count; i++)
            {
                var contact = addressContactBook[bookName].contactList[i];
                if (contact.firstName == personName)
                {
                    Console.WriteLine("Record Of {0} Deleted Successfully", contact.firstName);
                    addressContactBook[bookName].contactList.RemoveAt(i);
                }
                else
                    Console.WriteLine("Contact Not Found");
            }   
        }

        //Refactor to add multiple Address Book to the System(UC6)
        public void AddAddressBook(string addBookName)
        {
            var contact = addressContactBook;
            if (contact.ContainsKey(addBookName))
            {
                Console.WriteLine("Book Name Exists ");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                addressContactBook.Add(addBookName, addressBook);
                Console.WriteLine("AddressBook Created.\n");
            }      
        }

        //For Checking If AddressBook Is Present Or Not(UC6)
        public void CheckAddressBook(string bookName)
        {
            foreach (var book in addressContactBook)
            {
                if (book.Key == bookName)
                {
                    Console.WriteLine("Switching To Book Name : "+bookName);
                    Console.ReadLine();
                    break;
                }                       
            }
            Console.Write("Book Name Doesnt Exist");
        }

        //Returning the bookname with contact values to view(UC6 
        public Dictionary<string, AddressBook> GetAddressBook()
        {
            return addressContactBook;
        }

        //Returning list of values form particular book(UC7)
        public List<Contact> GetListOfAddressBookValues(string bookName)
        {
            List<Contact> book = new List<Contact>();
            if (bookName != null)
            {
                foreach (var value in addressContactBook[bookName].contactList)
                {
                    book.Add(value);
                }
                return book;
            }
            else
                return default;
        }

        //Checking For Duplicate Entry If Any(UC7)
        public bool CheckDuplicateEntry(Contact contact, string bookName)
        {
            List<Contact> book = GetListOfAddressBookValues(bookName);
            if (bookName != null)
            {
                if (book.Any(b => b.Equals(contact)))
                    return true;
            }
            return default;
        }

        //Method to add a new list of values from multiple books(UC8)
        public List<Contact> GetListOfMulAddressBookValues(List<Contact> addrBookName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in addrBookName)
            {
                book.Add(value);
            }
            return book;
        }

        //Method to search the person by city(UC8)
        public void SearchPersonByCity(string city)
        {
            foreach (AddressBook addrBookObj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfMulAddressBookValues(addrBookObj.contactList);
                foreach (Contact contact in contactList.FindAll(c => c.city.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }

        //Method to search the person by state(UC8)
        public void SearchPersonByState(string state)
        {
            foreach (AddressBook addressbookobj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfMulAddressBookValues(addressbookobj.contactList);
                foreach (Contact contact in contactList.FindAll(c => c.state.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
    }
}
