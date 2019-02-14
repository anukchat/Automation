using Common.Library.enums;
using Common.Library.NUnitProperties;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    [TestFixture, TestType(ToolType.Selenium)]
    public class LogInTests : BaseClass
    {
        private ILogIn _LogIn;

        public LogInTests()
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(tool, _base);
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