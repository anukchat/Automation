using Common.Library.enums;
using Common.Library.NUnitProperties;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    [TestFixture,TestType(ToolType.API)]
    public class GradeBookTests : BaseClass
    {
        private ILogIn _LogIn;

        public GradeBookTests()
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(base.tool, _base);
        }

        [Test]
        public void TestProject1Presentation()
        {
            _LogIn.LogIn("teacher", "test");
            //_LogIn.VerifyLogIn("Terri Teacher");
        }

        [Test]
        public void TestProject2Presentation()
        {
            _LogIn.ListUsers();
        }
    }
}