using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace RRLibraryUnitTest.Models
{
    public class MyTestContext : IDbContext
    {

        public MyTestContext()
        {
            TestDbSet<Restaurant> Restaurants;
            TestDbSet<Review> Reviews;
        }

        private void InitData()
        {
            // populate with some restaurants
            
            // populate with some reviews
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }
    }

    public class TestDbSet<T> : IDbSet<T> where T : class
    {
        public ObservableCollection<T> Local => new ObservableCollection<T>(_data);

        public Expression Expression => Expression.Constant(_data.AsQueryable());

        public Type ElementType => typeof(T);

        //May need to implement: https://www.eriklieben.com/unit-testing-entity-framework-repositories/
        public IQueryProvider Provider => throw new NotImplementedException();

        private readonly List<T> _data = new List<T>();

        public T Add(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public T Remove(T entity)
        {
            _data.Remove(entity);
            return entity;
        }

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
