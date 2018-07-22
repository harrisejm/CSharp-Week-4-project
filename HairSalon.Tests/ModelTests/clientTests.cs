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
      Client.DeleteAllStylistClient();
      Specialty.DeleteAllstylistsSpecialties();
    }
    public clientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
    }
    //getName
        [TestMethod]
        public void GetNamefromClient()
        {
          Client testClient = new Client("Jimmy");
          testClient.Save();

          Client savedClient = Client.GetAll()[0];

          string resultName = savedClient.GetName();
          string testName = testClient.GetName();

          Assert.AreEqual(testName, resultName);
        }

    //getId
        [TestMethod]
        public void GetIdfromClient()
        {
          Client testClient = new Client("Jimmy");
          testClient.Save();

          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          Assert.AreEqual(testId, result);
        }

//test getAll()
    [TestMethod]
    public void GetAll_DescriptionEmptyAtFirst_0()
    {
      int result = Client.GetAll().Count;

      Assert.AreEqual(0, result);
    }
//test Saves
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
  //test FindClient()
    [TestMethod]
    public void Find_FindClientInDatabase_Description()
    {
      Client testClient = new Client("test");
      testClient.Save();

      List<Client> allClients = Client.GetAll();
      Client foundClient = Client.FindClient(testClient.GetId());

      Assert.AreEqual(allClients[0], foundClient);
    }
 //test Delete()
    [TestMethod]
    public void Delete_DeleteClientInDatabase()
    {
      Client testClient1 = new Client("test1");
      testClient1.Save();
      List<Client> allClients = Client.GetAll();
      allClients[0].Delete();
      List<Client> allClientsDelete = Client.GetAll();

      Assert.AreEqual(0, allClientsDelete.Count);
    }
//add to join table stylists_clients
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
    //join table stylist_client, find by client_id
    [TestMethod]
    public void Get_GetStylistFromStylists_clients_byClientId()
    {
      Stylist testStylist1 = new Stylist("testName");
      testStylist1.Save();
      Client testClient1 = new Client("test1");
      testClient1.Save();
      Stylist.AddNewClient(testStylist1.GetId(), testClient1.GetId());
      List<Stylist> testStylist = Client.GetStylistByClient(testClient1.GetId());
    //  List<Client> testClient = Stylist.GetClientsByStylist(testStylist1.GetId());
      Assert.AreEqual(testStylist1.GetId(), testStylist[0].GetId());
    }

//Delete from Join table stylists_clients by client Id
    [TestMethod]
    public void Delete_DeleteFromStylists_clients_byClientId()
    {
      Stylist testStylist1 = new Stylist("testName");
      testStylist1.Save();
      Client testClient1 = new Client("test1");
      testClient1.Save();
      Stylist.AddNewClient(testStylist1.GetId(), testClient1.GetId());
      testClient1.DeleteFromJoin();

      List<Stylist> testStylist = Client.GetStylistByClient(testClient1.GetId());
    //  List<Client> testClient = Stylist.GetClientsByStylist(testStylist1.GetId());
      Assert.AreEqual(0, testStylist.Count);
    }

//Edit client name
    [TestMethod]
    public void Edit_EditClientName()
    {
      Client testClient = new Client("testName");
      testClient.Save();
      testClient.Edit(testClient.GetId(), "NewTestname");
      Client foundClient = Client.FindClient(testClient.GetId());
      Assert.AreEqual("NewTestname", foundClient.GetName());
    }


  }
}
