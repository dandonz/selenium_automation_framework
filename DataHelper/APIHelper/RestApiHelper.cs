using System;
using System.Collections.Generic;
using Utilities;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace DataHelper
{
    public class RestApiHelper : IRestAPIHelper
    {
        public string GetData(Dictionary<string, string> parameters)
        {
            string baseurl = parameters.ContainsKey(API_PARAMETER.API_BASE_URL) ? parameters[API_PARAMETER.API_BASE_URL] : string.Empty;
            string request = parameters.ContainsKey(API_PARAMETER.API_REQUEST) ? parameters[API_PARAMETER.API_REQUEST] : string.Empty;
            string username = parameters.ContainsKey(API_PARAMETER.API_USER_NAME) ? parameters[API_PARAMETER.API_USER_NAME] : string.Empty;
            string password = parameters.ContainsKey(API_PARAMETER.API_PASSWORD) ? parameters[API_PARAMETER.API_PASSWORD] : string.Empty;
            var client = new RestClient(baseurl)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };

            var restRequest = new RestRequest(request);
            var restResponse = client.Execute(restRequest);

            if (restResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                return restResponse.Content;
            }
            return string.Empty; 
        }
    }
}
