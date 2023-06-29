using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace ProductManagement.Controllers
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
                string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                SqlConnection conn = new SqlConnection(strcon);
                string query = "SELECT * FROM NewLoginTable WHERE username=@Username ANd password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", data.Username);
                cmd.Parameters.AddWithValue("@Password", data.Password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var roles= reader.GetString(reader.GetOrdinal("Roles"));
                    var jwtSecurityToken = Authentication.GenerateJwtToken(data.Username, roles);
                    var validUserName = Authentication.ValidateToken(jwtSecurityToken);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(jwtSecurityToken);

                    var expirationTime = jwtToken.ValidTo;
                    //TempData["Message"] = data.Username;
                    Session["user"] = data;
                    Session["roles"] = reader.GetString(reader.GetOrdinal("Roles"));
                    Session["mail"] = data.Username;
                    //TempData["roles"] = reader.GetString(reader.GetOrdinal("Roles"));
                    if (validUserName!=null)
                    {
                        Session["TokenExpirationTime"] = expirationTime;
                        return RedirectToAction("LoginSuccess", new { token = jwtSecurityToken });
                    }
                    return RedirectToAction("Index");
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
        public ActionResult RegenerateToken()
        {
            // Generate a new token for the current user
            var username = User.Identity.Name;
            var roles = Session["roles"] as string; // Assuming roles are stored in the session
            var newToken = Authentication.GenerateJwtToken(username, roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(newToken);

            var expirationTime = jwtToken.ValidTo;
            Session["TokenExpirationTime"] = expirationTime;

            // Return the new token as JSON
            return Json(new { success = true });
        }
        public ActionResult LoginSuccess(string token)
        {
            bool isTokenExpired = string.IsNullOrEmpty(token) || Authentication.IsTokenExpired(token);
            ViewBag.TokenExpirationTime = isTokenExpired ? 0 : Authentication.GetTokenExpirationTime(token);

            return View();
        }
        public ActionResult ClearToken()
        {
            return View("Index");
        }


    }
}
