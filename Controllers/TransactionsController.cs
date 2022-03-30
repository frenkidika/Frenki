using Currency_Exchange2022.Managers;
using Currency_Exchange2022.ViewModels.Currency;
using System.Web.Mvc;

namespace Currency_Exchange2022.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        public ActionResult Index()
        {
            var currencyManager = new CurrencyManager();
            var currencies = currencyManager.GetCurrencies();
            var model = new AddTransactionViewModel();
            model.InputCurrencyType = new SelectList(currencies, "Id", "Code");
            model.OutputCurrencyType = new SelectList(currencies, "Id", "Code");
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

        public ActionResult Add()
        {
            var currencyManager = new CurrencyManager();
            var currencies = currencyManager.GetCurrencies();
            var model = new AddTransactionViewModel
            {
                InputCurrencyType = new SelectList(currencies, "Id", "Code"),
                OutputCurrencyType = new SelectList(currencies, "Id", "Code")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transactionsManager = new TransactionsManager();
                var res = transactionsManager.Insert(model);
                if (res)
                {
                    return RedirectToAction("Index", "Transaction");
                }
            }
            return View();
        }

        [HttpPost]

        public ActionResult Transaction()
        {
            return View();  
        }
    }
}