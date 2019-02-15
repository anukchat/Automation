using Common.Library.enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Pages.Contracts;

namespace Selenium.Page.Repository
{
    public class SeleniumBase : IBase
    {
        public IWebDriver Driver { get; set; }

        private readonly BrowserType _browserType;

        public SeleniumBase(BrowserType browser)
        {
            this._browserType = browser;
        }

        public void InitialSetup()
        {
            Driver = GetDriver(_browserType);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://qa.moodle.net/");
        }

        private IWebDriver GetDriver(BrowserType browserType)
        {
            IWebDriver _driver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;

                case BrowserType.IE:
                    InternetExplorerOptions _ieOptions = new InternetExplorerOptions();
                    _ieOptions.AddAdditionalCapability("INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS", true);
                    _ieOptions.EnsureCleanSession = true;
                    _driver = new InternetExplorerDriver(_ieOptions);
                    break;
            }
            return _driver;
        }

        public void FinalTearDown()
        {
            Driver.Quit();
        }
    }
}