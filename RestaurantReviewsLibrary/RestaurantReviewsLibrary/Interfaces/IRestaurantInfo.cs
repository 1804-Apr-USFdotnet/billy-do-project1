using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary.Interfaces
{
    public interface IRestaurantInfo
    {
        double GetAverageRating { get; }
        string Name { get; }
        string Location { get; }
        int ReviewCount { get; }

        void SubmitReview(string name, int rating, string desc);
        IEnumerable<IReview> GetAllReviews();
    }
}
