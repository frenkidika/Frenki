using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022
{
    public static class Utils
    {
        public static string ConnectionString
        {
            get {
                
                return "Data Source=ENVI;Initial Catalog=CurrencyExchange;Integrated Security=True"; 
            }
        }
    }
}