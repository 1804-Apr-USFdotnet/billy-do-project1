using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Models
{
    class ReviewRepository : IRepository<Review>
    {
        private RRDb db;

        public ReviewRepository(RRDb context)
        {
            db = context;
        }

        public void Create(Review entity)
        {
            db.Reviews.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Review entity)
        {
            db.Reviews.Remove(entity);
            db.SaveChanges();
        }

        public Review GetById(int id)
        {
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviews.ToList();
        }

        public void Update(Review entity)
        {
            //TODO: test
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
