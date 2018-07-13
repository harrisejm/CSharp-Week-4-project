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
        public stylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eddie_harris_test;";
        }
//WORKS
       [TestMethod]
       public void GetAll_DescriptionEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

  ///WORKS
       [TestMethod]
       public void Save_SavesToDatabase_ItemList()
       {
         //Arrange
         Stylist testStylist = new Stylist("Eddie");

         //Act
         testStylist.Save();
         List<Stylist> result = Stylist.GetAll();
         List<Stylist> testList = new List<Stylist>{testStylist};

         //Assert
         CollectionAssert.AreEqual(testList, result);
       }
