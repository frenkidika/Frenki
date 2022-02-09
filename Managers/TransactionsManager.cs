using Currency_Exchange2022.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Managers
{
    public class TransactionsManager
    {
        public bool Insert(AddTransactionViewModel model)
        {
            try
            {
                var outputCurrencyAmount = model.InputCurrencyAmount * model.CurrencyRate;
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("inputCurrType", model.InputCurrencyType));
                        cmd.Parameters.Add(new SqlParameter("outputCurrType", model.OutputCurrencyType));
                        cmd.Parameters.Add(new SqlParameter("inputCurrAmount", model.InputCurrencyAmount));
                        cmd.CommandText = "INSERT INTO Transaction (inputCurrType, outputCurrType, inputCurrAmount) VALUES (@inputCurrType, @outputCurrType, @inputCurrAmount, @outputCurrencyAmount ) ";
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
