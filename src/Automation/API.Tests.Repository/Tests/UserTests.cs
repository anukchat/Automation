using API.Library;
using Common.Library;
using Common.Library.DTO;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace API.Tests.Repository.Tests
{
    [TestFixture]
    public class UserTests
    {
        [TestCase("api/users/")]
        public void GetAllUsersTest(string resourceUri)
        {
            //Create actual test data object
            var expectedResponse = TestDataHelper.ReadJsonText<UserDTO>();
            var actualResponse = RestApiHelper.PerformGetRequest<UserDTO>(resourceUri);
            actualResponse.Should().BeEquivalentTo(expectedResponse, "Assertion failed!!");
        }

        [TestCase("api/users/")]
        public void PostUserTest(string resourceUri)
        {
            var actualStatusCode=RestApiHelper.PerformPostRequest<LogInDTO>(resourceUri);
            Assert.AreEqual(HttpStatusCode.Created, actualStatusCode, "POST call failed, actual status is {0}", actualStatusCode);
        }

        [TestCase("api/users/2")]
        public void GetSingleUserTest(string resourceUri)
        {
            var expectedResponse = TestDataHelper.ReadJsonText<Datum>();
            var actualResponse = RestApiHelper.PerformGetRequest<Datum>(resourceUri);
            actualResponse.Should().BeEquivalentTo(expectedResponse, "Assertion failed!!");
        }
    }
}