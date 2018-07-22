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


  }
}
