using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RR.Web.Controllers
{
    public class ReviewsController : Controller
    {
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
            var review = new DataAccessLayer.Models.Review
            {
                Id = 1,
                Rating = 4,
                RestaurantId = 5,
                Username = "googleuser",
                Description = "I give it a 4/100."
            };

            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
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
             * 
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
    }
}
