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




[HttpGet("/clients")]
public ActionResult ClientList()
{
    return View(Client.GetAll());
}

[HttpGet("/clients/new")]
public ActionResult EditClients()
{
    return View();
}

[HttpPost("/clients")]
public ActionResult Edit()
{
 Client newClient = new Client(Request.Form["new-client"], int.Parse(Request.Form["new-assignment"]));
 newClient.Save();
 List<Client> allClient = Client.GetAll();
//return View("ClientList", allClient);
//return RedirectToAction("ClientList");
  return View("ClientList", allClient);
}


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
