using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
