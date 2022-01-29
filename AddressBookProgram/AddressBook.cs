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
            int count = 1;
            foreach (var contact in contactList)
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
        public void ViewContact(string personName)
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].firstName == personName)
                {
                    Console.WriteLine("First Name : {0} || Last Name : {1}", contactList[i].firstName, contactList[i].lastName);
                    Console.WriteLine("Address : {0} ", contactList[i].address);
                    Console.WriteLine("City Name : {0} || State Name : {1} || ZipCode : {2}", contactList[i].city, contactList[i].state, contactList[i].zip);
                    Console.WriteLine("Phone Number : {0}", contactList[i].phoneNumber);
                    Console.WriteLine("Email Id : {0} ", contactList[i].emailId);
                    Console.ReadLine();
                }
            }           
        }

        //Method to edit contacts(UC3)
        public void EditContact(string personName)
        {
            
            //Traversing the contact list
            for (int i = 0; i < contactList.Count; i++)
            {
                EditContactDetails.EditPersonDetails(contactList[i], personName);
            }
        }
        //Method to delete contact details using first name(UC4)
        public void DeleteContact(string personName) 
        {
            for(int i = 0; i < contactList.Count; i++)
            {
                if(contactList[i].firstName == personName)
                {
                    Console.WriteLine("Record Of {0} Deleted Successfully", contactList[i].firstName);
                    contactList.RemoveAt(i);
                }
            }
           
        }
    }
}
