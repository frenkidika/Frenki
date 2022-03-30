using Currency_Exchange2022.Managers;
using Currency_Exchange2022.Models;
using Currency_Exchange2022.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Currency_Exchange2022.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var currencyManager = new CurrencyManager();
            var currencies = currencyManager.GetCurrencies();
            var model = new AddTransactionViewModel();
            model.InputCurrencyType = new SelectList(currencies, "Id", "Code");
            model.OutputCurrencyType = new SelectList(currencies, "Id", "Code");
            model.SelectedOutputCurrencyType = 35;
            return View(model);
        }

        [HttpPost]
        public ActionResult CalculateValue(AddTransactionViewModel model)
        {
            var currencyManager = new CurrencyManager();
            var currencies = currencyManager.GetCurrencies();
            model.InputCurrencyType = new SelectList(currencies, "Id", "Code");
            model.OutputCurrencyType = new SelectList(currencies, "Id", "Code");
            var rate = currencyManager.CalculateCurrencyValue(model.SelectedInputCurrencyType, model.SelectedOutputCurrencyType);
            ModelState.Clear();
            model.OutputCurrencyAmount = rate * model.InputCurrencyAmount;
            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pricing()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Location()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}