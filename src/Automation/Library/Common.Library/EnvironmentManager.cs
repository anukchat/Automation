using NUnit.Framework;
using System.IO;

namespace Common.Library
{
    public static class EnvironmentManager
    {
        public static string AssemblyPath { get; } = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Data/";

        public static string TestFileName { get; } = TestContext.CurrentContext.Test.MethodName.ToString() + "_Data.json";
    }
}