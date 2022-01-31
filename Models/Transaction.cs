using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public decimal InputCurrencyAmount { get; set; }

        public decimal OutputCurrencyAmount { get; set; }

        public int InputCurrencyType { get; set; }

        public decimal OutputCurrencyType { get; set; }

        public bool Insert(int inputCurrencyType, int outputCurrencyType, decimal inputCurrencAmount, decimal currencyRate)
        {
            try
            {


                var outputCurrencyAmount = inputCurrencAmount * currencyRate;
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("inputCurrType", inputCurrencyType));
                        cmd.Parameters.Add(new SqlParameter("outputCurrType", outputCurrencyType));
                        cmd.Parameters.Add(new SqlParameter("inputCurrAmount", inputCurrencAmount));
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