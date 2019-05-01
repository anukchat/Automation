using Common.Library.enums;
using Common.Library.NUnitProperties;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    [TestFixture(BrowserType.Chrome,Platform.Web)]
    [TestFixture(BrowserType.IE, Platform.Web)]
    public class GradeBookTests : BaseClass
    {
        private ILogIn _LogIn;

        public GradeBookTests(BrowserType browserType,Platform pType) : base(browserType,pType)
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(pType, _base);
        }

        [Test]
        public void TestProject1Presentation()
        {
            _LogIn.LogIn("teacher", "test");
            _LogIn.VerifyLogIn("Terri Teacher");
        }

        [Test]
        public void TestProject2Presentation()
        {
            
        }
    }
}