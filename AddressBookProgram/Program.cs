using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class Program
    {
        public static string bookName;
        public static void Main(string[] args)
        {
            //Displaying Welcome Message
            Console.WriteLine("Welcome To Address Book Program");
            Console.ReadLine();
            try 
            {
                //Adding New Contact (UC2)
                AddressBook addressBook = new AddressBook();
                while (true)
                {
                    Console.WriteLine("1: Add A Default Addressbook" +
                                      "\n2: Add A New Addressbook To Create Contact" +
                                      "\n3: Switch AddressBook To Work On" +
                                      "\n4: Add A New Person Details" +
                                      "\n5: Add Default Contact Details" +
                                      "\n6: View All Person Details" +
                                      "\n7: View Single Person Details" +
                                      "\n8: Edit Person Details" +
                                      "\n9: Delete Person Details" +
                                      "\n10: Show AddressBook" +
                                      "\n11: Search Person By City Or State" +
                                      "\n12: Count Person By City Or State" +
                                      "\n13: Sort Entries By Name, City, State Or Zip" +
                                      "\n14: File IO Operations" +
                                      "\n15: Json IO Operations" +
                                      "\n16: Csv IO Operations" +
                                      "\n17: Exit"
                                      );
                    Console.Write("Enter The Choice From Above : ");
                    bool flag = int.TryParse(Console.ReadLine(), out int userChoice);
                    if (flag)
                    {
                        switch (userChoice)
                        {
                            case 1:
                                //Creating a default addresbook for storing contacts(UC6)
                                bookName = "Home";
                                addressBook.AddAddressBook(bookName);
                                break;
                            case 2:
                                //Creating a new addresbook for storing contacts(UC6)
                                Console.Write("Enter A New AddressBook Name To Add Another Contacts : ");
                                string newBookName = Console.ReadLine();
                                addressBook.AddAddressBook(newBookName);
                                bookName = newBookName;
                                break;
                            case 3:
                                //Switching AddressBooks(UC6)
                                Console.Write("Enter The Name Of The AddressBook You Want To Switch To : ");
                                string newbookName = Console.ReadLine();
                                addressBook.CheckAddressBook(newbookName);
                                bookName = newbookName;
                                break;
                            case 4:
                                //For adding multiple person(UC5)
                                //Creating a new contact with person details(UC2) 
                                AddContact.PersonDetails(addressBook, bookName);
                                break;
                            case 5:
                                //For adding multiple Person(UC5)
                                //Creating a contact with person details(UC1) 
                                DefaultContactDetails.AddPersonContact(addressBook, bookName);
                                break;
                            case 6:
                                addressBook.ViewContact(bookName);
                                break;
                            case 7:
                                //Editing a contact details with given name(UC3)
                                Console.Write("Enter The Full Name Exactly To View Contact Records: ");
                                string personName = Console.ReadLine();
                                addressBook.ViewContact(personName, bookName);
                                break;
                            case 8:
                                //Editing a contact details with given name(UC3)
                                Console.Write("Enter The Full Name Exactly To Edit Contact Records: ");
                                string fName = Console.ReadLine();
                                addressBook.EditContact(fName, bookName);
                                break;
                            case 9:
                                //Deleting a contact details with given name(UC4)
                                Console.Write("Enter The Full Name Exactly To Delete Contact Records : ");
                                string firstName = Console.ReadLine();
                                addressBook.DeleteContact(firstName, bookName);
                                break;
                            case 10:
                                //Refactor to view multiple Address Book to the System.
                                foreach (var result in addressBook.GetAddressBook())
                                {
                                    Console.WriteLine(result.Key);
                                }
                                Console.Write("Enter The Name Of The AddressBook From Above List To See Contacts : ");
                                while (true)
                                {
                                    bookName = Console.ReadLine();
                                    if (addressBook.GetAddressBook().ContainsKey(bookName))
                                    {
                                        addressBook.ViewContact(bookName);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book Name Doesnt Exist");
                                        break;
                                    }
                                }
                                break;
                            case 11:
                                //Taking the input city and state from the user to search the person(UC8)
                                Console.WriteLine("\n1: Search by city \n2: Search by state");
                                int option = int.Parse(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        Console.Write("Enter name of city to search the person for : ");
                                        addressBook.SearchPersonByCity(Console.ReadLine());
                                        break;
                                    case 2:
                                        Console.Write("Enter name of state to search the person from :");
                                        addressBook.SearchPersonByState(Console.ReadLine());
                                        break;
                                    default:
                                        Console.WriteLine("Enter A Right Choice Either 1 or 2");
                                        break;
                                }
                                break;
                            case 12:
                                //Calling the display count of persons by city or state method(UC9)
                                addressBook.DisplayCountByCityandState();
                                break;
                            case 13:
                                //Calling the method to display records sorted by name, city , state or zip(UC11&UC12)
                                Console.WriteLine("\n1: Sort Records By Name \n2: Sort Records By City \n3: Sort Records By State \n4: Sort Records By Zip");
                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        addressBook.SortRecordsByName();
                                        break;
                                    case 2:
                                        addressBook.SortRecordsByCity();
                                        break;
                                    case 3:
                                        addressBook.SortRecordsByState();
                                        break;
                                    case 4:
                                        addressBook.SortRecordsByZip();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong Choice");
                                        break;
                                }
                                break;
                            case 14:
                                //Calling file read and write operations method(UC13) 
                                Console.WriteLine("\n1: Write Data Into The File \n2: Read Data From File");
                                int fileChoice = int.Parse(Console.ReadLine());
                                switch (fileChoice)
                                {
                                    case 1:
                                        FileIOOperations.WriteToFile(addressBook.addressContactBook);
                                        break;
                                    case 2:
                                        FileIOOperations.ReadFromFile();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong Choice");
                                        break;
                                }
                                break;
                            case 15:
                                //Calling json file serialize and deserialize method(UC14) 
                                Console.WriteLine("\n1: Write Data Into The Json File \n2: Read Data From Json File");
                                int jsonFileCh = int.Parse(Console.ReadLine());
                                switch (jsonFileCh)
                                {
                                    case 1:
                                        JsonIOOperations.JsonSerialize(addressBook.addressContactBook);
                                        break;
                                    case 2:
                                        JsonIOOperations.JsonDeSerialize();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong Choice");
                                        break;
                                }
                                break;
                            case 16:
                                //Calling csv file serialize and deserialize method(UC15) 
                                Console.WriteLine("\n1: Write Data Into The Csv File \n2: Read Data From Csv File");
                                int csvFileCh = int.Parse(Console.ReadLine());
                                switch (csvFileCh)
                                {
                                    case 1:
                                        CsvIOOperations.CsvSerialize(addressBook.addressContactBook);
                                        break;
                                    case 2:
                                        CsvIOOperations.CsvDeserialize();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong Choice");
                                        break;
                                }
                                break;
                            case 17:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter A Right Choice");
                                continue;
                        }
                    }
                    else
                        Console.WriteLine("Enter Some Input Value");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
