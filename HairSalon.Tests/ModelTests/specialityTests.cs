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
          Client testClient = new Client("Eddie");

          testClient.Save();
          List<Client> result = Client.GetAll();
          List<Client> testList = new List<Client>{testClient};

          CollectionAssert.AreEqual(testList, result);
        }
      //test assigns Id when saved()
        [TestMethod]
        public void Save_DatabaseAssignsIdToDescription_Id()
        {
          Client testClient = new Client("Jimmy");
          testClient.Save();

          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          Assert.AreEqual(testId, result);
        }


  }
}
