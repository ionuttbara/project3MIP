using MVCs_project_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCs_project_3.Controllers
{
    public class Shopping_cartController : Controller
    {
        Shopping_cartDbContext scdb = new Shopping_cartDbContext();
        // GET: Shopping_cart
        public ActionResult Index()
        {
            return View(scdb.Carts.ToList());
        }
        public ActionResult Delete(Shopping_cart sc)
        {
            scdb.Entry(sc).State = System.Data.Entity.EntityState.Deleted;
            scdb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}