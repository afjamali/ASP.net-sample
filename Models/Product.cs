using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateTestStandard.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Discount { get; set; }
        public string LineTotal { get; set; }
    }

}