using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Models;

namespace Feedbapp.Services
{
    public class RestService
    {        
        public async Task<UserModel> GetUser(string username,string password)
        {
            HttpClient client = new HttpClient();
            
            string content="";
            string RestUrl = "http://172.20.2.76:8282/api/User/Get?username={0}";
            var uri = new Uri(string.Format(RestUrl, username));

            var response = await client.GetAsync(uri.ToString());
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                //JsonConvert.DeserializeObject<List<TodoItem>>(content);
            }
            UserModel um = (UserModel)Newtonsoft.Json.JsonConvert.DeserializeObject(content, typeof(UserModel));
            return um;
        }

        public string GetUser()
        {
            var client = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8282/api/User/Get?username=sebaa");
            string response = client.ToString();
            return response;
        }
        
    }
}
