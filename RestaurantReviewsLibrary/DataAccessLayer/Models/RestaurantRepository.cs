using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Models
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private RRDb db;

        public RestaurantRepository(RRDb context)
        {
            db = context;
        }

        public void Create(Restaurant entity)
        {
            //var restaurant = db.Restaurants.Create();
            //restaurant.Name = name;
            //restaurant.Location = loc;

            db.Restaurants.Add(entity);
            db.SaveChanges();
            //return restaurant;
            //throw new NotImplementedException();
        }

        public void Delete(Restaurant entity)
        {
            db.Restaurants.Remove(entity);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.ToList();
        }

        public void Update(Restaurant entity)
        {
            //TODO: test
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
