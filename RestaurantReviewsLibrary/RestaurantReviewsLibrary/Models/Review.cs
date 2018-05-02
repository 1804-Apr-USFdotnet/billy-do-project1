using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestaurantReviewsLibrary.Interfaces;

namespace RestaurantReviewsLibrary.Models
{
    public class Review : IReview
    {
        // properties
        public int Rating { get; set; }
        public int ReviewId { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        // Constructors
        public Review() { }

        public Review(int rating, string name, DateTime time, string description = "")
        {
            if (rating <= 0)
            {
                Rating = 0;
            }
            else
            {
                Rating = Math.Min(5, rating);
                
            }
            ReviewerName = name;
            DateCreated = time;
            Description = description;
        }

        public Review(DataAccessLayer.Review dbModel)
        {
            Rating = dbModel.Rating;
            ReviewId = dbModel.Id;
            RestaurantId = dbModel.RestaurantId;
            ReviewerName = dbModel.Username;
            Description = dbModel.Description;
            DateCreated = dbModel.DateCreated;
        }
    }
}
