using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Controllers
{
  public class SalonController : Controller
  {

    //****STYLISTS****

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
      Client newClient = new Client("Welcome");
      newClient.Save();
      return View("Index", allStylists);
    }

    [HttpGet("/stylist/{id}/delete")]
    public ActionResult DeleteStylist(int id)
    {
      Stylist selectStylist = Stylist.Find(id);
      selectStylist.Delete();
      selectStylist.DeleteFromJoin();

      return View();
    }

        //Change stylist name
        [HttpGet("/stylist/{id}/stylist")]
        public ActionResult EditStylistName(int id)
        {
          Stylist foundStylist = Stylist.Find(id);

          return View(foundStylist);
        }

        [HttpPost("/stylist/{id}/name/new")]
        public ActionResult EditStylsitNameFinal(int id)
        {
          Stylist foundStylist = Stylist.Find(id);
          foundStylist.Edit(id, Request.Form["new-stylist"]);
          List<Stylist> allStylists = Stylist.GetAll();

          return View("Index", allStylists);
        }

////****CLIENTS******
    ///show list of clients for a stylist
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

    //add new client to stylist
    [HttpGet("/clients/{id}/new")]
    public ActionResult EditClients(int id)
    {
      Stylist thisStylist = Stylist.Find(id);

      return View(thisStylist);
    }

    //display list after adding new client
    [HttpPost("/clients/{id}/list")]
    public ActionResult Edit(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();

      Client newClient = new Client(Request.Form["new-client"]);
      newClient.Save();
      Stylist.AddNewClient(id, newClient.GetId());

      List<Client> selectedClients = Stylist.GetClientsByStylist(id);
      Stylist selectedStylist = Stylist.Find(id);

      model.Add("clientList", selectedClients);
      model.Add("StylistName", selectedStylist);

      return View("ClientList", model);
    }
    /////////////Edit client's name
    [HttpGet("/clients/{id}/name")]
    public ActionResult EditClientName(int id)
    {
      Client foundClient = Client.FindClient(id);

      return View(foundClient);
    }
    //
    [HttpPost("/clients/{id}/name/new")]
    public ActionResult EditClientNameFinal(int id)
    {
      Client foundClient = Client.FindClient(id);
      foundClient.Edit(id, Request.Form["new-client"]);

      Dictionary<string, object> model = new Dictionary<string, object>();

      List<Stylist> stylistMain = Client.GetStylistByClient(id);
      Stylist selectedStylist = stylistMain[0];
      int stylistId = selectedStylist.GetId();

      List<Client> selectedClients = Stylist.GetClientsByStylist(stylistId);

      model.Add("clientList", selectedClients);
      model.Add("StylistName", selectedStylist);

      return View("ClientList", model);
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult DeleteClient(int id)
    {
      Client selectClient = Client.FindClient(id);
      List<Stylist> foundStylist = Client.GetStylistByClient(id);

      selectClient.Delete();
      selectClient.DeleteFromJoin();

      return View(foundStylist);
    }





//*****SPECIALTIES*******

    [HttpGet("salon/specialty")]
    public ActionResult Specialties()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();

      return View(allSpecialties);
    }
    //add
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
    public ActionResult StylistsSpecialties(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();

      List<Specialty> selectedSpecialty = Stylist.GetSpecialtyByStylist(id);
      Stylist selectedStylist = Stylist.Find(id);

      model.Add("SpecialtyList", selectedSpecialty);
      model.Add("StylistName", selectedStylist);

      return View(model);
    }

    [HttpGet("/salon/specialty/{id}/add")]
    public ActionResult addSpecialtyStylist(int id)
    {

      Dictionary<string, object> model = new Dictionary<string, object>();

      Stylist selectedStylist = Stylist.Find(id);
      List<Specialty> allSpecialty = Specialty.GetAll();

      model.Add("SpecialtyList", allSpecialty);
      model.Add("StylistName", selectedStylist);

      return View(model);
    }

    [HttpPost("/salon/specialty/{id}/all")]
    public ActionResult addSpecialty(int id)
    {

      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty.AddNewSpecialtyJoinStylist(id, int.Parse(Request.Form["new-specialty"]));
      List<Specialty> selectedSpecialty = Stylist.GetSpecialtyByStylist(id);
      Stylist selectedStylist = Stylist.Find(id);

      model.Add("SpecialtyList", selectedSpecialty);
      model.Add("StylistName", selectedStylist);

      return View("stylistsSpecialties", model);
    }
    ///change specialty
    [HttpGet("/salon/specialty/{id}/name")]
    public ActionResult EditSpecialty(int id)
    {
      Specialty foundSpecialty = Specialty.Find(id);

      return View(foundSpecialty);
    }

    [HttpPost("/salon/specialty/{id}/name/new")]
    public ActionResult EditSpecialtyNameFinal(int id)
    {
      Specialty foundSpecialty = Specialty.Find(id);
      foundSpecialty.Edit(id, Request.Form["new-specialty"]);

      List<Specialty> allSpecialties = Specialty.GetAll();

      return View("Specialties", allSpecialties);
    }
    ////// view stylists by specialty
    [HttpGet("/salon/specialty/{id}/stylist")]
    public ActionResult ClientsListSpecialty(int id)
    {

      Dictionary<string, object> model = new Dictionary<string, object>();

      Specialty foundSpecialty = Specialty.Find(id);
      List<Stylist> foundStylists = Specialty.GetStylistBySpecialty(id);

      model.Add("SpecialtyList", foundSpecialty);
      model.Add("StylistName", foundStylists);

      return View(model);
    }
  ////delete
    [HttpGet("/salon/specialty/{id}/delete")]
    public ActionResult DeleteSpecialty(int id)
    {
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> foundStylist = Specialty.GetStylistBySpecialty(id);
      selectedSpecialty.DeleteFromJoin();

      return View(foundStylist);
     }


    [HttpGet("/specialty/{id}/delete")]
    public ActionResult DeleteSpecialtyFinal(int id)
    {
      Specialty selectedSpecialty = Specialty.Find(id);
      selectedSpecialty.Delete();
      selectedSpecialty.DeleteFromJoin();

      return View();
    }


  }
}
