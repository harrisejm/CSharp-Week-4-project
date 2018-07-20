using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Salon.Models;

namespace Salon.Tests
{
  [TestClass]
  public class clientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
    public clientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
    }
//test Save()
    [TestMethod]
    public void GetAll_DescriptionEmptyAtFirst_0()
    {
      int result = Client.GetAll().Count;

      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Client testClient = new Client("Eddie", 1, "test");

      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      CollectionAssert.AreEqual(testList, result);
    }
  //test Save()
    [TestMethod]
    public void Save_DatabaseAssignsIdToDescription_Id()
    {
      Client testClient = new Client("Jimmy", 1, "test");
      testClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.AreEqual(testId, result);
    }
  //test Find()
    [TestMethod]
    public void Find_FindClientInDatabase_Description()
    {
      Client testClient = new Client("test", 1, "test");
      testClient.Save();

      List<Client> allClients = Client.GetAll();
      List<Client> foundClient = Client.Find(testClient.GetStylistId());

      Assert.AreEqual(Client.GetAll()[0], Client.Find(testClient.GetStylistId())[0]);
    }
 //test Delete()
    [TestMethod]
    public void Delete_DeleteClientInDatabase_Description()
    {
      Client testClient1 = new Client("test1", 1, "test2");
      testClient1.Save();
      List<Client> allClients = Client.GetAll();
      allClients[0].Delete();
      List<Client> allClientsDelete = Client.GetAll();

      Assert.AreEqual(0, allClientsDelete.Count);
    }

  }
}
