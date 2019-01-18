using System;
using Common.Library.enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Pages.Contracts;

namespace Selenium.Page.Repository
{
    public class SeleniumBase : IBase
    {
        public static IWebDriver Driver { get; set; }

        public SeleniumBase()
        {
            Driver = GetDriver(BrowserType.Chrome);
        }        

        public void InitialSetup()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("google.com");
        }
        private IWebDriver GetDriver(BrowserType browserType)
        {
            IWebDriver _driver=null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;
                case BrowserType.IE:
                    _driver = new InternetExplorerDriver();
                    break;
            }
            return _driver;
        }

    }
}