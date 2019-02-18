using Common.Library.enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResourceAttribute : PropertyAttribute
    {
        public ResourceAttribute(string resource)
            : base("Resource",resource) { }
    }
}
