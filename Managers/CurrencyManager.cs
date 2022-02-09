using Currency_Exchange2022.Models;
using Currency_Exchange2022.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Managers
{
    public class CurrencyManager
    {
        public List<Currency> GetCurrencies()

        {
            List<Currency> result = new List<Currency>();
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Currencyies where IsActive=1", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Currency()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Code = (string)reader["Code"],
                            });
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool Insert(AddCurrencyViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Currencyies (Code,Name) VALUES (@code,@name)";
                    cmd.Parameters.Add("@code", SqlDbType.Text).Value = model.Code;
                    cmd.Parameters.Add("@name", SqlDbType.Text).Value = model.Name;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        

    }

}