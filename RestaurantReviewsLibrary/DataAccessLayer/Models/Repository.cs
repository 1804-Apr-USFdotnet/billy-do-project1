﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:EntityBase
    {
        private readonly DbContext _db;
        private DbSet<TEntity> _entities; //???

        public Repository(DbContext context)
        {
            this._db = context;
            //this._entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _db.Set<TEntity>();
                }
                return _entities;
            }
        }

        public void Create(TEntity newEntity)
        {
            Entities.Add(newEntity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Entities.ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return Entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            Entities.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
