using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Currency_Exchange2022.ViewModels.Currency
{
    public class AddTransactionViewModel
    {
        [Required]
        public decimal InputCurrencyAmount { get; set; }

        [Required]
        public decimal OutputCurrencyAmount { get; set; }

        [Required(ErrorMessage = "Ju lutem specifikoni tipin e monedhes")]
        public int SelectedInputCurrencyType { get; set; }
        public IEnumerable<SelectListItem> InputCurrencyType { get; set; }

        [Required(ErrorMessage = "Ju lutem specifikoni tipin e monedhes")]
        public int SelectedOutputCurrencyType { get; set; }
        public IEnumerable<SelectListItem> OutputCurrencyType { get; set; }

        [Required]
        public decimal CurrencyRate { get; set; }
    }
}