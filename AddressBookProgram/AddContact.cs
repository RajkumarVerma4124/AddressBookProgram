using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddContact
    {
        public static void PersonDetails(AddressBook addressBook, string bookName)
        {
            //Creating a contact with person details(UC1)
            Console.Write("Enter Your First Name : ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Your Last Name : ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Your Home Address : ");
            string address = Console.ReadLine();
            Console.Write("Enter Your City Name : ");
            string city = Console.ReadLine();
            Console.Write("Enter Your State Name : ");
            string state = Console.ReadLine();
            Console.Write("Enter Your Area Zip Code : ");
            int zip = int.Parse(Console.ReadLine());
            Console.Write("Enter Your Phone Number : ");
            long phoneNum = long.Parse(Console.ReadLine());
            Console.Write("Enter Your EmailId : ");
            string emailId = Console.ReadLine();

            //User Data Entry            
            addressBook.AddContactDetails(firstName, lastName, address, city, state, zip, phoneNum, emailId, bookName);
            Console.ReadLine();
        }
    }
}
