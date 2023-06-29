using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(UserData data)
        {
            UserData model = new UserData();

            if (ModelState.IsValid)
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

                    //TempData["Message"] = data.Username;
                    Session["user"] = data;
                    Session["roles"] = reader.GetString(reader.GetOrdinal("Roles"));
                    Session["mail"] = data.Username;
                    //TempData["roles"] = reader.GetString(reader.GetOrdinal("Roles"));
                    //return RedirectToAction("LoginSuccess");
                    return RedirectToAction("Welcome", "WebApp", new { area = "Business" });
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid UserName or Password";
                    Session.Clear();
                    return View("Index");
                }
            }

            return View(model);
        }


    }
}