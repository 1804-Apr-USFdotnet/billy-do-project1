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
    public class ReviewUnitTests
    {

        [TestMethod()]
        public void ReviewConstructorTest1()
        {
            int expRating = 4;
            string expName = "Holly Tinkerton";
            DateTime expTime = DateTime.Now;
            string expDesc = "";

            Review testObj = new Review(expRating, expName, expTime);


            Assert.AreEqual(expRating, testObj.Rating);
            Assert.AreEqual(expName, testObj.ReviewerName);
            Assert.AreEqual(expTime, testObj.DateCreated);
            Assert.AreEqual(expDesc, testObj.Description);
        }

        [TestMethod()]
        public void ReviewConstructorTest2()
        {
            int expRating = 5;
            string expName = "Rick James";
            DateTime expTime = DateTime.Now;
            string expDesc = "These are some words";

            Review testObj = new Review(89, expName, expTime, expDesc);


            Assert.AreEqual(expRating, testObj.Rating);
            Assert.AreEqual(expName, testObj.ReviewerName);
            Assert.AreEqual(expTime, testObj.DateCreated);
            Assert.AreEqual(expDesc, testObj.Description);
        }
    }
}