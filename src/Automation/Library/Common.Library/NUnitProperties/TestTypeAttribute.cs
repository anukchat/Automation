using System;
using Common.Library.enums;
using NUnit.Framework;

namespace Common.Library.NUnitProperties
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TestTypeAttribute : PropertyAttribute
    {
        public TestTypeAttribute(ToolType tool)
            : base(tool) { }
    }

}
