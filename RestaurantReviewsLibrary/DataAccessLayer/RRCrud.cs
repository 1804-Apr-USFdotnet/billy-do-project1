using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

//namespace DataAccessLayer
//{
//    public class RRCrud
//    {
//        private RRDb db = new RRDb();
//        private RestaurantRepository restRepo;
//        private ReviewRepository revRepo;

//        public RRCrud(RRDb context)
//        {
//            restRepo = new RestaurantRepository(context);
//            revRepo = new ReviewRepository(context);
//        }

//        // ============
//        // CRUD Methods
//        // ============

//        #region Create Methods

//        public void Create(Restaurant restaurant)
//        {
//            restRepo.Create(restaurant);
//        }

//        public void Create(Review review)
//        {
//            revRepo.Create(review);
//        }
//        //public Restaurant CreateRestaurant(string name, string loc) 
//        //{
//        //    var restaurant = db.Restaurants.Create();
//        //    restaurant.Name = name;
//        //    restaurant.Location = loc;

//        //    db.Restaurants.Add(restaurant);
//        //    db.SaveChanges();
//        //    return restaurant;
//        //}

//        //public Review CreateReview(int rating, string user, string desc, DateTime created, int restid) 
//        //{
//        //    var review = db.Reviews.Create();
//        //    review.Rating = rating;
//        //    review.Username = user;
//        //    review.Description = desc;
//        //    review.DateCreated = created;

//        //    review.RestaurantId = restid;

//        //    db.Reviews.Add(review);
//        //    db.SaveChanges();
//        //    return review;
//        //}

//        #endregion

//        // ----
//        // Read

//        #region Read Methods
//        public Restaurant GetRestaurantById(int id)
//        {
//            return restRepo.GetById(id);
//        }

//        public Review GetReviewById(int id)
//        {
//            return revRepo.GetById(id);
//        }

//        public IEnumerable<Restaurant> GetAllRestaurants()
//        {
//            return restRepo.GetAll();
//        }

//        //public Restaurant ReadRestaurant(int id)
//        //{
//        //    return db.Restaurants.Find(id);
//        //}

//        //public IEnumerable<Restaurant> GetAllRestarurants()
//        //{
//        //    return db.Restaurants.ToList();
//        //}

//        //public Review ReadReview(int id)
//        //{
//        //    return db.Reviews.Find(id);
//        //}

//        //public IEnumerable<Review> GetAllReviews()
//        //{
//        //    return db.Reviews.ToList();
//        //}

//        #endregion

//        // ------
//        // Update
//        #region Update Methods
        
//        public void UpdateRestaurant(Restaurant entity)
//        {
//            restRepo.Update(entity);
//        }

//        public void UpdateReview(Review entity)
//        {
//            revRepo.Update(entity);
//        }

//        //public Restaurant UpdateRestaurant(int id, params string[] args)
//        //{
//        //    var r = ReadRestaurant(id);
//        //    r.Name = args[0];
//        //    r.Location = args[1];
//        //    db.SaveChanges();
//        //    return r;

//        //}

//        //public Review UpdateReview(int id, params object[] args)
//        //{
//        //    var r = ReadReview(id);
//        //    r.Rating = Convert.ToInt32(args[0]);
//        //    r.Description = (string)args[1];
//        //    // TODO: able to update other fields?

//        //    db.SaveChanges();
//        //    return r;
//        //}
//        #endregion

//        // ------
//        // Delete

//        #region Delete Methods
//        public void DeleteRestaurant(int id)
//        {
//            var r = GetRestaurantById(id);
//            DeleteRestaurant(r);
//        }

//        public void DeleteRestaurant(Restaurant entity)
//        {
//            restRepo.Delete(entity);
//        }

//        public void DeleteReview(int id)
//        {
//            var r = GetReviewById(id);
//            DeleteReview(r);
//        }

//        public void DeleteReview(Review entity)
//        {
//            revRepo.Delete(entity);
//        }

//        //public int DeleteRestaurant(int restId)
//        //{
//        //    var r = ReadRestaurant(restId);
//        //    db.Restaurants.Remove(r);
//        //    var result = db.SaveChanges();

//        //    return result;
//        //    //TODO: Return removed Restaurant object?
//        //}

//        //public int DeleteReview(int reviewId)
//        //{
//        //    var r = ReadReview(reviewId);
//        //    db.Reviews.Remove(r);
//        //    var result = db.SaveChanges();

//        //    return result;
//        //    //TODO: Return removed Restaurant object?
//        //}

//        #endregion

//        //public int SaveChanges()
//        //{
//        //    return db.SaveChanges();
//        //}
//    }
//}
