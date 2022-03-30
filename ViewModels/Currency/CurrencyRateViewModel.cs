using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Currency_Exchange2022.ViewModels.Currency
{
    public class CurrencyRateViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public decimal Value { get; set; }

        [Required]
        public int BuyCurrencyId { get; set; }

        [Required(ErrorMessage = "Ju lutem specifikoni monedhen e blerjes")]
        public int SelectedBuyCurrency { get; set; }
        public IEnumerable<SelectListItem> BuyCurrency { get; set; }

        [Required(ErrorMessage = "Ju lutem specifikoni tipin e monedhes")]
        public int SelectedSellCurrency { get; set; }
        public IEnumerable<SelectListItem> SellCurrency { get; set; }

    }
}