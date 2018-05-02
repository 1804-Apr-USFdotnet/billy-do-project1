using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviewsLibrary.Abstracts;

namespace RestaurantReviewsLibrary.Models
{
    class RestaurantDetails : BusinessDetails
    {
        string OpenTime;
        string ClosingTime;
    }
}
