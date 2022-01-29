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
        public static void EditPersonDetails(Contact contactList, string personName)
        {
            if (contactList.firstName == personName)
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
                        contactList.firstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter A New Entry For Last Name : ");
                        contactList.lastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter A New Entry For Address : ");
                        contactList.address = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter A New Entry For New City : ");
                        contactList.city = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter A New Entry For State : ");
                        contactList.state = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Enter A New Entry For Zip : ");
                        contactList.zip = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter A New Entry For Phone Number : ");
                        contactList.phoneNumber = long.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.Write("Enter A New Entry For Email Id : ");
                        contactList.emailId = Console.ReadLine();
                        break;
                }
            }
        }
    }
}
