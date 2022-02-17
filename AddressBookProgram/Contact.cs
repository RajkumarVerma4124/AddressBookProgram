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

        //Parameterized constructor to initialize the addressbook values
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

        //Overiding the equals method to check the person details(UC7)
        public override bool Equals(object obj)
        {
            Contact contact = (Contact)obj;
            if (contact == null)
                return false;
            else
                return firstName.Equals(contact.firstName) && lastName.Equals(contact.lastName);
        }

        //orveriding hashcode method
        public override int GetHashCode()
        {
            return default;
        }

        //Overiding string method to display the values serch for city and state(UC8) 
        public override string ToString()
        {
            return $"First Name : {firstName} \tLast Name : {lastName} \nCity : {city} \tState : {state} \tZip : {zip} \nEmail : {emailId}  \nPhone Number : {phoneNumber}\n";
        }
    }
}
