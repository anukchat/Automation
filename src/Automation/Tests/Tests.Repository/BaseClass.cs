using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Selenium.Tests.Repository
{
    public class BaseClass
    {
        protected IBase _base;
        protected ToolType tool = (ToolType)TestContext.CurrentContext.Test.Properties.Get("TestType");
        public BaseClass()
        {
            _base = BaseFactory.GetInstance<IBase>(tool);
            _base.InitialSetup();
        }
    }
}