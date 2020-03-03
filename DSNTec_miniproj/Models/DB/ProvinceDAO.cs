using DSNTec_miniproj.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DSNTec_miniproj.Models.DB
{
    public class ProvinceDAO
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;



        public List<Province> ListAll()
        {
            try
            {
                List<Province> lst = new List<Province>();


                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand("select_provinces", con);
                    com.CommandType = CommandType.StoredProcedure;

                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new Province
                        {
                            ProvinceID = Convert.ToInt32(rdr["province_id"]),
                            Description = rdr["description"].ToString(),
                        });
                    }

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
    }
}