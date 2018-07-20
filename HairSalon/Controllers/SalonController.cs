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
    //  Client newClient = new Client("Welcome", allStylists[allStylists.Count-1].GetId(), Request.Form["new-stylist"]);
     Client newClient = new Client("Welcome");
     newClient.Save();

    return View("Index", allStylists);
}

////////

[Produces("text/html")]
[HttpGet("/clients/{id}/all")]
public ActionResult ClientList(int id)
{
    Dictionary<string, object> model = new Dictionary<string, object>();

    List<Client> selectedClients = Stylist.GetClientsByStylist(id);
    Stylist selectedStylist = Stylist.Find(id);

    model.Add("clientList", selectedClients);
    model.Add("StylistName", selectedStylist);

  return View(model);
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
 Client newClient = new Client(Request.Form["new-client"]);
 newClient.Save();
 Stylist.AddNewFlight();
  return View("ClientList", Client.Find(int.Parse(Request.Form["new-stylistId"])));
}
//Stylist.GetClientsByStylist();

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

/////////////////

 [HttpGet("salon/specialty")]
  public ActionResult Specialties()
    {
     List<Specialty> allSpecialties = Specialty.GetAll();
     return View(allSpecialties);
    }

    [HttpGet("/salon/specialty/new")]
    public ActionResult addSpecialty()
    {
      return View();
    }

    [HttpPost("/salon/specialty")]
    public ActionResult CreateSpecialty()
    {
    Specialty newSpecialty = new Specialty(Request.Form["new-specialty"]);
     newSpecialty.Save();
     List<Specialty> allSpecialty = Specialty.GetAll();
   return View("Specialties", allSpecialty);
  }


  [HttpGet("/specialty/{id}/all")]
  public ActionResult stylistsSpecialties(int id)
  {
      Dictionary<string, object> model = new Dictionary<string, object>();

      List<Specialty> selectedSpecialty = Stylist.GetSpecialtyByStylist(id);
      Stylist selectedStylist = Stylist.Find(id);

      model.Add("SpecialtyList", selectedSpecialty);
      model.Add("StylistName", selectedStylist);

      return View(model);
  }

  [HttpGet("/salon/specialty/add")]
  public ActionResult addSpecialtyStylist()
  {
    List<Specialty> allSpecialty = Specialty.GetAll();

    return View(allSpecialty);
  }



 // [HttpPost("/clients/update")]
 //    public ActionResult Update(int id)
 //    {
 //      // Stylist thisStylist = Stylist.Find(id);
 //      // thisStylist.Edit(Request.Form["updatename"]);
 //      // return RedirectToAction("Index");
 //      Client selectClient = Client.FindClient(id);
 //      selectClient.Edit(Request.Form["new-client"], 1, Request.Form["new-stylistName"]);
 //
 //      List<Client> allClient = Client.GetAll();
 //      return View("allClients", allClient);
 //    }


    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
       Client selectClient = Client.FindClient(id);
       List<Stylist> remainClient = Client.GetStylistByClient(selectClient.GetId());

      // int stylistOutput = selectClient.GetStylistByClient()

    //  List<Client> remainClient = Client.Find(stylistOutput);
    //  List<Client> remainClient = Client.GetClientsByStylist()

       selectClient.Delete();

       return View(remainClient);
    }





  }
}
