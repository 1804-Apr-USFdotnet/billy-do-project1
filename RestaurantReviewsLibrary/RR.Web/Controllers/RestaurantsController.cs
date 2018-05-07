using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccessLayer.Models;
using RestaurantReviewsLibrary.Models;

namespace RR.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        // GET: Restaurants
        public ActionResult Index()
        {
            RRLibHelper libHelper;
            IEnumerable<Restaurant> topThree;
            using (var context = new DataAccessLayer.RRDb())
            {
                libHelper = new RRLibHelper(context);
                topThree = libHelper.GetTopThreeRestaurants();
            }
            /* Top 3 restaurants shown, perhaps in carousel
             * Each restaurant pic is a link to Details of restaurant
             * Input to search for restaurant, or choose by Id --> Details/???
             */
            return View(topThree);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            /* Show Details for restaurant
             * Have "submit review" link, that goes to Reviews/Create
             */
            Restaurant rest;

            RRLibHelper libHelper;
            using (var context = new DataAccessLayer.RRDb())
            {
                libHelper = new RRLibHelper(context);
                rest = libHelper.GetRestaurant(id);
            }

            return View(rest);
        }

        public ActionResult Search()
        {
            var name = Request.QueryString["restaurant"];
            if (name != null && name != "")
            {
                //TODO search by name, and return result
                return RedirectToAction("Details", 1);
            }
            else
            {
                // look by id
                var restId = Request.QueryString["id"];
                return RedirectToAction("Details", new { id = Convert.ToInt32(restId) });
            }
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            /* Show Input form for Restaurant
             **/
            return View();
        }

        //// POST: Restaurants/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                RRLibHelper libHelper;
                using (var context = new DataAccessLayer.RRDb())
                {
                    libHelper = new RRLibHelper(context);
                    libHelper.CreateRestaurant(restaurant);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            /* Show input fields
             * Each field should have current info as value
             */
             // Get restaurant object by ID
             // send object to view
            return View();
        }

        // POST: Restaurants/Edit/5
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

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            /* Ask if they want to delete
             * Show restaurant info
             */
            return View();
        }

        // POST: Restaurants/Delete/5
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
