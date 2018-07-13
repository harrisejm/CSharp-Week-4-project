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
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
    }

    [HttpGet("/salon/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    [HttpPost("/salon")]
    public ActionResult Create()
    {
     Stylist newStylist = new Stylist(Request.Form["new-stylist"]);
     newStylist.Save();
     List<Stylist> allStylists = Stylist.GetAll();
    return View("Index", allStylists);
}

[HttpGet("/client/new")]
public ActionResult StylistList()
{
    return View();
}

// [HttpPost("/client")]
// public ActionResult Create()
// {
//  Stylist newStylist = new Stylist(Request.Form["new-stylist"]);
//  newStylist.Save();
//  List<Stylist> allStylists = Stylist.GetAll();
// return View("StylistList", allStylists);
// }


// [HttpGet("/salon/{id}/update")]
//    public ActionResult UpdateForm(int id)
//    {
//        Stylist thisStylist = Stylist.Find(id);
//        return View(thisStylist);
//    }
//    [HttpPost("/salon/{id}/update")]
//     public ActionResult Update(int id)
//     {
//         Stylist thisStylist = Stylist.Find(id);
//         thisStylist.Edit(Request.Form["updatename"]);
//         return RedirectToAction("Index");
//     }
//
//     [HttpGet("/items/{id}/delete")]
//    public ActionResult Delete(int id)
//    {
//        Stylist thisStylist = Stylist.Find(id);
//        thisStylist.Delete();
//        return RedirectToAction("Index");
//    }





  }
}
