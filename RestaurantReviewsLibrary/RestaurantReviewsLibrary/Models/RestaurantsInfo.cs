using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviewsLibrary.Interfaces;
using System.Xml.Serialization;
using System.IO;
using DataAccessLayer;

namespace RestaurantReviewsLibrary.Models
{
    public class RestaurantsInfo : IRestaurantsInfo
    {
        private static RRCrud crud = new RRCrud();
        // ----------
        // Properties
        // ----------
        protected List<RestaurantInfo> _myList;

        public IEnumerable<RestaurantInfo> ListOfRestaurants
        {
            get
            {
                return _myList;
            }
        }

        // ------------
        // Constructors
        // ------------
        public RestaurantsInfo()
        {
            _myList = new List<RestaurantInfo>();
            GetSerializedData();
            MySerializer.Serialize(ref _myList);

            OutputToRRDb();
        }

        // -------
        // Methods
        // -------

        internal void AddRestaurant(string name, string loc)
        {
            _myList.Add(new RestaurantInfo(name, loc));
        }

        private void GetSerializedData()
        {
            try
            {
                var restList = crud.GetAllRestarurants();
                var reviewList = crud.GetAllReviews();
                foreach (var restaurant in restList)
                {
                    var restInfo = new RestaurantInfo(restaurant);
                    var shortList = reviewList.Where((r) => r.RestaurantId == restaurant.Id).ToList();
                    foreach (var review in shortList)
                    {
                        restInfo.ListOfReviews.Add(new Review(review));
                    }
                    _myList.Add(restInfo);
                }
            }
            catch (Exception e)
            {
                // TODO: Log database error
            }

            if (_myList.Count() == 0)
            {
                MySerializer.Deserialize(ref _myList);
            }
            
        }

        private void OutputToRRDb()
        {
            //TODO: figure out how to NOT input data if data already exists in DB
            try
            {
                var a = crud.GetAllRestarurants();
                if (a.Count() <= 0)
                {
                    foreach (var item in _myList)
                    {
                        int restId = crud.CreateRestaurant(item.Name, item.Location);
                        item.RestaurantId = restId;

                        foreach (var review in item.ListOfReviews)
                        {
                            review.RestaurantId = restId;
                            int reviewId = crud.CreateReview(review.Rating, review.ReviewerName,
                                review.Description, review.DateCreated, restId);
                            review.ReviewId = reviewId;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //TODO: Logging
            }
        }

        public IEnumerable<IRestaurantInfo> GetTopRestaurants(int n)
        {
            return _myList.OrderByDescending(c => c.GetAverageRating).Take(n);
        }

        public IEnumerable<IRestaurantInfo> GetTopThreeRestaurants()
        {
            return GetTopRestaurants(3);
        }

        public IEnumerable<IRestaurantInfo> GetAllRestaurants()
        {
            return _myList;
        }

        public IRestaurantInfo GetRestaurant(string name)
        {
            var obj = _myList.Find(c => c.Name == name);
            if (obj == null)
            {
                return null;
            }
            return obj;
        }

        public IEnumerable<IReview> GetAllReviews()
        {
            List<Review> retList = new List<Review>();
            foreach (var rest in _myList)
            {
                retList.AddRange(rest.ListOfReviews);
            }
            return retList;
        }

        public IEnumerable<IRestaurantInfo> SearchRestaurant(string searchQuery)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
            var obj = _myList.FindAll(c => c.Name.StartsWith(searchQuery, comparison));
            return obj;
        }
    }
}
