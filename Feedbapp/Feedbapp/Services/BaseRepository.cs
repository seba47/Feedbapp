using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;

namespace Feedbapp.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : TEntity
    {
        public abstract Task<T> Get(UriString parameters, string MethodName = null, string ControllerName = null);

        public abstract Task<T> Get(int identifier);

        public abstract Task<T> Update(T item);
        public abstract Task Delete(T item);

        public abstract Task<T> Add(T item);

        public BaseRepository(string BaseAddress)
        {
            //HttpClientHandler handle = new HttpClientHandler();
            //httpClient = new HttpClient(handle);
            //httpClient.BaseAddress = new Uri(BaseUri);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36");
        }

        public BaseRepository()
        {
            //HttpClientHandler handle = new HttpClientHandler();
            //httpClient = new HttpClient(handle);
            //httpClient.BaseAddress = new Uri(BaseUri);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36");
        }

    }
    public class UriString : Dictionary<string, string>
    {
        public Dictionary<string, string> _Params
        {
            get
            {
                return this;
            }
        }

    }
}
