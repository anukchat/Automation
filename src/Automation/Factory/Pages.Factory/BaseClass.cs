using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;

namespace Pages.Factory
{
    public class BaseClass
    {
        private IBase _base;

        [OneTimeSetUp]
        public void SetUp()
        {
            _base = BaseFactory.GetInstance<IBase>(ToolType.Selenium);
            _base.InitialSetup();
        }
    }
}