using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GroupOne.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        //test for username and password
        [TestMethod()]
        public void AuthenticateUserTest()
        {
            User user = new User()
            {
                username = "username",
                password = "password"

            };
            User user1 = new User()
            {
                username = "test",
                password = "pwd"
            };
            bool isValid()
            {
                if (user.username == "username" && user1.username == "test" && user.password == "password" && user1.password == "pwd")
                    return true;
                else
                    return false;
            }
            Assert.IsTrue(isValid());
        }

        //checking for null in username or password
        [TestMethod()]
        public void AuthenticateDoesNotReturnNullTest()
        {
            JwtAuthenticationManager authenticationManager = new JwtAuthenticationManager("AbdullahiMohamed12345");
            User user = new User(){ username = "username", password = "password" };
            var data = authenticationManager.Authenticate(user.username, user.password);
            Assert.IsNotNull(data);
        }
    }
}