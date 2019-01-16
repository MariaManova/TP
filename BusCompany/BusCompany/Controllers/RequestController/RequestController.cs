using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BusCompany.Controllers.TicketController
{
    public class TicketController : Controller
    {
        ATSContext db = new ATSContext(); //создаем контекст данных

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        [HttpGet]
        public ActionResult TicketsList()
        {
            var tickets = db.Tickets.Include(p => p.way);
            return View(tickets.ToList());
        }

        [HttpGet]
        public ActionResult TicketAdd(int ID)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                Way wayID = db.Ways.Find(ID);
                Ticket req = new Ticket();
                ViewBag.Ways = wayID;
                ViewBag.User = user;
                return View();
            };
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult TicketAdd(Ticket model)
        {
            Ticket ticket = new Ticket
            {
                clientSurname = model.clientSurname,
                clientName = model.clientName,
                waynumber = model.waynumber,
                begin = model.begin,
                end = model.end,
                pay = model.pay,
                
                
                

            };
            db.Tickets.Add(ticket);
            db.SaveChanges();

            return RedirectToAction("ATSList", "ATS");
        }

        [HttpGet]
        public ActionResult TicketDelete(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ATS way = db.ATS.Find(ticket.wayID);
            ViewBag.Way = way;
            return View(ticket);
        }

        [HttpPost, ActionName("TicketDelete")]
        public ActionResult TicketDeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("TicketList");
        }
    }
}