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
    public void Index_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.Index();

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
    public void ClientList_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.ClientList(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void EditClients_ReturnsCorrectView_True()
    {
      SalonController controller = new SalonController();

      ActionResult indexView = controller.EditClients(1);

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

  }
}
