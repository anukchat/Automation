using Common.Library.enums;
using Common.Library.NUnitProperties;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    [TestFixture(BrowserType.Chrome,ToolType.Selenium)]
    public class LogInTests : BaseClass
    {
        private ILogIn _LogIn;

        public LogInTests(BrowserType browserType, ToolType toolType) :base(browserType,toolType)
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(toolType, _base);
        }

        [Test]
        public void TestMethod1()
        {
            _LogIn.LogIn("student", "test");
            _LogIn.VerifyLogIn("Sam Student");
        }

        [Test]
        public void TestMethod2()
        {
        }
    }
}