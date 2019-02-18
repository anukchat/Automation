using API.Library;
using API.Tests.Repository.APIResource;
using Common.Library;
using Common.Library.DTO;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using Common.Library.Attributes;
using Common.Library.enums;

namespace API.Tests.Repository.Tests
{
    [TestFixture,Resource(ResourceURI.UsersURI)]
    public class UserTests: APIBase
    {
        [Test]
        public void GetAllUsersTest()
        {
            //Create actual test data object
            var expectedResponse = TestDataHelper.ReadJsonText<UserDTO>();
            var actualResponse = RestApiHelper.PerformGetRequest<UserDTO>();
            actualResponse.Should().BeEquivalentTo(expectedResponse, "Assertion failed!!");
        }

        [Test]
        public void PostUserTest()
        {
            var actualStatusCode=RestApiHelper.PerformPostRequest<LogInDTO>();
            Assert.AreEqual(HttpStatusCode.Created, actualStatusCode, "POST call failed, actual status is {0}", actualStatusCode);
        }

        [TestCase("2")]
        public void GetSingleUserTest(string resourceUri)
        {
            var expectedResponse = TestDataHelper.ReadJsonText<Datum>();
            var actualResponse = RestApiHelper.PerformGetRequest<Datum>(resourceUri);
            actualResponse.Should().BeEquivalentTo(expectedResponse, "Assertion failed!!");
        }
    }
}