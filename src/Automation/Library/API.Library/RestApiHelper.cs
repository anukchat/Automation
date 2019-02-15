using Common.Library;
using RestSharp;
using System.IO;
using System.Net;

namespace API.Library
{
    public class RestApiHelper
    {
        public static RestClient _restClient;
        public static RestRequest _restRequest;
        public static string _basURL = "https://reqres.in/";

        public static RestClient SetUrl(string resourceURL)
        {
            var url = Path.Combine(_basURL + resourceURL);
            var _restClient = new RestClient(url);
            return _restClient;
        }

        public static RestRequest CreatePostRequest<T>(T dataObject)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddJsonBody(dataObject);
            //_restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreatePutRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            //_restRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return _restRequest;
        }

        public static RestRequest CreateDeleteRequest()
        {
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static T GetResponse<T>(RestClient restClient, RestRequest restRequest) where T : new()
        {
            return restClient.Execute<T>(restRequest).Data;
        }

        public static HttpStatusCode GetResponseStatus(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest).StatusCode;
        }

        public static DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deserializeObject;
        }

        public static T PerformGetRequest<T>(string resourceUri) where T : new()
        {
            var restURL = SetUrl(resourceUri);
            var request = CreateGetRequest();
            var response = GetResponse<T>(restURL, request);
            return response;
        }

        public static HttpStatusCode PerformPostRequest<T>(string resourcerequest) where T : new()
        {
            var payLoad = TestDataHelper.ReadJsonText<T>();
            var restURL = SetUrl(resourcerequest);
            var request = CreatePostRequest(payLoad);
            var response = GetResponseStatus(restURL, request);
            return response;
        }


    }
}