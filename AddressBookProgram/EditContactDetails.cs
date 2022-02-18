using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class EditContactDetails
    {
        //Method To Edit Single Peron Details
        public static void EditPersonDetails(KeyValuePair<string, Contact> contactList, string personName)
        {
            if (contactList.Key.Equals(personName))
            {
                Console.WriteLine("\nChoose What You Want To Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Area Zip \n7.Phone Number \n8.Email Id");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter A New Entry For First Name : ");
                        contactList.Value.FirstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter A New Entry For Last Name : ");
                        contactList.Value.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter A New Entry For Address : ");
                        contactList.Value.Address = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter A New Entry For New City : ");
                        contactList.Value.City = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter A New Entry For State : ");
                        contactList.Value.State = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Enter A New Entry For Zip : ");
                        contactList.Value.Zip = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter A New Entry For Phone Number : ");
                        contactList.Value.PhoneNumber = long.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.Write("Enter A New Entry For Email Id : ");
                        contactList.Value.EmailId = Console.ReadLine();
                        break;
                }
                Console.WriteLine("Edited The Contact Succesfully\n");
            }
        }
    }
}
