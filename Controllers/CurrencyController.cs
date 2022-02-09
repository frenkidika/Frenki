using Currency_Exchange2022.Managers;
using Currency_Exchange2022.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Currency_Exchange2022.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult Index()
        {
            //get list of all currencies
            //ToDo:TBD
            var currencyManager = new CurrencyManager();
            var result = currencyManager.GetCurrencies();
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddCurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currencyManager = new CurrencyManager();
                var res = currencyManager.Insert(model);
                if (res)
                {
                    return RedirectToAction("Index", "Currency");
                }
                //procedojme me shtimin e monedhes
            }
            return View();
        }
    }
}