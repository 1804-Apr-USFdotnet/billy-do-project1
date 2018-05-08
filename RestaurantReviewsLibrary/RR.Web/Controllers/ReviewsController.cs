using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccessLayer.Models;
using RestaurantReviewsLibrary.Models;
using RR.Web.Models;

namespace RR.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private static RRLibHelper libHelper;

        private RRLibHelper GetLibHelper()
        {
            if (libHelper == null)
            {
                libHelper = new RRLibHelper();
            }
            return libHelper;
        }

        // GET: Reviews
        public ActionResult Index()
        {
            /* Show 3 random reviews of restaurants?
             * Same as Restaurants, have "search for" stuff at bottom
             */
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            var rev = GetLibHelper().GetReview(id);
            if (rev == null)
            {
                TempData["ReviewNull"] = true;
                return RedirectToAction("Index");
            }

            return View(rev);
        }

        // GET: Reviews/Create
        public ActionResult Create(int id)
        {
            /* Show fields for creating a review
             */
            ViewData["Restaurant"] = GetLibHelper().GetRestaurant(id);
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                // TODO: Add insert logic here
                review.RestaurantId = review.Id;
                review.Id = 0;
                GetLibHelper().CreateReview(review);


                return RedirectToAction("Details", new { id = review.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            /* show fields allowed for editing a review
             */
            var review = GetLibHelper().GetReview(id);
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Review review)
        {
            try
            {
                var oldrev = GetLibHelper().GetReview(id);
                oldrev.Rating = review.Rating;
                oldrev.Username = review.Username;
                oldrev.Description = review.Description;
                GetLibHelper().UpdateReview(oldrev);
                return RedirectToAction("Details", new { id = oldrev.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            /* Ask if they want to delete review
             * Show review Details
             */
            var review = GetLibHelper().GetReview(id);
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GetLibHelper().DeleteReview(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            var qs = Request.QueryString;
            var restId = qs["restId"];
            var reviewId = qs["reviewId"];
            if (restId != null && restId != "")
            {
                //go to restaurantDetail, show reviews
                return RedirectToAction("Reviews", new { id = Convert.ToInt32(restId) });
            }
            else if (reviewId != null && reviewId != "")
            {
                // get Id, go to Details/Id
                return RedirectToAction("Details", new { id = Convert.ToInt32(reviewId) });
            }
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Reviews(int id)
        {
            // show restaurant detail
            var restaurant = GetLibHelper().GetRestaurant(id);
            var result = restaurant.AverageRating;
            // get all reviews
            IEnumerable<Review> reviews;
            try
            {
                reviews = restaurant.Reviews;
            }
            catch (NullReferenceException ex)
            {
                reviews = new List<Review>();
            }
            // show all reviews
            var vmObj = new ReviewViewModel(restaurant, reviews);

            return View(vmObj);
            //return View();
        }
    }
}
