using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviewsLibrary.Models;
using DataAccessLayer.Models;

namespace RestaurantReviewsLibrary
{
    public static class Mapper
    {
        public static void Map(ref Restaurant src, ref RestaurantInfo dst)
        {
            // TODO: implement map
            dst.Name = src.Name;
            dst.Street = src.Street;
            dst.City = src.City;
            dst.State = src.State;
            dst.Zipcode = src.Zipcode;
            dst.RestaurantId = src.Id;
            dst.Country = src.Country;
        }

        public static void Map(ref RestaurantInfo src, ref Restaurant dst)
        {
            // TODO: implement map
        }

        public static void Map(ref Review src, ref ReviewInfo dst)
        {
            // TODO: implement map
        }

        public static void Map(ref ReviewInfo src, ref Review dst)
        {
            // TODO: implement map
        }
    }
}
