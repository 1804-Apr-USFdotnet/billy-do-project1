using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RRCrud
    {
        RRDb db = new RRDb();

        // ============
        // CRUD Methods
        // ============

        // Create
        public int CreateRestaurant(string name, string loc) 
        {
            var restaurant = db.Restaurants.Create();
            restaurant.Name = name;
            restaurant.Location = loc;

            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            return restaurant.Id;
        }

        public int CreateReview(int rating, string user, string desc, DateTime created, int restid) 
        {
            var review = db.Reviews.Create();
            review.Rating = rating;
            review.Username = user;
            review.Description = desc;
            review.DateCreated = created;

            review.RestaurantId = restid;

            db.Reviews.Add(review);
            db.SaveChanges();
            return review.Id;
        }

        //Read
        public Restaurant ReadRestaurant(int id)
        {
            //TODO: test
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetAllRestarurants()
        {
            return db.Restaurants.ToList();
        }

        public Review ReadReview(int id)
        {
            // test
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return db.Reviews.ToList();
        }

        // Update

        // Delete

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
