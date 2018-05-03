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

        // ------
        // Create
        public Restaurant CreateRestaurant(string name, string loc) 
        {
            var restaurant = db.Restaurants.Create();
            restaurant.Name = name;
            restaurant.Location = loc;

            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            return restaurant;
        }

        public Review CreateReview(int rating, string user, string desc, DateTime created, int restid) 
        {
            var review = db.Reviews.Create();
            review.Rating = rating;
            review.Username = user;
            review.Description = desc;
            review.DateCreated = created;

            review.RestaurantId = restid;

            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        // ----
        // Read
        public Restaurant ReadRestaurant(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetAllRestarurants()
        {
            return db.Restaurants.ToList();
        }

        public Review ReadReview(int id)
        {
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return db.Reviews.ToList();
        }

        // ------
        // Update
        public Restaurant UpdateRestaurant(int id, params string[] args)
        {
            var r = ReadRestaurant(id);
            r.Name = args[0];
            r.Location = args[1];
            db.SaveChanges();
            return r;

        }

        public Review UpdateReview(int id, params object[] args)
        {
            var r = ReadReview(id);
            r.Rating = Convert.ToInt32(args[0]);
            r.Description = (string)args[1];
            // TODO: able to update other fields?

            db.SaveChanges();
            return r;
        }

        // ------
        // Delete
        public int DeleteRestaurant(int restId)
        {
            var r = ReadRestaurant(restId);
            db.Restaurants.Remove(r);
            var result = db.SaveChanges();

            return result;
            //TODO: Return removed Restaurant object?
        }

        public int DeleteReview(int reviewId)
        {
            var r = ReadReview(reviewId);
            db.Reviews.Remove(r);
            var result = db.SaveChanges();

            return result;
            //TODO: Return removed Restaurant object?
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
