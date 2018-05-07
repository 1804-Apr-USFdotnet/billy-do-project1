using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DataAccessLayer.Models;

namespace RR.Web.Models
{
    public class ReviewViewModel
    {
        public ReviewViewModel(Restaurant otherRestaurant, IEnumerable<Review> otherReviews)
        {
            Restaurant = otherRestaurant;
            Reviews = otherReviews;
        }

        public Restaurant Restaurant;
        public IEnumerable<Review> Reviews;
    }
}