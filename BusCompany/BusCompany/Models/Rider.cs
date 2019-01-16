using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
	public class Rider
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string adress { get; set; }
		public string patronymic { get; set; }
		public int phone { get; set; }
		public int atsnumber { get; set; }

	}
}