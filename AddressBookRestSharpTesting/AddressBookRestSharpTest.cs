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

        //Method to get all contact details from server using get requests(UC16)
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
                Assert.AreEqual(7, resContact.Count);
                //Checking the response statuscode
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                foreach (var contact in resContact)
                {
                    Console.WriteLine("Contact Id : " + contact.Id + " " + contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Method to add a json object to json server using post request(UC17)
        public IRestResponse AddToJsonServer(JsonObject jsonObject)
        {
            IRestResponse response = default;
            try
            {
                RestRequest request = new RestRequest("/contacts", Method.POST);
                //Adding type as json in request and passing the json object as a body of request
                request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
                //Execute the request
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        //Method to add a contact to json object(UC17)
        public List<JsonObject> AddContactToJsonObject(string fName, string lName, string address, string city, string state, int zip, long phNumber, string emailId, List<JsonObject> contactList)
        {
            try
            {
                JsonObject json = new JsonObject();
                json.Add("FirstName", fName);
                json.Add("LastName", lName);
                json.Add("PhoneNumber", phNumber);
                json.Add("Address", address);
                json.Add("City", city);
                json.Add("State", state);
                json.Add("ZipCode", zip);
                json.Add("EmailId", emailId);
                //Adding json object to list
                contactList.Add(json);
                return contactList;
            }
            catch(Exception ex)
            {
                throw ex;
            }   
        }

        //Test method to add multiple contact to the addressbook using json server(UC17-TC17.1)
        [TestMethod]
        public void AddingMulContactsToABFileUsingJsonServer()
        {
            try
            {
                //List for storing contacts using json objects
                List<JsonObject> contactList = new List<JsonObject>();
                AddContactToJsonObject("Mahipal", "Purohit", "Powai", "Mumbai", "Maharashtra", 400123, 9513574561, "mahipal@gmail.com", contactList);
                AddContactToJsonObject("Yash", "Sarjekar", "Koliwada", "Pune", "Maharashtra", 400741, 9553174561, "yash@gmail.com", contactList);
                var contactLists = AddContactToJsonObject("Ankit", "Varma", "Powai", "Mumbai", "Maharashtra", 400321, 9513554761, "ankit@gmail.com", contactList);
                contactList.ForEach((contact) =>
                {
                    AddToJsonServer(contact);
                });
                //Calling the get all contact method to check if its added or not
                IRestResponse response = GetAllContacts();
                //Convert json object to contact object
                var res = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
                res.ForEach((contact) =>
                {
                    Console.WriteLine("Contact Id : " + contact.Id + " " + contact);
                });
                //Checking the response statuscode 200-ok
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
