using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Contracts;
using System;

namespace Selenium.Page.Repository.Pages
{
    public class SeleniumLogInPage : ILogIn
    {
        private IWebDriver _driver;

        public SeleniumLogInPage(SeleniumBase driver)
        {
            this._driver = driver.Driver;
        }

        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void LogIn(string userName, string password)
        {
            var usernameBox = _driver.FindElement(By.Id("login_username"));
            var passwordBox = _driver.FindElement(By.Id("login_password"));
            var logInButton = _driver.FindElement(By.XPath("//*[@id=\"login\"]/div[4]/input"));

            usernameBox.SendKeys(userName);
            passwordBox.SendKeys(password);
            logInButton.Click();
        }

        public void VerifyForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void VerifyLogIn(string expectedUser)
        {
            var userDisplayed = _driver.FindElement(By.ClassName("usertext"));
            Assert.AreEqual(expectedUser, userDisplayed.Text, "LogIn failed!! Actual and expected user do not match!!");
        }
    }
}