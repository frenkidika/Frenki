using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Models
{
    public class CurrencyRates
    {
        public int ID_M { get; set; }

        public decimal Value { get; set; }


        public List<CurrencyRates> GetCurrencyRates()

        {
            List<CurrencyRates> result = new List<CurrencyRates>();
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CurrencyRates", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new CurrencyRates()
                            {
                                ID_M = (int)reader["ID"],
                                Value = (decimal)reader["Value"],

                            });
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool Insert(Currency currency)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    SqlParameter curr = new SqlParameter("curr", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Add(curr);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO CurrencyRates (Currency) VALUES (@curr)";
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(string ID_M)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    SqlParameter curr = new SqlParameter("curr", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Remove(curr);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "DELETE INTO CurrencyRates (Currency) VALUES (@curr)";
                    cmd.ExecuteNonQuery();

                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}