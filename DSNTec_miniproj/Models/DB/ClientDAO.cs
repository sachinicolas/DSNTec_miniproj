using DSNTec_miniproj.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DSNTec_miniproj.Models.DB
{
    public class ClientDAO
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        


        public List<Client> ListAll()
        {
            try
            {
                List<Client> lst = new List<Client>();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand("select_clients", con);
                    com.CommandType = CommandType.StoredProcedure;

                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new Client
                        {
                            ClientID = Convert.ToInt32(rdr["client_id"]),
                            Name = rdr["name"].ToString(),
                            //ProvinceID = Convert.ToInt32(rdr["province_id"]),
                            Province = new Province(Convert.ToInt32(rdr["province_id"]), rdr["description"].ToString())
                        });
                    }

                    return lst;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Add(Client c)
        {
            try
            {
                int i;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand("insert_update_client", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@client_id", c.ClientID);
                    com.Parameters.AddWithValue("@name", c.Name);
                    com.Parameters.AddWithValue("@province_id", c.Province.ProvinceID);
                    com.Parameters.AddWithValue("@Action", "insert");

                    i = com.ExecuteNonQuery();
                }

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    
        public int Update(Client c)
        {
            try
            {
                int i;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand("insert_update_client", con);

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@client_id", c.ClientID);
                    com.Parameters.AddWithValue("@name", c.Name);
                    com.Parameters.AddWithValue("@province_id", c.Province.ProvinceID);
                    com.Parameters.AddWithValue("@Action", "update");

                    i = com.ExecuteNonQuery();
                }

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int id)
        {
            try
            {
                int i;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand("delete_client", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@client_id", id);

                    i = com.ExecuteNonQuery();
                }

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}