using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers.RiderController
{
	public class RiderController : Controller
	{

		ATSContext db = new ATSContext();
		[Authorize(Roles = "Admin")]
		[HttpGet]
		public ActionResult RiderList()
		{
			var rid = db.Rider;
			return View( rid.ToList());
		}



		[Authorize(Roles = "Admin")]
		[HttpGet]
		public ActionResult RiderDelete(int id)
		{
			Rider rid = db.Rider.Find(id);
			if (rid == null)
			{
				return HttpNotFound();
			}
			return View(rid);
		}
		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("RiderDelete")]
		public ActionResult BusDeleteConfirmed(int id)
		{
			Rider rid = db.Rider.Find(id);
			if (rid == null)
			{
				return HttpNotFound();
			}
			db.Rider.Remove(rid);
			db.SaveChanges();
			return RedirectToAction("RiderList");
		}
	}
}