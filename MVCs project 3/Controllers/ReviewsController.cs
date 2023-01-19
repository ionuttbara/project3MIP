using MVCs_project_3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCs_project_3.Controllers
{
    public class ReviewsController : Controller
    {
        ReviewsDbContext rdb= new ReviewsDbContext();
        // GET: Reviews
        public ActionResult Index()
        {
            return View(rdb.Reviews.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Reviews rw= new Reviews();
            return View(rw);
        }
       

        [HttpPost]
        public ActionResult Create(Reviews rw)
        {
            rdb.Reviews.Add(rw);
            rdb.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Reviews rw = rdb.Reviews.Find(Id);
            return View(rw);
        }
        [HttpPost]
        public ActionResult Edit(Reviews rw)
        {
            rdb.Reviews.AddOrUpdate(rw);
            rdb.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Reviews rw = rdb.Reviews.Find(Id);
            return View(rw);
        }
        [HttpPost]
        public ActionResult Delete(Reviews rw)
        {
            rdb.Entry(rw).State = System.Data.Entity.EntityState.Deleted;
            rdb.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}