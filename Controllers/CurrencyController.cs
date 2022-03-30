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
            return View(new AddCurrencyViewModel());
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
                else
                {
                    return View(model);
                }
                //procedojme me shtimin e monedhes
            }
            return View();
        }
       
        public ActionResult Delete(int id,AddCurrencyViewModel model)
        {
            CurrencyManager manager = new CurrencyManager();
            return View(manager.GetCurrencyById(id));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {            
            CurrencyManager manager = new CurrencyManager();
            manager.Delete(id);
            return RedirectToAction("Index",manager.GetCurrencies());
        }
        [HttpPost]
        public ActionResult Edit(int id, AddCurrencyViewModel model)
        {
            CurrencyManager manager = new CurrencyManager();
            manager.Edit(id, model);
            return RedirectToAction("Index", manager.GetCurrencies());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CurrencyManager manager = new CurrencyManager();
            var currency = manager.GetCurrencyById(id);
            return View(currency);

        }
    }
}