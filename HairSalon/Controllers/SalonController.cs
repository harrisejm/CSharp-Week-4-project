using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Controllers
{
  public class SalonController : Controller
  {

    [HttpGet("/salon")]
    public ActionResult Index()
    {
        List<Item> allItems = Item.GetAll();
        return View(allItems);
    }

    [HttpGet("/salon/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

  }
}
