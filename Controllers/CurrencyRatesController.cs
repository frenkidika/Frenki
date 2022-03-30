using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Currency_Exchange2022.Controllers
{
    public class CurrencyRatesController : Controller
    {
        // GET: CurrencyRates
        public ActionResult Index()
        {
            return View();
        }
    }
}