using Newtonsoft.Json;
using System.IO;

namespace Common.Library
{
    public class TestDataHelper
    {
        public static T ReadJsonText<T>() where T : new()
        {
            var input = File.ReadAllText(EnvironmentManager.AssemblyPath + EnvironmentManager.TestFileName).ToString();
            return DeserializeJSON<T>(input);
        }

        private static T DeserializeJSON<T>(string input) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}