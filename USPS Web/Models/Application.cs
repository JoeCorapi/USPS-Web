using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USPS_Web.Models
{
    public class Application
    {
        public string name { get; set; }
        public Guid id { get; set; }
        public string createdon { get; set; }
        public string type{ get; set; }
    }
}