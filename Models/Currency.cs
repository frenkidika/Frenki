using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Models
{
    public class Currency
    {
        public int ID_M { get; set; }

        public string Name { get; set; }



        public List<Currency> GetCurrencies()

        {
            List<Currency> result = new List<Currency>();
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Books", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Currency()
                            {
                                ID_M = (int)reader["ID"],
                                Name = (string)reader["Name of Currency"],

                            });
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public static bool Insert(Currency currency)
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
                    cmd.CommandText = "INSERT INTO Currency (Currency) VALUES (@curr)";
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool Delete(string ID_M)
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
                    cmd.Parameters.Add(curr);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "DELETE INTO Currency (Currency) VALUES (@curr)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}