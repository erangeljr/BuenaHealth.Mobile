using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Interfaces;
using BuenaHealth.Mobile.Models;

namespace BuenaHealth.Mobile.Infrastructure
{
    public class VitalSignsRepository :IRepository<VitalSigns>
    {
        public IQueryable<VitalSigns> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<VitalSigns> Find(Expression<Func<VitalSigns, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public VitalSigns Single(Expression<Func<VitalSigns, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public VitalSigns SingleOrDefault(Expression<Func<VitalSigns, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public VitalSigns First(Expression<Func<VitalSigns, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public VitalSigns GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(VitalSigns entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(VitalSigns entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(VitalSigns entity)
        {
            throw new NotImplementedException();
        }

        public void Update(VitalSigns entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<VitalSigns> entities)
        {
            throw new NotImplementedException();
        }
    }
}
