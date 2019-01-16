using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Ticket
    {
        public int id { get; set; } //идентификатор
        public string waynumber { get; set; } // номер маршрута 
        public string begin { get; set; } // начало маршрута 
        public string end { get; set; } // конец маршрута 
        public int pay { get; set; } //цена 
        
        public string clientSurname { get; set; }
        public string clientName { get; set; }


        public int? wayID { get; set; }
        public Way way { get; set; }
    }
}