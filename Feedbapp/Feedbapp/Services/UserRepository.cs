using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Models;

namespace Feedbapp.Services
{
    public class UserRepository<T> : IRepository<T> where T : class, new()
    {
        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Func<T, bool> predicatepredicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Func<T, bool> identifier)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
