using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using Salon.Controllers;

namespace Salon.Tests
{
  [TestClass]
  public class SalonControllerTest
  {

    [TestMethod]
    public void addSpecialty_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.addSpecialty();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void addSpecialtyStylist_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.addSpecialtyStylist(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void ClientList_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.ClientList(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void ClientListSpecialty_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.ClientsListSpecialty(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateForm_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.CreateForm();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void delete_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.DeleteClient(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void DeleteSpecialty_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.DeleteSpecialty(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void DeleteSpecialtyFinal_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.DeleteSpecialtyFinal(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void DeleteStylist_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.DeleteStylist(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void EditClientName_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.EditClientName(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void EditClients_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.EditClients(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void EditSpecialty_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.EditSpecialty(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void EditStylistName_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.EditStylistName(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.Index();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Specialties_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.Specialties();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void stylistsSpecialties_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.StylistsSpecialties(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }





  }
}
