using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Helpers
{
    public class ApiHelper
    {
        public static HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53510/api/");
            return client;
        }

        public static async Task<HttpResponseMessage> ApiRequest(Guid guid, string action, string method, object obj = null, int num = 0)
        {
            string json = JsonConvertion(obj, guid, num);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = Initial();
            var response = await HttpClientResponse(method, client, action, httpContent);
            if(!response.IsSuccessStatusCode)
            {
                var errMsg = response.Content.ReadAsStringAsync().Result;
                throw new InvalidOperationException(errMsg);
            }
            return response;
        }

        public static async Task<HttpResponseMessage> HttpClientResponse(string method, HttpClient client, string action, StringContent httpContent = null)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (method == "GET")
            {
                response = await client.GetAsync(action);
            }
            else if (method == "POST")
            {
                response = await client.PostAsync(action, httpContent);
            }
            else if (method == "PUT")
            {
                response = await client.PutAsync(action, httpContent);
            }
            else if (method == "DELETE")
            {
                response = await client.DeleteAsync(action);
            }
            return response;
        }

        public static string JsonConvertion(object obj, Guid guid, int num)
        {
            string json = string.Empty;
            if (obj != null)
            {
                json = JsonConvert.SerializeObject(obj);
            }
            else if (guid != Guid.Empty)
            {
                json = JsonConvert.SerializeObject(guid);
            }
            else if (num != 0)
            {
                json = JsonConvert.SerializeObject(num);
            }
            return json;
        }
    }
}
