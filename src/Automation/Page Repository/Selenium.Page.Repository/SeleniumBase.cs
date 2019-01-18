using OpenQA.Selenium;
using Pages.Contracts;

namespace Selenium.Page.Repository
{
    public class SeleniumBase : IBase
    {
        public IWebDriver Driver { get; set; }

        public SeleniumBase()
        {
        }

        public void InitialSetup()
        {
            //Driver = GetDriver();
        }
    }
}