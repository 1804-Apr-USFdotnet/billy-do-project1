using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviewsLibrary.Abstracts;
using RestaurantReviewsLibrary.Interfaces;
using System.Xml.Serialization;

namespace RestaurantReviewsLibrary.Models
{
    public class RestaurantInfo : Business
    {
        public int RestaurantId { get; set; }

        //// Properties
        //public double GetAverageRating
        //{
        //    get
        //    {
        //        if (!(ListOfReviews.Count > 0))
        //        {
        //            return 0;
        //        }
        //        double sum = 0.0;
        //        foreach(IReview review in ListOfReviews)
        //        {
        //            sum += review.Rating;
        //        }
        //        return sum / ListOfReviews.Count;
        //    }
        //}

        //public int ReviewCount
        //{
        //    get
        //    {
        //        return ListOfReviews.Count;
        //    }
        //}

        

        // Constructors
        public RestaurantInfo()
        {

        }
    }
}
