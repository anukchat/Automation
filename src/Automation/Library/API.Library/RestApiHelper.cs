using RestSharp;
using System.IO;

namespace API.Library
{
    public class RestApiHelper<T>
    {
        public RestClient _restClient;
        public RestRequest _restRequest;
        public string _basURL = "https://reqres.in/";

        public RestClient SetUrl(string resourceURL)
        {
            var url = Path.Combine(_basURL + resourceURL);
            var _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreatePostRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }
        public RestRequest CreatePutRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deserializeObject;
        }
    }
}