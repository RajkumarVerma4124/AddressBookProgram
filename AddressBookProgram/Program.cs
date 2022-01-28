using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class Program
    {
        //Initializing variable
        public static int count=0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            Console.ReadLine();

            //Creating a contact with person details(UC1)
            AddressBook addressBook = new AddressBook();
            addressBook.AddContactDetails("Raj", "Verma", "Ghansoli", "NaviMumbai", "Maharashtra", 401546, 9517534567, "abc123@gmail.com");
            addressBook.ViewContact();
        }
    }
}
