using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateTestStandard.Models
{
    public class Order
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipMethod { get; set; }
        public string SubTotal { get; set; }
        public string Tax { get; set; }
        public string Freight { get; set; }
        public string Total { get; set; }
        public string SalesOrderID { get; set; }
    }

}