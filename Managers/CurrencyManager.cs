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
        public List<AddCurrencyViewModel> GetCurrencies()
        {
            List<AddCurrencyViewModel> result = new List<AddCurrencyViewModel>();
            try
            {
                
                using(SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand("SELECT * FROM Currencyies", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new AddCurrencyViewModel()
                            {
                                Id = (int)reader["Id"],
                                Code = (String)reader["Code"],
                                Name = (String)reader["Name"],
                                BuyRate = (Decimal)reader["BuyRate"],
                                SellRate = (Decimal)reader["SellRate"]
                            });
                        }
                        return result;
                        con.Close();
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public bool Insert(AddCurrencyViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"INSERT INTO Currencyies(Code,Name,IsActive,BuyRate,SellRate) VALUES('{model.Code}','{model.Name}',1,{model.BuyRate},{model.SellRate})", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        if(cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                        con.Close();
                    }
                    /*
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Currencyies (Code,Name,BuyRate,SellRate) VALUES (@code,@name,@BuyRate,@SellRate)";
                    cmd.Parameters.Add("@code", SqlDbType.Text).Value = model.Code;
                    cmd.Parameters.Add("@name", SqlDbType.Text).Value = model.Name;
                    cmd.Parameters.Add("@BuyRate", SqlDbType.Decimal).Value = model.BuyRate;
                    cmd.Parameters.Add("@SellRate", SqlDbType.Decimal).Value = model.SellRate;
                    cmd.ExecuteNonQuery();

                    return true;
                    */
                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

       
        public bool Delete(int id)
        {
            try 
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM Currencyies WHERE Id={id}", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        if(cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;

        }

        public bool Edit(int id, AddCurrencyViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Currencyies SET Code=@code, Name=@name, BuyRate=@buyRate, SellRate =@sellRate WHERE Id = @id", con))
                    {
                        cmd.Parameters.Add("@code", SqlDbType.Text).Value = model.Code;
                        cmd.Parameters.Add("@name", SqlDbType.Text).Value = model.Name;
                        cmd.Parameters.Add("@buyRate", SqlDbType.Decimal).Value = model.BuyRate;
                        cmd.Parameters.Add("@sellRate", SqlDbType.Decimal).Value = model.SellRate;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.CommandType = CommandType.Text;
                        if(cmd.ExecuteNonQuery()==1)
                        {
                            return true;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return false;

        }
        public AddCurrencyViewModel GetCurrencyById(int id)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Currencyies WHERE Id={id}", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            return new AddCurrencyViewModel()
                            {
                                Id = (int)reader["Id"],
                                Code = (String)reader["Code"],
                                Name = (String)reader["Name"],
                                BuyRate = (Decimal)reader["BuyRate"],
                                SellRate = (Decimal)reader["SellRate"]
                            };
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public decimal CalculateCurrencyValue(int buyCurrencyId, int sellCurrencyId)
        {
            decimal outputValue = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT TOP 1 [Value] FROM CurrencyRates WHERE BuyCurrencyId = @buyCurrencyId AND SellCurrencyId = @sellCurrencyId AND Active = 1", con))
                    {
                        cmd.Parameters.Add("@buyCurrencyId", SqlDbType.Int).Value = buyCurrencyId;
                        cmd.Parameters.Add("@sellCurrencyId", SqlDbType.Int).Value = sellCurrencyId;
                        cmd.CommandType = CommandType.Text;
                        outputValue = (decimal)cmd.ExecuteScalar();
                        return outputValue;                    }
                }

            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }

}