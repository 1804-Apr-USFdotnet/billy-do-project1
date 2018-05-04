using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Restaurant> Restaurants { get; }
        IRepository<Review> Reviews { get; }
        void Commit();
    }
}
