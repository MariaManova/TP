using System.Web.Mvc;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class HomeController : Controller
    {
        ATSContext db = new ATSContext(); //создаем контекст данных

        public ActionResult Index()
        {
            return View(); //возвращаем представление
        }  
    }
}