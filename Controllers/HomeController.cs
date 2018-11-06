using CandidateTestStandard.SampleGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTestStandard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string firstName, string lastName, string fromDate, string toDate, string orderType)
        {
            var result = SampleDataSearch.SearchOrder(firstName, lastName, fromDate, toDate, orderType);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderInfo()
        {
            try
            {
                int t = int.Parse(SalesOrderID.value);
            }
            catch
            {
                return null;
            }
            var result = SampleDataSearch.ProductInfo(SalesOrderID.value);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductInfo(string id)
        {
            SalesOrderID.value = id;

            return View();
        }
    }
}