using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class SchedulingAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SchedulingAppContext() : base("name=SchedulingAppContext")
        {
        }
                
        public System.Data.Entity.DbSet<SchedulingApp.Models.Appointment> Appointment { get; set; }
        public System.Data.Entity.DbSet<SchedulingApp.Models.Customer> Customer { get; set; }
        public System.Data.Entity.DbSet<SchedulingApp.Models.Worker> Worker { get; set; }
    }
}
