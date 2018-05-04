using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Models
{
    class UnitOfWork : IUnitOfWork
    {
        private RRDb db;
        public IRepository<Restaurant> Restaurants;

        public IRepository<Review> Reviews;

        public UnitOfWork()
        {
            db = new RRDb();
            //Restaurants = db.Restaurants;

        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
