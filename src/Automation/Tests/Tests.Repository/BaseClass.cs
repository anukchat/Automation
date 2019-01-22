using Common.Library.enums;
using NUnit.Framework;
using Pages.Contracts;
using Pages.Factory;

namespace Tests.Repository
{
    public class BaseClass
    {
        protected IBase _base;

        public BaseClass()
        {
            _base = BaseFactory.GetInstance<IBase>(ToolType.Selenium);
            _base.InitialSetup();
        }

    }
}