using API.Library;
using Common.Library.DTO;
using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Library;

namespace API.Tests.Repository.Tests
{
    [TestFixture]
    public class UserTests
    {
        private string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        
        [TestCase("api/users/","/ExpectedResponse/Users.json")]
        public void GetAllUsers(string resourceUri,string expectedResponse)
        {
            var input = File.ReadAllText(assemblyPath+expectedResponse).ToString();
            //Create actual test data object
            var deserial = JsonConvert.DeserializeObject<TestTDO>(input);
            var restURL = RestApiHelper.SetUrl(resourceUri);
            var request = RestApiHelper.CreateGetRequest();
            var response = RestApiHelper.GetResponse<TestTDO>(restURL, request);
            //Assert.AreEqual(deserial, response);
            //AssertHelper.PropertyValuesAreEquals(response, deserial);
            response.Should().BeEquivalentTo(deserial,"Assertion failed!!");
            //Verify the response
        }
    }
}
