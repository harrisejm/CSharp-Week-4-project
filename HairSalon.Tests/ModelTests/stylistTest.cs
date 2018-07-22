using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Salon.Models;

namespace Salon.Tests
{
  [TestClass]
  public class stylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
      Client.DeleteAllStylistClient();
    }
    public stylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
    }
//get all
    [TestMethod]
    public void GetAll_DescriptionEmptyAtFirst_0()
    {
      int result = Stylist.GetAll().Count;

      Assert.AreEqual(0, result);
    }
// save
    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      Stylist testStylist = new Stylist("Eddie");

      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      CollectionAssert.AreEqual(testList, result);
    }
//getId
    [TestMethod]
    public void Save_DatabaseAssignsIdToDescription_Id()
    {
      Stylist testStylist = new Stylist("Jimmy");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.AreEqual(testId, result);
    }
//Find
    [TestMethod]
    public void Find_FindStylistInDatabase_Description()
    {
      Stylist testStylist = new Stylist("test");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.AreEqual(testStylist, foundStylist);
    }




  }
}
