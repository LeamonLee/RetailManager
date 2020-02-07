using RMWpfUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RMWpfUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _APIClient;
        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            // needs to add System.Configuration reference
            string strAPIURL = ConfigurationManager.AppSettings["apiBaseURL"];

            _APIClient = new HttpClient();
            _APIClient.BaseAddress = new Uri(strAPIURL);
            _APIClient.DefaultRequestHeaders.Accept.Clear();
            _APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));        // Expects the response in Json format

        }

        public async Task<AuthenticatedUserInfo> Authenticate(string strUsername, string strPassword)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", strUsername),
                new KeyValuePair<string, string>("password", strPassword)
            });

            // We specify relative url in here since the main address may change in the future.
            using (HttpResponseMessage response = await _APIClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    // ReadAsAsync extension method needs to install AspNet.WebApi.Client Package from Nuget.
                    var result = await response.Content.ReadAsAsync<AuthenticatedUserInfo>();
                    return result;
                }

                // Throw the reason why the request is failed
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
