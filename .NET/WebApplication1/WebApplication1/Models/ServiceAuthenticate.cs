using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class ServiceAuthenticate
    {
        public bool Authenticate(UserData data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection("Data Source=xc-db-int2019.cweclpjrmoc6.us-east-1.rds.amazonaws.com,1357;Initial Catalog=XTRACHEF_Freshers;User ID=xcdbAppUser;Password=GJGwAWjB7C2tSSad65NO;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string query = "SELECT * FROM NewLoginTable WHERE username=@Username ANd password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", data.Username);
                cmd.Parameters.AddWithValue("@Password", data.Password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public string UserAuthenticate(string data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection("Data Source=xc-db-int2019.cweclpjrmoc6.us-east-1.rds.amazonaws.com,1357;Initial Catalog=XTRACHEF_Freshers;User ID=xcdbAppUser;Password=GJGwAWjB7C2tSSad65NO;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string query = "SELECT * FROM NewLoginTable WHERE username=@Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", data);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Debug.WriteLine("This is a debug message");
                    Debug.WriteLine(reader.GetString(reader.GetOrdinal("Roles")));
                    return reader.GetString(reader.GetOrdinal("Roles")); ;
                }
                return "";
            }
            return "";
        }
    }
}