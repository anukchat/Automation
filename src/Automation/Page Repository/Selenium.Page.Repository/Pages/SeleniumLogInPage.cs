using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Contracts;
using Selenium.Library.Extensions;
using Selenium.Library.ObjectRepository.WebRepository;
using System;

namespace Selenium.Page.Repository.Pages
{
    public class SeleniumLogInPage : ILogIn
    {
        private IWebDriver _driver;

        public SeleniumLogInPage(SeleniumBase _base)
        {
            this._driver = _base.Driver;
        }

        public void ForgotPassword()
        {
            _driver.GetElement(LogInLocator.LogInPasswordBoxID);
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