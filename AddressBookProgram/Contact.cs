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
        public readonly string firstName;
        public readonly string lastName;
        public readonly string address;
        public readonly string city;
        public readonly string state;
        public readonly int zip;
        public readonly long phoneNumber;
        public readonly string emailId;

        public Contact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string emailId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip; 
            this.phoneNumber = phoneNumber;
            this.emailId = emailId;
        }
    }
}
