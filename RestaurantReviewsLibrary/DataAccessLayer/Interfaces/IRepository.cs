using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        
        void Create(T newEntity);
        T FindById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> Table { get; }
        
    }
}
