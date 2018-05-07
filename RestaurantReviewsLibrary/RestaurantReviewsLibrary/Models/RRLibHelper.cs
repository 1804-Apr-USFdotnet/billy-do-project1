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
        private Repository<Review> revRepo;

        #region Constructors
        public RRLibHelper()
        {
            context = new RRDb();
            restRepo = new Repository<Restaurant>(context);
            revRepo = new Repository<Review>(context);
        }
        #endregion

        #region Methods

        #region CRUD Restaurants
        public void CreateRestaurant(Restaurant restaurant)
        {
            // TODO test
            //var r = new Restaurant();
            //Mapper.Map(ref restaurant, ref r);
            restRepo.Create(restaurant);
            //throw new NotImplementedException();
        }

        public Restaurant GetRestaurant(int id)
        {
            //TODO test
            //var rest = restRepo.FindById(id);
            //var info = new RestaurantInfo();
            //Mapper.Map(ref rest, ref info);
            return restRepo.FindById(id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            // TODO test
            //var r = restRepo.FindById(info.RestaurantId);
            //Mapper.Map(ref info, ref r);
            restRepo.Update(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            // TODO test
            restRepo.Delete(restaurant);
        }

        public void DeleteRestaurant(int id)
        {
            // TODO test
            var r = GetRestaurant(id);
            DeleteRestaurant(r);
        }
        #endregion

        #region CRUD Reviews
        public void CreateReview(Review review)
        {
            // TODO test
            revRepo.Create(review);
        }

        public Review GetReview(int id)
        {
            // TODO test
            return revRepo.FindById(id);
        }

        public void UpdateReview(Review review)
        {
            // TODO test
            revRepo.Update(review);
        }

        public void DeleteReview(Review review)
        {
            // TODO test
            revRepo.Delete(review);
        }

        public void DeleteReview(int id)
        {
            // TODO test
            var r = GetReview(id);
            DeleteReview(r);
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

        public IEnumerable<Restaurant> GetTopRestaurants(int n)
        {
            // TODO: implement new version
            return GetAllRestaurantsSortBy(SortBy.AverageDesc).Take(n);
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetTopThreeRestaurants()
        {
            return GetTopRestaurants(3);
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            // TODO: implement new version
            return restRepo.FindAll();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            // TODO: implement new version
            //var allReviews = revRepo.FindAll();
            //List<ReviewInfo> infos = new List<ReviewInfo>();
            //foreach (var review in allReviews)
            //{
            //    ReviewInfo info = new ReviewInfo();
            //    Mapper.Map(ref review, ref info);
            //    infos.Add(info);
            //}
            //throw new NotImplementedException();
            return revRepo.FindAll();
        }

        public IEnumerable<Restaurant> GetAllRestaurantsSortBy(SortBy sortOption)
        {
            var list = GetAllRestaurants();
            switch (sortOption)
            {
                case SortBy.NameAsc:
                    list.OrderBy(x => x.Name);
                    break;
                case SortBy.NameDesc:
                    list.OrderByDescending(x => x.Name);
                    break;
                case SortBy.ReviewCountAsc:
                    list.OrderBy(x => x.Reviews.Count());
                    break;
                case SortBy.ReviewCountDesc:
                    list.OrderByDescending(x => x.Reviews.Count());
                    break;
                case SortBy.AverageAsc:
                    list.OrderBy(x => (x.AverageRating));
                    break;
                case SortBy.AverageDesc:
                    list.OrderByDescending(x => (x.AverageRating));
                    break;
                default:
                    break;
            }
            return list;
        }

        public IEnumerable<Review> GetAllReviewsSortBy(SortBy sortOption)
        {
            var list = GetAllReviews();
            switch (sortOption)
            {
                case SortBy.NameAsc:
                    list.OrderBy(x => x.Username);
                    break;
                case SortBy.NameDesc:
                    list.OrderByDescending(x => x.Username);
                    break;
                case SortBy.DateCreatedAsc:
                    list.OrderBy(x => x.DateCreated);
                    break;
                case SortBy.DateCreatedDesc:
                    list.OrderByDescending(x => x.DateCreated);
                    break;
                case SortBy.DateModifiedAsc:
                    list.OrderBy(x => x.DateModified);
                    break;
                case SortBy.DateModifiedDesc:
                    list.OrderByDescending(x => x.DateModified);
                    break;
                default:
                    break;
            }
            return list;
        }

        public IEnumerable<Restaurant> SearchRestaurant(string searchQuery)
        {
            // TODO: implement new version
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
            //restRepo.FindAll().ToList().FindAll(c => c.Name.StartsWith(searchQuery, comparison));
            return restRepo.FindAll().ToList().FindAll(c => c.Name.StartsWith(searchQuery, comparison));
            //throw new NotImplementedException();

            //var obj = _myList.FindAll(c => c.Name.StartsWith(searchQuery, comparison));
            //return obj;
        }
        #endregion

    }

    public enum SortBy { NameAsc, NameDesc, ReviewCountAsc, ReviewCountDesc, AverageAsc, AverageDesc,
        DateCreatedAsc, DateCreatedDesc, DateModifiedAsc, DateModifiedDesc }

}
