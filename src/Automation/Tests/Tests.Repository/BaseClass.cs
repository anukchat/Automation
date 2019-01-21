using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Tests.Repository
{
    public class BaseClass
    {
        private IBase _base;

        public BaseClass()
        {
            _base = BaseFactory.GetInstance<IBase>(ToolType.Selenium);
        }
        [OneTimeSetUp]
        public void SetUp()
        {
            _base.InitialSetup();
        }

    }
}