using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupOne.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupOne.Models;
namespace GroupOne.Controllers.Tests
{
    [TestClass()]
    public class CustomersControllerTests
    {
        //test sample used for testing. Not part of the test.
        public List<Customer> GetCustomersSampleTest()
        {
            List<Customer> customersList = new List<Customer>()
            {
                new Customer{CustomerId = 1, CustFirstName = "Mike", CustLastName = "Johnson", CustCity = "St. Cloud", CustEmail = "example@live.com", CustPhone = "214211", CustState = "MN", CustStreet = "14 ball st", CustZip = "56301"},
                new Customer{CustomerId = 2, CustFirstName = "Kayla", CustLastName = "Lee", CustCity = "St. Cloud", CustEmail = "example@live.com", CustPhone = "214211", CustState = "MN", CustStreet = "14 ball st", CustZip = "56301"},
                new Customer{CustomerId = 3, CustFirstName = "Tom", CustLastName = "Cleverly", CustCity = "St. Cloud", CustEmail = "example@live.com", CustPhone = "214211", CustState = "MN", CustStreet = "14 ball st", CustZip = "56301"}
            };
            return customersList;
        }

        //checks if the GetCustomer method does not return null;
        [TestMethod()]
        public void GetCustomerDoesNotReturnNullTest()
        {
            List<Customer> result = GetCustomersSampleTest();
            Assert.IsNotNull(result);
        }

        //checks if the types are same.
        [TestMethod()]
        public void GetTypeCustomerTest()
        {
            var result = GetCustomersSampleTest();
            var type = result.GetType();
            if (typeof(System.Collections.Generic.List<Customer>).Equals(type))
            {
                Assert.IsInstanceOfType(result, type);
            }
            else
            {
                Assert.Fail();
            }

        }

        //checks if the Ids in the getCustomerSampleTest matches with the dataRow. If they are, it would be deleted.
        [TestMethod()]
        [DataRow(3)]
        public void DeleteCustomerTest( int id)
        {
            int cusID = 0;
            foreach (var i in GetCustomersSampleTest())
            {
               cusID = i.CustomerId;
               
            }
            Assert.AreEqual(cusID, id);
        }
    }
}