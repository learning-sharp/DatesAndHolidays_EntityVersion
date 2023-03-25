using System;
using System.Data.Entity;

namespace DatesAndHolidays_EntityVersion.DataBase
{
    class MyDbContext : DbContext 
    {
        public MyDbContext() : base("DBConnection")
        { 
        }

        public DbSet<Day> Days { get; set; }
    }
}
