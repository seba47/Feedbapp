using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Services
{
    public interface IRepository<T> where T : TEntity
    {
        Task<T> Get(int identifier);

        Task<List<T>> Get();

        Task<T> Update(T item);

        Task Delete(T item);

        Task<int> Add(T item);
    }
}