using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary.Abstracts
{
    abstract class BusinessDetails : Details
    {
        string OwnerName;
        string StartTime;
        string EndTime;
        string PhoneNumber;
        string WebsiteURL;
    }
}
