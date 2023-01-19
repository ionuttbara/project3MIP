using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Language2;

namespace MVCs_project_3.Models
{
    public class Products
    {
        public int ID { get; set; }

		[Display(Name = "UserName", ResourceType = typeof(ResourceEn))]
		public string Name { get; set; }
		[Display(Name = "Description", ResourceType = typeof(ResourceEn))]
		public string Description { get; set; }

    }

    public class ProductsDbContext : DbContext
    {
        public DbSet <Products> Products { get; set; } 
    }
}