using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary.Models.Tests
{
    [TestClass()]
    public class RestaurantsInfoUnitTests
    {
        [TestMethod()]
        public void RestaurantsInfoConstructorTest()
        {
            RestaurantsInfo infoObj = new RestaurantsInfo();
            int expected = 51;
            int expectedReviewCount = 7;// total = 188;

            var actual = infoObj.ListOfRestaurants.Count();
            int actualReviewCount = infoObj.ListOfRestaurants.ElementAt(2).ReviewCount;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedReviewCount, actualReviewCount);
        }


        [TestMethod()]
        public void GetTopRestaurantsTest()
        {
            // Dummy Data: Franklin BBQ, Pizza Place (Tallahassee), Checkers
            RestaurantsInfo infoObj = new RestaurantsInfo();
            string first = "Rath, Stehr and O'Connell";
            string second = "Schiller LLC";
            string secondLocation = "Old Shore";
            string third = "Collier, Beatty and Mertz";

            var a = infoObj.GetTopRestaurants(3);

            Assert.AreEqual(first, a.ElementAt(0).Name);
            Assert.AreEqual(second, a.ElementAt(1).Name);
            Assert.AreEqual(secondLocation, a.ElementAt(1).Location);
            Assert.AreEqual(third, a.ElementAt(2).Name);

        }

        [TestMethod()]
        public void GetAllRestaurantsTest()
        {
            RestaurantsInfo infoObj = new RestaurantsInfo();
            int expectedRestaurantCount = 51;

            var a = infoObj.GetAllRestaurants();

            Assert.AreEqual(expectedRestaurantCount, a.Count());
            foreach (var restaurant in a)
            {
                Assert.IsNotNull(restaurant.Name);
            }
        }

        [TestMethod()]
        public void GetAllReviewsTest()
        {
            RestaurantsInfo infoObj = new RestaurantsInfo();
            int expectedReviewCount = 188;

            var actualReviews = infoObj.GetAllReviews();

            Assert.AreEqual(expectedReviewCount, actualReviews.Count());
        }

        [TestMethod()]
        public void SearchRestaurantTest1()
        {
            RestaurantsInfo infoObj = new RestaurantsInfo();
            string expectedRestName = "Thiel LLC";
            int expectedCount = 1;

            var a = infoObj.SearchRestaurant("Thiel LLC");

            Assert.AreEqual(expectedCount, a.Count());
            Assert.AreEqual(expectedRestName, a.ElementAt(0).Name);
        }

        [TestMethod()]
        public void SearchRestaurantTest2()
        {
            string restPartialName = "Jo";
            RestaurantsInfo infoObj = new RestaurantsInfo();
            string expectedRestName1 = "Jones Group";
            string expectedRestName2 = "Johns Group";
            string expectedRestName3 = "Jones LLC";
            int expectedCount = 3;

            var a = infoObj.SearchRestaurant(restPartialName);

            Assert.AreEqual(expectedCount, a.Count());
            Assert.AreEqual(expectedRestName1, a.ElementAt(0).Name);
            Assert.AreEqual(expectedRestName2, a.ElementAt(1).Name);
            Assert.AreEqual(expectedRestName3, a.ElementAt(2).Name);
        }
    }
}