using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using SQLite;

namespace Feedbapp.Services
{
    public class LocalRepository<T> : BaseRepository<T> where T : TEntity, new()
    {
        protected SQLiteConnection database;
        
        public LocalRepository()
        {

            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<T>();
        }

        public async override Task<int> Add(T item)
        {
            var func = database.Insert(item);
            return await Task.Run(() => func);
        }

        public override Task Delete(T item)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<T>> Get()
        {
            TableQuery<T> tb = database.Table<T>();
            var all = tb.ToList<T>();
            return await Task.Run(() => all);
        }

        public async override Task<T> Get(int identifier)
        {
            TableQuery<T> tb = database.Table<T>();
            var first = tb.FirstOrDefault(x => x.Id == identifier.ToString());
            return await Task.Run(()=> first);      
        }


        public override Task<T> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
