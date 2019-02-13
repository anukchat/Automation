using API.Library;
using Common.Library.DTO;
using NUnit.Framework;
using Pages.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Page.Repository.Pages
{
    public class APILogIn : ILogIn
    {
        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void ListUsers()
        {
            
            var restURL = RestApiHelper.SetUrl("api/users?page=2");
            var request = RestApiHelper.CreateGetRequest();
            var response = RestApiHelper.GetResponse<List<TestTDO>>(restURL, request);
        }

        public void LogIn(string userName, string password)
        {
            var jsonObject = new LogInDTO()
            {
                Name = "Anukool",
                Job = "Test Engineer"
            };
            ////var jsonString = @"{
            //                    ""name"": ""Anukool"" ,
            //                    ""job"":""Test Engineer""
            //                   }";
            var restURL =RestApiHelper.SetUrl("api/users/");
            var request =RestApiHelper.CreatePostRequest(jsonObject);
            var response = RestApiHelper.GetResponseStatus(restURL, request);

            //LogInDTO logInDtp = RestApiHelper.GetContent<LogInDTO>(response);
            Assert.AreEqual("completed", response.StatusCode, "POST call failed, actual status is {0}", response.StatusCode);
        }

        public void VerifyForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void VerifyLogIn(string expectedUser)
        {
            throw new NotImplementedException();
        }
    }
}
