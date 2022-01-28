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
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phoneNumber;
        public string emailId;

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
