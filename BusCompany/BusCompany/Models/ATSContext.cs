using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BusCompany.Models
{
    public class ATSContext : DbContext
    {
        public DbSet<ATS> ATS { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Way> Ways { get; set; }
		public DbSet<Rider> Rider { get; set; }
    }

    public class BusDbInitializer : DropCreateDatabaseAlways<ATSContext>
    {
        protected override void Seed(ATSContext db)
        {
            db.ATS.Add(new ATS { marka = "PAZ", number = "421", fuel = 22, waynumber = 12454 });

            base.Seed(db);
        }
    }
}