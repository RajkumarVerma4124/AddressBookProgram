using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    /// <summary>
    /// Csv IO Operations Program(UC15)
    /// </summary>
    public class CsvIOOperations
    {
        //Declaring file path
        public static string csvFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\AddressBookProgram\AddressBookProgram\DataFiles\AddressBook.csv";

        //Method to serialized the data into csv file from list of contact object          
        public static void CsvSerialize(Dictionary<string, AddressBook> addressBookDictionary)
        {
            File.WriteAllText(csvFilePath, string.Empty);
            var stream = File.Open(csvFilePath, FileMode.Append);
            StreamWriter writer = new StreamWriter(stream);
            CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            foreach (AddressBook AddressBookObj in addressBookDictionary.Values)
            {
                List<Contact> contactRecord = AddressBookObj.contactList.Values.ToList();
                csvWriter.WriteRecords(contactRecord);
            }
            Console.WriteLine("\nSuccessfully Added The Records To The CSV file.");
            writer.Flush();
            writer.Close();
            stream.Close();
        }

        //Method to deserialized the data from csv file into list of contact object          
        public static void CsvDeserialize()
        {
            StreamReader streamReader = new StreamReader(csvFilePath);
            CsvReader csv = new CsvReader(streamReader, CultureInfo.InvariantCulture); 
            Console.WriteLine("Below are contents of csv file");
            List<Contact> contactRecord = csv.GetRecords<Contact>().ToList();
            foreach (Contact contact in contactRecord)
            {
                Console.WriteLine(contact);
            } 
            streamReader.Close();
        }
    }
}
 