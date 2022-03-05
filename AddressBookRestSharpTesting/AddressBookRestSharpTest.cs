using AddressBookProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace AddressBookRestSharpTesting
{
    [TestClass]
    public class AddressBookRestSharpTest
    {
        //Initializing the restclient as null
        RestClient client = null;
        [TestInitialize]
        //Setup base 
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }

        //Method to get all contact details from server(UC16)
        public IRestResponse GetAllContacts()
        {
            IRestResponse response = default;
            try
            {
                //Get request from json server
                RestRequest request = new RestRequest($"/contacts", Method.GET);
                //Requesting server and executing the gotten response
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        //Test method to get all person details from addressbook json server(UC16-TC16.1)
        [TestMethod]
        public void TestMethodToGetAllPersons()
        {
            try
            {
                //calling get all persom method 
                IRestResponse response = GetAllContacts();
                //converting response to list of objects
                var resContact = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
                //Check whether all contents are received or not
                Assert.AreEqual(4, resContact.Count);
                //Checking the response statuscode
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                foreach (var contact in resContact)
                {
                    Console.WriteLine("Contact Id : "+contact.Id+" "+contact);
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
