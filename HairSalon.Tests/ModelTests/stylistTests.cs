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
      Specialty.DeleteAllstylistsSpecialties();
    }
    public stylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
    }

    //getName
    [TestMethod]
    public void GetNamefromStylist_Id()
    {
      Stylist testStylist = new Stylist("Jimmy");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      string resultName = savedStylist.GetName();
      string testName = testStylist.GetName();

      Assert.AreEqual(testName, resultName);
    }

    //getId
    [TestMethod]
    public void getIdFromStylist_Id()
    {
      Stylist testStylist = new Stylist("Jimmy");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.AreEqual(testId, result);
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

    //test assigns Id when saved()
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

    //get all
    [TestMethod]
    public void GetAll_DescriptionEmptyAtFirst_0()
    {
      int result = Stylist.GetAll().Count;

      Assert.AreEqual(0, result);
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

//join table stylist_client, find by stylist_id
    [TestMethod]
    public void Get_GetStylistFromStylists_clients_byClientId()
    {
      Stylist testStylist1 = new Stylist("testName");
      testStylist1.Save();
      Client testClient1 = new Client("test1");
      testClient1.Save();
      Stylist.AddNewClient(testStylist1.GetId(), testClient1.GetId());
      List<Client> testClient = Stylist.GetClientsByStylist(testStylist1.GetId());
      Assert.AreEqual(testClient1.GetId(), testClient[0].GetId());
    }


/////find specialties by stylist Id
public void Get_SpecialtiesFromStylistId()
{
  Stylist testStylist1 = new Stylist("testName");
  testStylist1.Save();
  Specialty testSpecialty1 = new Specialty("testSpecialtyName");
  testSpecialty1.Save();

  Specialty.AddNewSpecialtyJoinStylist(testStylist1.GetId(), testSpecialty1.GetSpecialtyId());

  List<Specialty> testSpecialty = Stylist.GetSpecialtyByStylist(testStylist1.GetId());

  Assert.AreEqual("testSpecialtyName", testSpecialty[0].GetSpecialtyName());
}

//Add to join table stylists_clients
[TestMethod]
public void Add_AddtoStylists_clients()
{
  Stylist testStylist1 = new Stylist("testName");
  testStylist1.Save();
  Client testClient1 = new Client("test1");
  testClient1.Save();
  Stylist.AddNewClient(testStylist1.GetId(), testClient1.GetId());
  List<Stylist> testStylist = Client.GetStylistByClient(testClient1.GetId());
//  List<Client> testClient = Stylist.GetClientsByStylist(testStylist1.GetId());
  Assert.AreEqual(1, testStylist.Count);
}

//Delete from Join table stylists_clients
[TestMethod]
public void Delete_DeleteFromStylists_clients_byClientId()
{
  Stylist testStylist1 = new Stylist("testName");
  testStylist1.Save();
  Client testClient1 = new Client("test1");
  testClient1.Save();
  Stylist.AddNewClient(testStylist1.GetId(), testClient1.GetId());

  testStylist1.DeleteFromJoin();

  List<Stylist> testStylist = Client.GetStylistByClient(testClient1.GetId());

  Assert.AreEqual(0, testStylist.Count);
}

//Edit stylist name
    [TestMethod]
    public void Edit_EditClientName()
    {
      Stylist testStylist = new Stylist("testName");
      testStylist.Save();
      testStylist.Edit(testStylist.GetId(), "NewTestname");
      Stylist foundStylist = Stylist.Find(testStylist.GetId());
      Assert.AreEqual("NewTestname", foundStylist.GetName());
    }






  }
}
