using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Tests.Repository
{
    [TestFixture]
    public class LogInTests : BaseClass
    {
        private ILogIn _LogIn;

        public LogInTests()
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(ToolType.Selenium, _base);
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