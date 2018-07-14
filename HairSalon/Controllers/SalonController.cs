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

////////


[HttpGet("/clients")]
public ActionResult ClientList()
{
    return View(Client.GetAll());
}
// [HttpGet("/clients/new")]
//    public ActionResult EditClients()
//    {
//        return View();
//    }
[HttpGet("/clients/{id}/new")]
    public ActionResult EditClients(int id)
    {
        Stylist thisStylist = Stylist.Find(id);
      //  thisStylist.Save();
    //   List<Stylist> allStyllists = Stylist.GetAll();
        return View(thisStylist);
    }
[HttpPost("/clients/list")]
public ActionResult Edit()
{
 Client newClient = new Client(Request.Form["new-client"], int.Parse(Request.Form["new-stylistId"]));
 newClient.Save();
 //int test = int.Parse(Request.Form["new-stylistId"]);
// List<Client> allClient = Client.Find(test);
//  Client testt = Client.Find(test);
//return RedirectToAction("ClientList");

  return View("ClientList", Client.Find(int.Parse(Request.Form["new-stylistId"])));
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
