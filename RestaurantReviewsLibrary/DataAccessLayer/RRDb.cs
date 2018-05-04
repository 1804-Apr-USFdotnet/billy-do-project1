namespace DataAccessLayer
{

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using DataAccessLayer.Models;

    public class RRDb : DbContext, IDbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLayer.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public RRDb()
            : base("name=RRDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntities> Restaurants { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        public override int SaveChanges()
        {
            // TODO: Do other stuff? Ensure DateCreated/Modified is set properly here?
            return base.SaveChanges();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}