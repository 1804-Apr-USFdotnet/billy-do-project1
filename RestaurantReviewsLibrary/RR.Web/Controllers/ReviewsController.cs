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

            return View(rev);
        }

        // GET: Reviews/Create
        public ActionResult Create(int id)
        {
            /* Show fields for creating a review
             */
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
            }
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Reviews(int id)
        {
            // show restaurant detail
            var restaurant = GetLibHelper().GetRestaurant(id);
            // get all reviews
            IEnumerable<Review> reviews = restaurant.Reviews;
            reviews = new List<Review>();
            // show all reviews
            var vmObj = new ReviewViewModel(restaurant, reviews);

            return View(vmObj);
            //return View();
        }
    }
}
