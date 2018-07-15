using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using Salon.Controllers;

namespace Salon.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      HomeController controller = new HomeController();

      ActionResult indexView = controller.Index();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
