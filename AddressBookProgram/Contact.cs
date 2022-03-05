using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace AddressBookProgram
{
    public class Contact
    {
        //Declaring contact details properties
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailId { get; set; }

        //Overiding the equals method to check the person details(UC7)
        public override bool Equals(object obj)
        {
            Contact contact = (Contact)obj;
            if (contact == null)
                return false;
            else
                return FirstName.Equals(contact.FirstName) && LastName.Equals(contact.LastName);
        }

        //orveriding hashcode method
        public override int GetHashCode()
        {
            return default;
        }

        //Overiding string method to display the values serch for city and state(UC8) 
        public override string ToString()
        {
            return $"First Name : {FirstName} \tLast Name : {LastName} \nCity : {City} \tState : {State} \tZip : {Zip} \nEmail : {EmailId}  \nPhone Number : {PhoneNumber}\n";
        }
    }
}
