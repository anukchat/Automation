using Common.Library.enums;
using NUnit.Framework;
using System;

namespace Common.Library.NUnitProperties
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TestTypeAttribute : PropertyAttribute
    {
        public TestTypeAttribute(Platform tool)
            : base(tool) { }
    }
}