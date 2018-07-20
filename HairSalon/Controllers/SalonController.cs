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

     Client newClient = new Client("Welcome", allStylists[allStylists.Count-1].GetId(), Request.Form["new-stylist"]);
     newClient.Save();

    return View("Index", allStylists);
}

////////

[Produces("text/html")]
[HttpGet("/clients/{id}/all")]
public ActionResult ClientList(int id)
{
    return View(Client.Find(id));
}

[HttpGet("/clients/{id}/new")]
    public ActionResult EditClients(int id)
    {
        Stylist thisStylist = Stylist.Find(id);
        return View(thisStylist);
    }

[HttpPost("/clients/list")]
public ActionResult Edit()
{
 Client newClient = new Client(Request.Form["new-client"], int.Parse(Request.Form["new-stylistId"]), Request.Form["new-stylistName"]);
 newClient.Save();
  return View("ClientList", Client.Find(int.Parse(Request.Form["new-stylistId"])));
}

[HttpGet("/clients/list/all")]
    public ActionResult allClients()
    {
        List<Client> allClient = Client.GetAll();
        return View(allClient);
    }


[HttpGet("/clients/{id}/update")]
   public ActionResult EditClientsAll(int id)
   {

      // Stylist thisStylist = Stylist.Find(id);
        List<Stylist> thisStylist = Stylist.GetAll();
       return View(thisStylist);
   }

 [HttpPost("/clients/update")]
    public ActionResult Update(int id)
    {
      // Stylist thisStylist = Stylist.Find(id);
      // thisStylist.Edit(Request.Form["updatename"]);
      // return RedirectToAction("Index");
      Client selectClient = Client.FindClient(id);
      selectClient.Edit(Request.Form["new-client"], 1, Request.Form["new-stylistName"]);

      List<Client> allClient = Client.GetAll();
      return View("allClients", allClient);
    }


    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
       Client selectClient = Client.FindClient(id);
       int stylistOutput = selectClient.GetStylistId();
        List<Client> remainClient = Client.Find(stylistOutput);

        selectClient.Delete();
      //  Stylist thisStylist = Stylist.Find(id);

        //Client.Find(id);
      //  return RedirectToAction("ClientList", Client.Find(id));
       return View(remainClient);
    }


//     [HttpGet("/items/{id}/delete")]
//    public ActionResult Delete(int id)
//    {
//        Stylist thisStylist = Stylist.Find(id);
//        thisStylist.Delete();
//        return RedirectToAction("Index");
//    }



  }
}
