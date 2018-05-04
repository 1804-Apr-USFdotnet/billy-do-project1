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

        public UnitOfWork()
        {
            db = new RRDb();
            //Restaurants = db.Restaurants;

        }

        public IRepository<Restaurant> Restaurants => throw new NotImplementedException();

        public IRepository<Review> Reviews => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
