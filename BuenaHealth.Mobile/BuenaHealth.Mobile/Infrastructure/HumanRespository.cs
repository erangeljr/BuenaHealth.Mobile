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
    public class HumanRespository : IRepository<Humans>
    {
         private SQLiteConnection dbConn;
        
        public string StatusMessage { get; set; }
        public HumanRespository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                dbConn = new SQLiteConnection(sqlitePlatform, dbPath);

                //create the Person table
                dbConn.CreateTable<Humans>();
            }
        }
        public IQueryable<Humans> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Humans> Find(Expression<Func<Humans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Humans Single(Expression<Func<Humans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Humans SingleOrDefault(Expression<Func<Humans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Humans First(Expression<Func<Humans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Humans GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(Humans entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Humans entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Humans entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Humans entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Humans> entities)
        {
            throw new NotImplementedException();
        }
    }
}
