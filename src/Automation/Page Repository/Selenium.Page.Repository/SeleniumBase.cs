using OpenQA.Selenium;
using Pages.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Page.Repository
{
    public class SeleniumBase : IBase
    {
        public IWebDriver Driver;

        public SeleniumBase()
        {
            
        }
        public void InitialSetup()
        {
            throw new NotImplementedException();
        }
    }
}
