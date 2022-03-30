using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.ViewModels.Currency
{
    public class AddCurrencyViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal BuyRate { get; set; }
        [Required]
        public decimal SellRate { get; set; }
        [Required]
        public int IsActive { get; set; }

    }
}