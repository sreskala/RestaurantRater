using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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