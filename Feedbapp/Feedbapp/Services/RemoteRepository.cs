using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Services
{
    public class RemoteRepository<T> : BaseRepository<T> where T : TEntity
    {
        protected HttpClient httpClient = new HttpClient();
        protected string ControllerName;

        //Change this line if you want to reference to another URL for VideoApp.Services
        private const string BaseUri = "http://feedbapp.carrasco.uruit.com/api/"; //"http://172.20.2.76:8282/api/"; //this needs to be changed to the URI of your Service URL

        public RemoteRepository(string controller)
        {
            this.ControllerName = controller;
        }

        public string FullUrl(UriString parameters, string MethodName)
        {
            List<string> returnParams = new List<string>();
            if (string.IsNullOrWhiteSpace(MethodName))
            {
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters._Params)
                    {
                        returnParams.Add(String.Format("{0}={1}", param.Key, param.Value));
                    }
                    var data = "?" + String.Join("&", returnParams.ToArray());
                    return BaseUri + this.ControllerName + "/" + MethodName + data;
                }
                else
                    return BaseUri + this.ControllerName + "/" + MethodName;
            }
            else
            {
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters._Params)
                    {
                        returnParams.Add(String.Format("{0}/{1}", param.Key, param.Value));
                    }
                    var data = "/" + String.Join("/", returnParams.ToArray());
                    return BaseUri + this.ControllerName + "/" + MethodName + data;
                }
                else
                    return BaseUri + this.ControllerName + "/" + MethodName;
            }
        }

        public async override Task<int> Add(T item)
        {
            return await this.Post(item);
        }

        public async override Task Delete(T item)
        {
            UriString uString = new UriString();
            uString.Add("id", item.Id);
            await this.Get(uString, "Delete");
        }

        public async override Task<T> Get(int identifier)
        {
            UriString uString = new UriString();
            uString.Add("id", identifier.ToString());
            return await this.Get(uString, "Get");
        }

        public async override Task<List<T>> Get()
        {
            var result = await this.httpClient.GetAsync(this.FullUrl(null, ""));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(await result.Content.ReadAsStringAsync());
            }
            return null;
        }

        protected async Task<T> Get(UriString parameters, string MethodName = null)
        {
            string url = FullUrl(parameters, MethodName);
            var result = await httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }

        protected async Task<int> Post(object obj)
        {
            string url = BaseUri + ControllerName;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var result = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override Task<T> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}