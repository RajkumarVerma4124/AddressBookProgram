using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    /// <summary>
    /// Json IO Operation Program(UC14)
    /// </summary>
    public class JsonIOOperations
    {
        //Declaring file path
        public static string filePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\AddressBookProgram\AddressBookProgram\DataFiles\AddressBook.Json";

        //Method to create object for json(UC14)
        public static void JsonSerialize(Dictionary<string, AddressBook> addressBookContact)
        {
            //converting the addressbook dictionary object to json string
            string jsonString = JsonConvert.SerializeObject(addressBookContact);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("\nSuccessfully added the data to json file.");
        }

        //Method to read json file by converting json object to addressbook object(UC14)
        public static void JsonDeSerialize()
        {
            Console.WriteLine("Below are contents of json file");
            var addressBookObject = JsonConvert.DeserializeObject<Dictionary<string, AddressBook>>(File.ReadAllText(filePath));
            foreach (var addressBook in addressBookObject)
            {
                Console.WriteLine("\nAddressBook Name: {0}", addressBook.Key);
                foreach (var person in addressBook.Value.contactList.Values)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
