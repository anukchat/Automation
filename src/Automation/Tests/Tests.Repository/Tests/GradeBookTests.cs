using Common.Library.enums;
using Common.Library.NUnitProperties;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    [TestFixture(BrowserType.Chrome,ToolType.Selenium)]
    [TestFixture(BrowserType.IE, ToolType.Selenium)]
    public class GradeBookTests : BaseClass
    {
        private ILogIn _LogIn;

        public GradeBookTests(BrowserType browserType,ToolType toolType) : base(browserType,toolType)
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(toolType, _base);
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