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
                Assert.AreEqual(6, resContact.Count);
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
                //Converting json object to contact object
                var contactsList = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
                contactsList.ForEach((contact) =>
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

        //Test method to update contacts of addressbook using json server(UC18-TC18.1)
        [TestMethod]
        public void UpdateContactOfABFileUsingJsonServer()
        {
            try
            {
                //Setting rest request to url and setting method to put to update contacts
                RestRequest request = new RestRequest("/contacts/5", Method.PUT);
                //object for json
                JsonObject json1 = new JsonObject();
                //Adding new person details to json object
                json1.Add("FirstName", "Raj");
                json1.Add("LastName", "Verma");
                json1.Add("PhoneNumber", 9517534561);
                json1.Add("Address", "Vashi");
                json1.Add("City", "NaviMumbai");
                json1.Add("State", "Maharashra");
                json1.Add("Zip", 456025);
                json1.Add("EmailId", "rajkumar@gmail.com");
                //Adding type as json in request and passing the json object as a body of request
                request.AddParameter("application/json", json1, ParameterType.RequestBody);
                //execute the request
                IRestResponse response = client.Execute(request);
                //deserialize json object to person class  object
                var contact = JsonConvert.DeserializeObject<Contact>(response.Content);
                //Checking the response statuscode
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                //Printing updated contact
                Console.WriteLine("Contact Id : "+contact.Id+" "+contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Test method to delete contact based on id using json server(UC19-TC19.1)
        [TestMethod]
        public void DeleteContactsUsingJsonServer()
        {
            try
            {
                //Setting rest request to url and setting method to delete for deleting particular contact record using id
                RestRequest request = new RestRequest("/contacts/7", Method.DELETE);
                //Executing the request
                IRestResponse response = client.Execute(request);
                //Calling the get all contact method to check if its added or not
                IRestResponse restResponse = GetAllContacts();
                //Converting json object to contact object
                var contactList = JsonConvert.DeserializeObject<List<Contact>>(restResponse.Content);
                contactList.ForEach((contact) =>
                {
                    Console.WriteLine("Contact Id : "+contact.Id+" "+contact);
                });
                //Checking the response statuscode
                Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
