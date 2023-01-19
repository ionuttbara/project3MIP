using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCs_project_3.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Message { get; set; }
    }

    public class ReviewsDbContext : DbContext
    {
        public DbSet <Reviews> Reviews { get; set; }
    }
}