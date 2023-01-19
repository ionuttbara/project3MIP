using Language2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace MVCs_project_3.Models
{
    public class Shopping_cart
    {
        public int ID { get; set; }
	//	[Display(Name = "Name of the product", ResourceType = typeof(ResourceEn))]
		public string Name { get; set; }
	//	[Display(Description = "Name of the product", ResourceType = typeof(ResourceEn))]
		public string Description { get; set; }
    }
    public class Shopping_cartDbContext : DbContext
    {
        public DbSet <Shopping_cart> Carts { get; set; } 
    }
}