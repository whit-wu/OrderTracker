using Microsoft.EntityFrameworkCore;
using OrderTracker.Model;
using System;
using System.Diagnostics.CodeAnalysis;

namespace OrderTracker.Data
{
    public class OrderTrackerContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public bool IsUnitTestContext { get; set; }

        private readonly string connectionString;

        public string DbPath { get; private set; }



        // this is the constructor we use when setting up a context for our actual app.  it will set the path to 
        // point to a persistant db. 
        public OrderTrackerContext(bool isUnitTestContext)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "OrderTracker.db");
            IsUnitTestContext = isUnitTestContext;
        }



        // this is the constructor that gets called by our unit test project.  we have already set the options so an 
        // in memroy db is used.
        public OrderTrackerContext([NotNullAttribute] DbContextOptions options, bool isUnitTestContext) : base(options)
        {
            IsUnitTestContext = isUnitTestContext;
        }



        // normally this would be the type of constructor we would use when setting up a dbcontext.
        // the options parameter would be set to either use an in-memory db or actual one.
        // since we are using sqlLite for both persistant and in-memory dbs, we need to get
        // a little hacky in some areas.
        public OrderTrackerContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {


            // here we are setting our db path if our context is not making use of unit tests.
            // in the unit tests, we setup our options to use SqlLite as well, but we set it to
            // be an in memory db
            if (!IsUnitTestContext)
            {
                options.UseSqlite($"Data Source = ../OrderTracker.Data/OrderTracker.db");
            }
        }


        // you can use this method here to setup contraints on your model properties.
        // try go google fluent api and figure out how we can set each model's id to be unique
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}