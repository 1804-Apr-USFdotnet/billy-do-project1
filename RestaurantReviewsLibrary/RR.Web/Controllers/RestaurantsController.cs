﻿using System;
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
        private static RRLibHelper libHelper;

        private RRLibHelper GetLibHelper()
        {
            if (libHelper == null)
            {
                libHelper = new RRLibHelper();
            }
            return libHelper;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            List<Restaurant> topThree;
            topThree = GetLibHelper().GetTopThreeRestaurants().ToList();

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

            rest = GetLibHelper().GetRestaurant(id);

            return View(rest);
        }

        public ActionResult Search()
        {
            var name = Request.QueryString["restaurant"];
            if (name != null && name != "")
            {
                //TODO Search is not working...
                var r = GetLibHelper().SearchRestaurant(name);
                TempData["searchResults"] = r;
                return RedirectToAction("List", "Restaurants", new { @list = r });
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
                //RRLibHelper libHelper = new RRLibHelper();
                GetLibHelper().CreateRestaurant(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
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

            Restaurant rest = GetLibHelper().GetRestaurant(id);
            return View(rest);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            try
            {
                //RRLibHelper libHelper = new RRLibHelper();
                var oldRest = GetLibHelper().GetRestaurant(id);
                oldRest.Name = restaurant.Name;
                oldRest.Street = restaurant.Street;
                oldRest.City = restaurant.City;
                oldRest.State = restaurant.State;
                oldRest.Country = restaurant.Country;
                oldRest.Zipcode = restaurant.Zipcode;
                oldRest.ImageUrl = restaurant.ImageUrl;
                
                GetLibHelper().UpdateRestaurant(oldRest);
                return RedirectToAction("Details", new { id = oldRest.Id });
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public Restaurant UpdateRestaurant(Restaurant rest, FormCollection collection)
        {
            rest.Name = collection["Name"];
            rest.ImageUrl = collection["ImageUrl"];
            return rest;
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            /* Ask if they want to delete
             * Show restaurant info
             */
            var r = GetLibHelper().GetRestaurant(id);
            return View(r);
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                GetLibHelper().DeleteRestaurant(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult List(IEnumerable<Restaurant> list)
        {
            var searchResults = TempData["searchResults"];
            if (searchResults != null)
            {
                list = (IEnumerable<Restaurant>)searchResults;
            }

            string sortOption = Request["sort"];
            if (list == null)
            {
                // Get list of all resturants
                if (sortOption != null && sortOption != "")
                {
                    SortBy sortBy = SortBy.NameAsc;
                    switch (sortOption)
                    {
                        case "name":
                            sortBy = SortBy.NameDesc;
                            break;
                        case "review":
                            sortBy = SortBy.ReviewCountDesc;
                            break;
                        case "avg":
                            sortBy = SortBy.AverageDesc;
                            break;
                    }
                    list = GetLibHelper().GetAllRestaurantsSortBy(sortBy);
                }
                else
                {
                    list = GetLibHelper().GetAllRestaurants();
                }
            }
            else if (list.Count() == 0)
            {
                // TODO Show "No restaurants listed" text?
                return View(list);
            }
            else if (list.Count() == 1)
            {
                // Redirect to Details page?
                return RedirectToAction("Details", new { id = list.FirstOrDefault().Id  });
            }
             else
            {
                // Show list of restaurants
            }
            return View(list);
        }
    }
}
