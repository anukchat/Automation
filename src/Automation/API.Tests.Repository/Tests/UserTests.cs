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
            var payLoad = TestDataHelper.ReadJsonText<LogInDTO>();
            var restURL = RestApiHelper.SetUrl(resourceUri);
            var request = RestApiHelper.CreatePostRequest(payLoad);
            var response = RestApiHelper.GetResponseStatus(restURL, request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "POST call failed, actual status is {0}", response.StatusCode);
        }
    }
}