using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestaurantReviewsLibrary.Interfaces;

namespace RestaurantReviewsLibrary.Models
{
    public class ReviewInfo
    {
        // properties
        public int Rating { get; set; }
        public int ReviewId { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        // Constructors
        public ReviewInfo() { }
    }
}
