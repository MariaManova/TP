using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers.ATSController
{
	public class ATSController : Controller
	{

		ATSContext db = new ATSContext(); //создаем контекст данных

		[HttpGet]
		public ActionResult ATSList()
		{
			var buses = db.ATS;
			return View(buses.ToList());
		}
		[Authorize (Roles = "Admin")]
        [HttpGet]
        public ActionResult ATSAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ATSAdd(ATS bus)
        {
            db.ATS.Add(bus);
            db.SaveChanges();
            return RedirectToAction("ATSList");
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public ActionResult ATSEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ATS bus = db.ATS.Find(id);
            if (bus != null)
            {
                return View(bus);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult ATSEdit(ATS bus)
        {
            db.Entry(bus).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ATSList");
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public ActionResult ATSDelete(int id)
        {
            ATS bus = db.ATS.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        [HttpPost, ActionName("ATSDelete")]
        public ActionResult BusDeleteConfirmed(int id)
        {
            ATS bus = db.ATS.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            db.ATS.Remove(bus);
            db.SaveChanges();
            return RedirectToAction("ATSList");
        }
    }
}