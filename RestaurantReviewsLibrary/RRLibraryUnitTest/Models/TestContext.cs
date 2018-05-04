using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace RRLibraryUnitTest.Models
{
    public class MyTestContext : IDbContext
    {
        private List<Restaurant> restRepo;
        private List<Review> revRepo;

        public MyTestContext()
        {

        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }
    }
}
