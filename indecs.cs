using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class indecs
    {

        public int ID { get; set; }
        public virtual string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }

    public class indecsDBContext :DbContext
    {
        public DbSet<indecs> indecsS { get; set; }
    }
}