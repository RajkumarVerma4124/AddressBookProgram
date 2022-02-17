using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Collections;
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
        private Dictionary<string, Contact> contactList = new Dictionary<string, Contact>();
        private Dictionary<string, AddressBook> addressContactBook = new Dictionary<string, AddressBook>();
        private Dictionary<Contact, string> personsCity = new Dictionary<Contact, string>();
        private Dictionary<Contact, string> personsState = new Dictionary<Contact, string>();
    
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
                    addressContactBook[bookName].contactList.Add(personDetail.firstName+" "+personDetail.lastName, personDetail);
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
            foreach (var contact in addressContactBook[bookName].contactList.Values)
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
                if (contact.Key.Equals(personName))
                {
                    Console.WriteLine("First Name : {0} || Last Name : {1}", contact.Value.firstName, contact.Value.lastName);
                    Console.WriteLine("Address : {0} ", contact.Value.address);
                    Console.WriteLine("City Name : {0} || State Name : {1} || ZipCode : {2}", contact.Value.city, contact.Value.state, contact.Value.zip);
                    Console.WriteLine("Phone Number : {0}", contact.Value.phoneNumber);
                    Console.WriteLine("Email Id : {0} ", contact.Value.emailId);
                    Console.ReadLine();
                }
            }           
        }

        //Method to edit contacts(UC3)
        public void EditContact(string personName, string bookName)
        {
            //Traversing the contact list
            foreach (var contact in addressContactBook[bookName].contactList)
            {
                EditContactDetails.EditPersonDetails(contact, personName);
            }
        }

        //Method to delete contact details using first name(UC4)
        public void DeleteContact(string personName, string bookName) 
        {
            if (addressContactBook[bookName].contactList.ContainsKey(personName))
            {
                addressContactBook[bookName].contactList.Remove(personName);
                Console.WriteLine("Record Of {0} Deleted Successfully", personName);
            }
            else
                Console.WriteLine("Contact Not Found");   
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

        //Method to add a new list of values from multiple books(UC7 & UC8)
        public List<Contact> GetListOfMulAddressBookKeys(string addrBookName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in addressContactBook[addrBookName].contactList.Values)
            {
                book.Add(value);
            }
            return book;
        }

        //Method to add a new list of values from multiple dictionary's(UC9)
        public List<Contact> GetListOfDictionaryContactKeys(Dictionary<Contact, string> dictionaryName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in dictionaryName.Keys)
            {
                book.Add(value);
            }
            return book;
        }

        //Checking For Duplicate Entry If Any(UC7)
        public bool CheckDuplicateEntry(Contact contact, string bookName)
        {  
            List<Contact> book = GetListOfMulAddressBookKeys(bookName);
            if (bookName != null)
            {
                if (book.Any(b => b.Equals(contact)))
                    return true;
            }  
            return default;
        }

        //Method to search the person by city(UC8)
        public void SearchPersonByCity(string city)
        {
            CreateCityDictionary();
            foreach (AddressBook addrBookObj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfDictionaryContactKeys(addrBookObj.personsCity);
                foreach (Contact contact in contactList.FindAll(c => c.city.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }

        //Method to search the person by state(UC8)
        public void SearchPersonByState(string state)
        {
            CreateStateDictionary();
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfDictionaryContactKeys(addressBookObj.personsState);
                foreach (Contact contact in contactList.FindAll(c => c.state.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }

        //Method to maintain dictionary of city and person(UC9)
        public void CreateCityDictionary()
        {
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                foreach (Contact contact in addressBookObj.contactList.Values)
                {
                    if (addressBookObj.personsCity.ContainsKey(contact))
                        continue;
                    else
                        addressBookObj.personsCity.Add(contact, contact.city);
                }
            }
        }

        //Method to maintain dictionary of state and person(UC9)
        public void CreateStateDictionary()
        {
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                foreach (Contact contact in addressBookObj.contactList.Values)
                {
                    if (addressBookObj.personsState.ContainsKey(contact))
                        continue;
                    else
                        addressBookObj.personsState.Add(contact, contact.state);
                }
            }
        }

        //Method to get number of contact persons by counting city or state(UC10)
        public void DisplayCountByCityandState()
        {
            //Maintaining dictionary for person by city and person by state
            CreateCityDictionary();
            CreateStateDictionary();
            var countByCity = new Dictionary<string, int>();
            var countByState = new Dictionary<string, int>();
            
            //For counting persons city from diff addressbook
            foreach (var obj in addressContactBook.Values)
            {
                foreach (var person in obj.personsCity)
                {
                    if (countByCity.ContainsKey(person.Value))
                        countByCity[person.Value]++;
                    else
                    {
                        countByCity.Add(person.Value, 0);
                        countByCity[person.Value]++;
                    }
                }
            }
            Console.WriteLine("\nNumber of person in city wise count");
            foreach (var person in countByCity)
            {
                Console.WriteLine($"{person.Key} : {person.Value}");
            }

            //For counting persons state from diff addressbook
            foreach (var obj in addressContactBook.Values)
            {
                foreach (var person in obj.personsState)
                {
                    if (countByState.ContainsKey(person.Value))
                        countByState[person.Value]++;
                    else
                    {
                        countByState.Add(person.Value, 0);
                        countByState[person.Value]++;
                    }
                }
            }
            Console.WriteLine("\nNumber of person in state wise count");
            foreach (var person in countByState)
            {
                Console.WriteLine($"{person.Key} : {person.Value}");
            }
            Console.WriteLine();
        }

        //Method to sort the entries in the address book by name(UC11)
        public void SortRecordsByName()
        {
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                List<string> list = addressBookObj.contactList.Keys.ToList();
                list.Sort();
                foreach (string personName in list)
                {
                    Console.WriteLine(addressBookObj.contactList[personName]);
                }
            }
        }

        //Method to sort the entries in the address book by city(UC12)
        public void SortRecordsByCity()
        {
            CreateCityDictionary();
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfDictionaryContactKeys(addressBookObj.personsCity);
                foreach (Contact contact in contactList.OrderBy(c => c.city).ToList())
                {
                    Console.WriteLine(contact);
                }
            }
        }

        //Method to sort the entries in the address book by state(UC12)
        public void SortRecordsByState()
        {
            CreateStateDictionary();
            foreach (AddressBook addressBookObj in addressContactBook.Values)
            {
                List<Contact> contactList = GetListOfDictionaryContactKeys(addressBookObj.personsState);
                foreach (Contact contact in contactList.OrderBy(c => c.state).ToList())
                {
                    Console.WriteLine(contact);
                }
            }
        }

        //Method to sort the entries in the address book by zipcode(UC12)
        public void SortRecordsByZip()
        {
            foreach (AddressBook addressBookobj in addressContactBook.Values)
            {
                foreach (Contact contact in addressBookobj.contactList.Values.OrderBy(c=>c.zip).ToList())
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }
}
