using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            Console.ReadLine();

            //Adding New Contact (UC2)
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("1: Add A New Person Details"+
                                  "\n2: Add Default Contact Details" +
                                  "\n3: View All Person Details"+
                                  "\n4: View Single Person Details"+
                                  "\n5: Edit Person Details"+
                                  "\n6: Delete Person Details"+
                                  "\n7: Exit"
                                  ); 
                Console.Write("Enter The Choice From Above : ");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        //For adding multiple person(UC5)
                        //Creating a new contact with person details(UC2) 
                        AddContact.PersonDetails(addressBook);
                        break;
                    case 2:
                        //For adding multiple Person(UC5)
                        //Creating a contact with person details(UC1) 
                        DefaultContactDetails.AddPersonContact(addressBook);
                        break;
                    case 3:
                        addressBook.ViewContact();
                        break;
                    case 4:
                        //Editing a contact details with given name(UC3)
                        Console.Write("Enter The First Name Exactly To View Contact Records: ");
                        string personName = Console.ReadLine();
                        addressBook.ViewContact(personName);
                        break;
                    case 5:
                        //Editing a contact details with given name(UC3)
                        Console.Write("Enter The First Name Exactly To Edit Contact Records: ");
                        string fName = Console.ReadLine();
                        addressBook.EditContact(fName);
                        break;
                    case 6:
                        //Deleting a contact details with given name(UC4)
                        Console.Write("Enter The First Name Exactly To Delete Contact Records : ");
                        string firstName = Console.ReadLine();
                        addressBook.DeleteContact(firstName);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter A Right Choice");
                        continue;
                }
            }
        }
    }
}
