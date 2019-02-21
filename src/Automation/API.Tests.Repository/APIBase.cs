using API.Library;
using NUnit.Framework;

namespace API.Tests.Repository.Tests
{
    public class APIBase
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            var resource = TestContext.CurrentContext.Test.Properties.Get("Resource").ToString();
            RestApiHelper.ResourceString = resource;
        }
    }
}