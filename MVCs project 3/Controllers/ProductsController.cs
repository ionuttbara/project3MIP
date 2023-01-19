using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using MVCs_project_3.Models;




namespace MVCs_project_3.Controllers
{
    
    public class ProductsController : Controller
    {
        private ProductsDbContext pdb = new ProductsDbContext();
        Shopping_cartDbContext scdb = new Shopping_cartDbContext();


        // GET: Products
        public ActionResult Index()
        {
            return View(pdb.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Products prd= new Products();
            return View(prd);
        }
        [HttpPost]
        public ActionResult Create(Products prd)
        {
            if (prd.Name.Length > 30 && prd.Description.Length>100)
            {
                //System.Console.WriteLine("Nume prea lung");
                return RedirectToAction("Index");
            }
            else
            {
                pdb.Products.Add(prd);
                pdb.SaveChanges();
                return RedirectToAction("Index");
            }

                
            
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Products prd = pdb.Products.Find(Id);
            return View(prd);
        }
        [HttpPost]
        public ActionResult Edit(Products prd)
        {
            if (prd.Name.Length > 30 && prd.Description.Length > 100)
            {
                return RedirectToAction("Index");
            }
            else
            {
                pdb.Products.Add(prd);
                pdb.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Products prd=pdb.Products.Find(Id);
            return View(prd);
        }
        [HttpPost]
        public ActionResult Delete(Products prd)
        {
            pdb.Entry(prd).State = System.Data.Entity.EntityState.Deleted;
            pdb.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Buy(int Id)
        {
            
            
                Products prd = pdb.Products.Find(Id);
                Shopping_cart sc = new Shopping_cart();
                sc.ID = prd.ID;
                sc.Name = prd.Name;
                sc.Description = prd.Description;
            using (Shopping_cartDbContext scdb = new Shopping_cartDbContext())
            {
                scdb.Carts.Add(sc);
                scdb.SaveChanges();
                

            }

            return RedirectToAction("Index");
            
            
        }
        [HttpPost]
        public ActionResult Buy(Shopping_cart sc)
        {
            using (Shopping_cartDbContext scdb = new Shopping_cartDbContext())
            {
                scdb.Carts.Add(sc);
                scdb.SaveChanges();
                return View("Index");
                
            }
        }
        [HttpGet]
        public ActionResult Review(int Id)
        {
            Products prd = pdb.Products.Find(Id);
            Reviews rw = new Reviews();
            using (ReviewsDbContext rdb = new ReviewsDbContext())
            {
                rdb.SaveChanges();
                return RedirectToAction("Index","Reviews");
            }
            
        }
        [HttpPost]
        public ActionResult Review(Reviews rw)
        {
            using(ReviewsDbContext rdb=new ReviewsDbContext())
            {
                rdb.Reviews.Add(rw);
                rdb.SaveChanges();
                return View("Index");
            }
        }
        public ActionResult Details (int? Id)
        {
            Products prd= pdb.Products.Find(Id);
            return View(prd);
        }

    }
}