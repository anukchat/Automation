using Common.Library;
using Common.Library.Attributes;
using NUnit.Framework;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace API.Library
{
    public class RestApiHelper
    {
        public static string ResourceString {get;set;}

        public static RestClient SetUrl(string query)
        {         
            var resource = TestContext.CurrentContext.Test.Properties["Resource"];
            var url = Path.Combine(EnvironmentManager.BaseURL+ResourceString+query);
            RestClient _restClient = new RestClient(url);
            return _restClient;
        }

        private string SelectResource(string resource)
        {
            return null;
        }
        public static RestRequest CreatePostRequest<T>(T dataObject)
        {
            RestRequest _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddJsonBody(dataObject);
            //_restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static double ExecuteRest(int numberOfLoads)
        {
            var client = SetUrl("");
            
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for(int i=0;i< numberOfLoads;i++)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                RestRequest _restRequest = new RestRequest();
                _restRequest.AddHeader("Accept", "application/json");
                
                var response=client.ExecuteAsync(_restRequest,(rp)=>
                {
                    if (rp.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("ERROR");
                    }

                });
            }
            watch.Stop();
            
            return watch.Elapsed.TotalMilliseconds;
            //Debug.WriteLine("Elapsed Time {0} ", watch.Elapsed.Seconds);

        }

        public static RestRequest CreatePutRequest(string jsonString)
        {
            RestRequest _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreateGetRequest()
        {
            RestRequest _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            //_restRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return _restRequest;
        }

        public static RestRequest CreateDeleteRequest()
        {
            RestRequest _restRequest = new RestRequest(Method.DELETE);
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

        public static T PerformGetRequest<T>(string query="") where T : new()
        {
            var restURL = SetUrl(query);
            var request = CreateGetRequest();
            var response = GetResponse<T>(restURL, request);
            return response;
        }

        public static HttpStatusCode PerformPostRequest<T>(string query="") where T : new()
        {
            var payLoad = TestDataHelper.ReadJsonText<T>();
            var restURL = SetUrl(query);
            var request = CreatePostRequest(payLoad);
            var response = GetResponseStatus(restURL, request);
            return response;
        }


    }
}