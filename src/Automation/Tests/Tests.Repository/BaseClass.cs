using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    public class BaseClass
    {
        protected IBase _base;

        public BaseClass(): this(BrowserType.Chrome)
        { }

        public BaseClass(BrowserType browser):this(browser,Platform.Web)
        { }

        public BaseClass(BrowserType browser,Platform toolType)
        {
            _base = BaseFactory.GetInstance<IBase>(toolType, browser);
            _base.InitialSetup();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _base.FinalTearDown();
        }

    }
}