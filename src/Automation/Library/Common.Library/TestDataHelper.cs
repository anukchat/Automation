using Newtonsoft.Json;
using System.IO;

namespace Common.Library
{
    public class TestDataHelper
    {
        public static T ReadJsonText<T>(string dataFile=null) where T : new()
        {
            if (dataFile == null)
                dataFile = EnvironmentManager.TestFileName;
            var input = File.ReadAllText(EnvironmentManager.AssemblyPath + dataFile).ToString();
            return DeserializeJSON<T>(input);
        }

        private static T DeserializeJSON<T>(string input) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}