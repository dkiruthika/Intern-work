﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Finalpage()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=xc-db-int2019.cweclpjrmoc6.us-east-1.rds.amazonaws.com,1357;Initial Catalog=XTRACHEF_Freshers;User ID=xcdbAppUser;Password=GJGwAWjB7C2tSSad65NO;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM XTRACHEF_EMPLOYEE WHERE EMPLOYEE_USERNAME=@username AND EMPLOYEE_PASSWORD=@password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    // Login successful
                    return View("Finalpage");
                }
                else
                {
                    // Login failed
                    ModelState.AddModelError("", "Invalid username or password");
                    return View("Index");
                }
            }
        }
    }
}