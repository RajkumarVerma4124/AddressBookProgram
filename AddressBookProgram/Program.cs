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
                                  "\n2: View Person Details"+
                                  "\n3: Exit"
                                  ); 
                Console.Write("Enter The Choice From Above : ");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        //Creating a contact with person details(UC1) 
                        AddContact.PersonDetails(addressBook);
                        break;
                    case 2:
                        addressBook.ViewContact();
                        break;
                    case 3:
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
