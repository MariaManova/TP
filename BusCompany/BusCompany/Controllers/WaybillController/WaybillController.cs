using BusCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCompany.Controllers
{
    public class WayController : Controller
    {

        ATSContext db = new ATSContext(); //создаем контекст данных

        [HttpGet]
        public ActionResult WaysList()
        {
            var ways = db.Ways;
            return View(ways.ToList());
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public ActionResult WayAdd(int ID)
        {
            Ticket tic = db.Tickets.Find(ID);
            ViewBag.Request = tic;
            return View();
        }
		[Authorize(Roles = "Admin")]
		[HttpPost]
        public ActionResult WayAdd(Way model)
        {
            Way way = new Way
            {
                begin = model.begin,
                end = model.end,
                pay = model.pay,
                time = model.time
            };
            db.Ways.Add(way);
            db.SaveChanges();

            return RedirectToAction("WayList", "Way");
        }
    }
}