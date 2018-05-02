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
    public class RestaurantInfoUnitTests
    {
        [TestMethod()]
        public void RestaurantInfoConstructorTest()
        {
            string expName = "Marv's Pizza Palace";
            string expLocation = "789 Thisisa Street";

            RestaurantInfo testObj = new RestaurantInfo(expName, expLocation);

            Assert.AreEqual(expName, testObj.Name);
            Assert.AreEqual(expLocation, testObj.Location);
        }

        [TestMethod()]
        public void RestaurantInfoGetAverageRatingTest1()
        {
            string expName = "Tatsuya Ramen";
            string expLocation = "123 Fake St.";
            double expRating = 0.0;
            RestaurantInfo testObj = new RestaurantInfo(expName, expLocation);

            double actualVal = testObj.GetAverageRating;

            Assert.AreEqual(expName, testObj.Name);
            Assert.AreEqual(expLocation, testObj.Location);
            Assert.AreEqual(expRating, actualVal);
        }

        [TestMethod()]
        public void RestaurantInfoGetAverageRatingTest2()
        {
            string expName = "TGIFridays";
            string expLocation = "4568 Main Street";
            double expRating = 2.5;
            RestaurantInfo testObj = new RestaurantInfo(expName, expLocation);
            testObj.SubmitReview("Reviewer1", 4);
            testObj.SubmitReview("Reviewer1", 1, "Review Description");

            double actualVal = testObj.GetAverageRating;

            Assert.AreEqual(expName, testObj.Name);
            Assert.AreEqual(expLocation, testObj.Location);
            Assert.AreEqual(expRating, actualVal);
        }

        [TestMethod()]
        public void SubmitReviewTest()
        {
            string expReviewerName = "Hanzo Lastname";
            int expRating = 4;
            string expDesc = "";
            RestaurantInfo rest = new RestaurantInfo("name", "loc");

            rest.SubmitReview(expReviewerName, expRating);
            
            Assert.IsTrue(rest.ReviewCount > 0);
        }

        [TestMethod()]
        public void GetAllReviewsTest1()
        {
            string expName = "Restaurant1";
            string expLocation = "123 One St.";
            RestaurantInfo rest = new RestaurantInfo(expName, expLocation);

            var l = rest.GetAllReviews();

            foreach (var review in l)
            {
                Assert.Fail();
            }
            Assert.IsTrue(l.Count() == 0);
        }

        [TestMethod()]
        public void GetAllReviewsTest2()
        {
            string expName = "Restaurant1";
            string expLocation = "123 One St.";
            RestaurantInfo rest = new RestaurantInfo(expName, expLocation);
            rest.SubmitReview("Reviewer1", 5);
            rest.SubmitReview("Reviewer2", 4);
            rest.SubmitReview("Reviewer3", 3);
            rest.SubmitReview("Reviewer4", 2);
            rest.SubmitReview("Reviewer5", 1);

            var l = rest.GetAllReviews();

            foreach (var review in l)
            {
                Assert.AreEqual(review.ReviewerName.Length, 9);
            }
            Assert.IsTrue(l.Count() == 05);
        }
    }
}