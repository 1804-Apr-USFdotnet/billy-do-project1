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
    public class RestaurantInfo : Business, IRestaurantInfo
    { 
        [XmlArray]
        public List<Review> ListOfReviews;
        public int RestaurantId { get; set; }

        // Properties
        public double GetAverageRating
        {
            get
            {
                if (!(ListOfReviews.Count > 0))
                {
                    return 0;
                }
                double sum = 0.0;
                foreach(IReview review in ListOfReviews)
                {
                    sum += review.Rating;
                }
                return sum / ListOfReviews.Count;
            }
        }

        public int ReviewCount
        {
            get
            {
                return ListOfReviews.Count;
            }
        }

        

        // Constructors
        private RestaurantInfo()
        {

        }

        public RestaurantInfo(string name, string loc) : base(name, loc)
        {
            ListOfReviews = new List<Review>();
        }

        public RestaurantInfo(DataAccessLayer.Restaurant dbModel)
        {
            Name = dbModel.Name;
            Location = dbModel.Location;
            RestaurantId = dbModel.Id;
            ListOfReviews = new List<Review>();
        }

        // Methods
        public void SubmitReview(string name, int rating, string description = "")
        {
            Review r = new Review(rating, name, DateTime.Now, description);
            ListOfReviews.Add(r);
        }

        public IEnumerable<IReview> GetAllReviews()
        {
            return ListOfReviews;
        }
    }
}
