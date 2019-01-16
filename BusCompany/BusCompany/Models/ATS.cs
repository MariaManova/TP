using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class ATS
    {
        public int id { get; set; } //идентификатор
        public string marka { get; set; } // марка атс
        public string number { get; set; } //номер атс
        public int fuel { get; set; } // расход топлива
        public int waynumber { get; set; } //номер маршрута


        public ICollection<Ticket> tickets { get; set; }
        public ATS()
        {
            tickets = new List<Ticket>();
        }
    }
}