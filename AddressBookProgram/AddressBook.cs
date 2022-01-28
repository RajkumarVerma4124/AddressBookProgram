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

        //Method to edit contacts(UC3)
        public void EditContact(string personName)
        {
            //Traversing the contact list
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].firstName == personName)
                {
                    Console.WriteLine("\nChoose What You Want To Edit" +
                                "\n1.First Name" +
                                "\n2.Last Name" +
                                "\n3.Address" +
                                "\n4.City" +
                                "\n5.State" +
                                "\n6.Area Zip" +
                                "\n7.Phone Number" +
                                "\n8.Email Id"
                                );
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter A New Entry For First Name : ");
                            contactList[i].firstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter A New Entry For Last Name : ");
                            contactList[i].lastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter A New Entry For Address : ");
                            contactList[i].address = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter A New Entry For New City : ");
                            contactList[i].city = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Enter A New Entry For State : ");
                            contactList[i].state = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Enter A New Entry For Zip : ");
                            contactList[i].zip = int.Parse(Console.ReadLine());
                            break;
                        case 7:
                            Console.Write("Enter A New Entry For Phone Number : ");
                            contactList[i].phoneNumber = long.Parse(Console.ReadLine());
                            break;
                        case 8:
                            Console.Write("Enter A New Entry For Email Id : ");
                            contactList[i].emailId = Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
}
