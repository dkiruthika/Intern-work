using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LoginPage.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginPage.Models
{
    public class dbClass
    {
        SqlConnection con = new SqlConnection("Data Source=xc-db-int2019.cweclpjrmoc6.us-east-1.rds.amazonaws.com,1357;Initial Catalog=XTRACHEF_Freshers;User ID=xcdbAppUser;Password=GJGwAWjB7C2tSSad65NO;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public int LoginCheck(string username, string password)
        {
            SqlCommand com = new SqlCommand("Sp_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", username);
            com.Parameters.AddWithValue("@pswd", password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}