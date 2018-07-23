using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Salon.Models;

namespace Salon.Tests
{
  [TestClass]
  public class specialtyTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
      Client.DeleteAllStylistClient();
      Specialty.DeleteAll();
      Specialty.DeleteAllstylistsSpecialties();
    }
    public specialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
    }
    //getName
    [TestMethod]
    public void GetNamefromSpecialty()
    {
      Specialty testSpecialty = new Specialty("Jimmy");
      testSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      string resultName = savedSpecialty.GetSpecialtyName();
      string testName = testSpecialty.GetSpecialtyName();

      Assert.AreEqual(testName, resultName);
    }

    //getId
    [TestMethod]
    public void getIdFromSpecialty()
    {
      Specialty testSpecialty = new Specialty("Jimmy");
      testSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetSpecialtyId();
      int testId = testSpecialty.GetSpecialtyId();

      Assert.AreEqual(testId, result);
    }

    //test getAll()
    [TestMethod]
    public void GetAll_EmptyAtFirst_0()
    {
      int result = Specialty.GetAll().Count;
      Assert.AreEqual(0, result);
    }
    //test Save
    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Specialty testSpecialty = new Specialty("Eddie");

      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      CollectionAssert.AreEqual(testList, result);
    }
    //test assigns Id when saved()
    [TestMethod]
    public void Save_DatabaseAssignsIdToDescription_Id()
    {
      Specialty testSpecialty = new Specialty("Jimmy");
      testSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetSpecialtyId();
      int testId = testSpecialty.GetSpecialtyId();

      Assert.AreEqual(testId, result);
    }
    //add to join table stylists_specialties
    [TestMethod]
    public void Add_AddtoStylists_clients()
    {
      Stylist testStylist1 = new Stylist("testName");
      testStylist1.Save();
      Specialty testSpecialty1 = new Specialty("test1");
      testSpecialty1.Save();

      Specialty.AddNewSpecialtyJoinStylist(testStylist1.GetId(), testSpecialty1.GetSpecialtyId());
      List<Stylist> testSpecialty = Specialty.GetStylistBySpecialty(testSpecialty1.GetSpecialtyId());

      Assert.AreEqual(1, testSpecialty.Count);
    }

    //test Delete()
    [TestMethod]
    public void Delete_DeleteSpecialyInDatabase()
    {
      Specialty testSpecialty1 = new Specialty("test1");
      testSpecialty1.Save();
      List<Specialty> allSpecialtys = Specialty.GetAll();
      allSpecialtys[0].Delete();
      List<Specialty> allSpecialtysDelete = Specialty.GetAll();

      Assert.AreEqual(0, allSpecialtysDelete.Count);
    }

    //Delete from Join table stylists_clients by client Id
    [TestMethod]
    public void Delete_DeleteFromStylists_specialty()
    {
      Stylist testStylist1 = new Stylist("testName");
      testStylist1.Save();
      Specialty testSpecialty1 = new Specialty("test1");
      testSpecialty1.Save();
      Specialty.AddNewSpecialtyJoinStylist(testStylist1.GetId(), testSpecialty1.GetSpecialtyId());
      testSpecialty1.DeleteFromJoin();

      List<Stylist> testSpecialty = Specialty.GetStylistBySpecialty(testSpecialty1.GetSpecialtyId());

      Assert.AreEqual(0, testSpecialty.Count);
    }
//Find
    [TestMethod]
    public void Find_FindSpecialtyById()
    {
      Specialty testSpecialty = new Specialty("test");
      testSpecialty.Save();

      List<Specialty> allSpecialtys = Specialty.GetAll();
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetSpecialtyId());

      Assert.AreEqual(allSpecialtys[0], foundSpecialty);
    }

    //Edit specialty name
    [TestMethod]
    public void Edit_EditSpecialtyName()
    {
      Specialty testSpecialty = new Specialty("testName");
      testSpecialty.Save();
      testSpecialty.Edit(testSpecialty.GetSpecialtyId(), "NewTestname");
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetSpecialtyId());
      Assert.AreEqual("NewTestname", foundSpecialty.GetSpecialtyName());
    }



  }
}
