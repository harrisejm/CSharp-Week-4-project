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
//WORKS
       [TestMethod]
       public void GetAll_DescriptionEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Client.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

  ///WORKS
       [TestMethod]
       public void Save_SavesToDatabase_ItemList()
       {
         //Arrange
         Client testClient = new Client("Eddie", 1);

         //Act
         testClient.Save();
         List<Client> result = Client.GetAll();
         List<Client> testList = new List<Client>{testClient};

         //Assert
         CollectionAssert.AreEqual(testList, result);
       }
       [TestMethod]
       public void Save_DatabaseAssignsIdToDescription_Id()
       {
         //Arrange
         Client testClient = new Client("Jimmy", 1);
         testClient.Save();

         //Act
         Client savedClient = Client.GetAll()[0];

         int result = savedClient.GetId();
         int testId = testClient.GetId();

         //Assert
         Assert.AreEqual(testId, result);
      }



}
}
