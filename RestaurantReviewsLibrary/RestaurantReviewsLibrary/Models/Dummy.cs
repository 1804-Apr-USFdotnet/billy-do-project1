using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary.Models
{
    public class Dummy
    {
        private List<List<object>> _myRestaurantList;
        private List<List<object>> _myReviewList;

        public Dummy()
        {
            _myRestaurantList = new List<List<object>>();
            _myReviewList = new List<List<object>>();

            //populate list with dummy data
            _myRestaurantList.Add(new List<object> { "Pizza Place", "Tampa" });
            _myRestaurantList.Add(new List<object> { "Mission BBQ", "Tampa" });
            _myRestaurantList.Add(new List<object> { "Wendys", "Michigan" });
            _myRestaurantList.Add(new List<object> { "Franklin BBQ", "Austin, TX" });
            _myRestaurantList.Add(new List<object> { "Chuck E. Cheese", "California" });
            _myRestaurantList.Add(new List<object> { "Checkers", "Florida" });
            _myRestaurantList.Add(new List<object> { "Pizza Place", "Tallahassee" });

            // Pizza Place in Tampa has 3 reviews, avg rating of 2.66667~
            _myReviewList.Add(new List<object> {0, 1, "Piper Doe" });
            _myReviewList.Add(new List<object> {0, 3, "Penelope Doe", "It's pizza." });
            _myReviewList.Add(new List<object> {0, 4, "Pepper Potts" });
            // Mission BBQ has 2 reviews, avgrating of 3
            _myReviewList.Add(new List<object> {1, 4, "Mary Jane", "Pretty good BBQ." });
            _myReviewList.Add(new List<object> {1, 2, "Moses", "Decent food, but way too expensive." });
            // Wendys has 1 review, avgrating of 3
            _myReviewList.Add(new List<object> {2, 3, "Wario", "WAAAAAHHHAAAAHAAAAHHH" });
            // Franklin BBQ has 2 reviews, avgrating of 5
            _myReviewList.Add(new List<object> {3, 5, "Franklin", "THE BEST bbq in the world!!!!" });
            _myReviewList.Add(new List<object> {3, 5, "Fartso Mcgee", "Long lines, but worth the wait." });
            // Chuck E Cheese has 4 reviews, avgrating of 1.25
            _myReviewList.Add(new List<object> {4, 1, "Chuuni Byou" });
            _myReviewList.Add(new List<object> {4, 2, "Child Name", "PIZZAGAMESPIZZAGAMESPIZZAGAMES" });
            _myReviewList.Add(new List<object> {4, 1, "Check", "Saw a huge rat, nobody else seemed to mind..." });
            _myReviewList.Add(new List<object> {4, 1, "Charles" });
            // Checkers has 2 reviews, avgrating 3.5
            _myReviewList.Add(new List<object> {5, 3, "Cheep Byrd", "Cheap, okay food." });
            _myReviewList.Add(new List<object> {5, 4, "Cheese Burgler", "Nearly as good as my usual go-to!" });
            // Pizza Place in Tallahassee has 3 reviews, avgrating of 4
            _myReviewList.Add(new List<object> {6, 4, "Tom Cruises", "Great place to host my scientology meetings." });
            _myReviewList.Add(new List<object> {6, 4, "Anne Castaway" });
        }

        public List<List<object>> GetRestaruantData()
        {
            return _myRestaurantList;
        }

        public List<List<object>> GetReviewData()
        {

            return _myReviewList;
        }

    }
}
