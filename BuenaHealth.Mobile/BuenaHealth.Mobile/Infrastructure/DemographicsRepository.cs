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
    public class DemographicsRepository : IRepository<Demographics>
    {

        private SQLiteConnection dbConn;
        
        public string StatusMessage { get; set; }
        public DemographicsRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                dbConn = new SQLiteConnection(sqlitePlatform, dbPath);

                //create the Person table
                dbConn.CreateTable<Demographics>();
            }
        }
        public IQueryable<Demographics> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Demographics> Find(Expression<Func<Demographics, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Demographics Single(Expression<Func<Demographics, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Demographics SingleOrDefault(Expression<Func<Demographics, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Demographics First(Expression<Func<Demographics, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Demographics GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(Demographics entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Demographics entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Demographics entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Demographics entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Demographics> entities)
        {
            throw new NotImplementedException();
        }

        IList<Demographics> IRepository<Demographics>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
