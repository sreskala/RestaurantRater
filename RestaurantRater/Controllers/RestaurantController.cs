using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        //private field
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //GET: RESTAURANT/DELTE/{id}
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _db.Restaurants.Find(id);
            if(restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        //POST: RESTAURANT/DELETE/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);

            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }
    }
}