using NUnit.Framework;
using Pages.Contracts;
using System;
using Selenium.Library.ObjectRepository.WebRepository;
using Selenium.Library.Extensions;
using OpenQA.Selenium;

namespace Selenium.Page.Repository.Pages
{
    public class SeleniumLogInPage : ILogIn
    {
        private IWebDriver _driver;

        public SeleniumLogInPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void ForgotPassword()
        {
            _driver.GetElement(LogInLocator.LogInPasswordBoxID);
        }

        public void ListUsers()
        {
            throw new NotImplementedException();
        }

        public void LogIn(string userName, string password)
        {
            var usernameBox = _driver.GetElement(LogInLocator.LogInUserNameBoxID);
            var passwordBox = _driver.GetElement(LogInLocator.LogInPasswordBoxID);
            var logInButton = _driver.GetElement(LogInLocator.LogInButtonXPath);

            usernameBox.EnterText(userName);
            passwordBox.EnterText(password);
            logInButton.ClickElement();

            //Fetch the username logged in and map to LogInTdo

        }

        public void VerifyForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void VerifyLogIn(string expectedUser)
        {
            var userDisplayed = _driver.GetElement(LogInLocator.DisplayedUserCSSSelector);
            Assert.AreEqual(expectedUser, userDisplayed.Text, "LogIn failed!! Actual and expected user do not match!!");
        }
    }
}