using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
        int SaveChanges();
    }
}
