using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class DefaultContactDetails
    {
        public static void AddPersonContact(AddressBook addressBook)
        {
            addressBook.AddContactDetails("Raj", "Verma", "Ghansoli", "NaviMumbai", "Maharashtra", 456123, 9517534561, "abc123@gmail.com");
            addressBook.AddContactDetails("Yash", "Verma", "Sec-45", "Noida", "Delhi", 789456, 7412589631, "abc456@gmail.com");
            addressBook.AddContactDetails("Ajay", "Matkar", "Chembur", "Mumbai", "Maharashtra", 125463, 8523697412, "abc789@gmail.com");
        }
    }
}
