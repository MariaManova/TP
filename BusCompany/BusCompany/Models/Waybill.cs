 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Way
    {
        public int id { get; set; } //идентификатор 
        public string begin { get; set; } // начало маршрута 
        public string end { get; set; } // конец маршрута 
        public string time { get; set; } //время в пути 
        public int pay { get; set; } //цена 

        public ICollection<Ticket> tickets { get; set; }
        public Way()
        {
            tickets = new List<Ticket>();
        }
    }
}