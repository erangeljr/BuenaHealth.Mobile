using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Interfaces;
using BuenaHealth.Mobile.Models;
using SQLite.Net;
using SQLite.Net.Interop;

namespace BuenaHealth.Mobile.Infrastructure
{
    public class BuenaHealthBaseRepository<T> : IRepository<T> where T : class
    {
         private SQLiteConnection dbConn;
        
        public string StatusMessage { get; set; }
        public BuenaHealthBaseRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                dbConn = new SQLiteConnection(sqlitePlatform, dbPath);

                //create the Person table
                dbConn.CreateTable<T>();
            }
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
