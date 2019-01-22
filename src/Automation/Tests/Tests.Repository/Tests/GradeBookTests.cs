using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Tests.Repository
{
    [TestFixture]
    public class GradeBookTests : BaseClass
    {
        private ILogIn _LogIn;

        public GradeBookTests()
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(ToolType.Selenium, _base);
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