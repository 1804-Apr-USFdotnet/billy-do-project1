using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantReviewsLibrary.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace RestaurantReviewsLibrary.Models
{
    public class RRLibHelper : IRRLibHelper
    {
        private IDbContext context;
        private Repository<Restaurant> restRepo;
        private Repository<DataAccessLayer.Models.Review> revRepo;

        #region Constructors
        public RRLibHelper(IDbContext context)
        {
            this.context = context;
            restRepo = new Repository<Restaurant>(context);
            revRepo = new Repository<DataAccessLayer.Models.Review>(context);
            //GetSerializedData();
            //OutputData();
        }
        #endregion

        #region Methods

        #region CRUD Restaurants
        public void CreateRestaurant(Restaurant restaurant)
        {
            // TODO implement
            throw new NotImplementedException();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            // TODO implement
            throw new NotImplementedException();
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            // TODO implement
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD Reviews
        public void CreateReview(Review review)
        {
            // TODO implement
            throw new NotImplementedException();
        }

        public void UpdateReview(Review review)
        {
            // TODO implement
            throw new NotImplementedException();
        }

        public void DeleteReview(Review review)
        {
            // TODO implement
            throw new NotImplementedException();
        }
        #endregion

        private void GetSerializedData()
        {
            //if ((_datasrc & DataSource.InputDb) > 0)
            //{
            //    // get from database
            //    try
            //    {
            //        var restList = crud.GetAllRestarurants();
            //        var reviewList = crud.GetAllReviews();
            //        foreach (var restaurant in restList)
            //        {
            //            var restInfo = new RestaurantInfo(restaurant);
            //            var shortList = reviewList.Where((r) => r.RestaurantId == restaurant.Id).ToList();
            //            foreach (var review in shortList)
            //            {
            //                restInfo.ListOfReviews.Add(new Review(review));
            //            }
            //            _myList.Add(restInfo);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        // TODO: Log database error
            //    }
            //} 
            //else if ((_datasrc & DataSource.InputXml) > 0)
            //{
            //    MySerializer.Deserialize(ref _myList);
            //}
            //else
            //{
            //    // Did not choose any input!!!
            //    // TODO Log error?
            //}
            
        }

        private void OutputData()
        {
            //if ((_datasrc & DataSource.OutputDb) > 0)
            //{
            //    try
            //    {
            //        var a = crud.GetAllRestaurants();
            //        if (a.Count() <= 0)
            //        {
            //            foreach (var item in _myList)
            //            {
            //                var rest = crud.CreateRestaurant(item.Name, item.Location);
            //                int restId = rest.Id;
            //                item.RestaurantId = restId;

            //                foreach (var review in item.ListOfReviews)
            //                {
            //                    review.RestaurantId = restId;
            //                    var retReview = crud.CreateReview(review.Rating, review.ReviewerName,
            //                        review.Description, review.DateCreated, restId);
            //                    int reviewId = retReview.Id;
            //                    review.ReviewId = reviewId;
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        //TODO: Logging on database error?
            //    }
            //}
            //else if ((_datasrc & DataSource.OutputXml) > 0)
            //{
            //    MySerializer.Serialize(ref _myList);
            //    //TODO: Log info, output to xml file
            //}
            //else
            //{
            //    // Did not choose to output
            //    // TODO Log info, for all choices
            //}
        }

        public IEnumerable<IRestaurantInfo> GetTopRestaurants(int n)
        {
            // TODO: implement new version
            throw new NotImplementedException();
        }

        public IEnumerable<IRestaurantInfo> GetTopThreeRestaurants()
        {
            return GetTopRestaurants(3);
        }

        public IEnumerable<IRestaurantInfo> GetAllRestaurants()
        {
            // TODO: implement new version
            throw new NotImplementedException();
        }

        public IRestaurantInfo GetRestaurant(string name)
        {
            // TODO: implement new version
            throw new NotImplementedException();
        }

        public IEnumerable<IReview> GetAllReviews()
        {
            // TODO: implement new version
            throw new NotImplementedException();
        }

        public IEnumerable<IRestaurantInfo> SearchRestaurant(string searchQuery)
        {
            // TODO: implement new version
            throw new NotImplementedException();

            //StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
            //var obj = _myList.FindAll(c => c.Name.StartsWith(searchQuery, comparison));
            //return obj;
        }
        #endregion
    }

}
