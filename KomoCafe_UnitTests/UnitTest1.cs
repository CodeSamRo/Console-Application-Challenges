using KomoCafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomoCafe_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private KomoCafeRepo komoCafeRepo;
        private KomoCafe komoCafe;
        private KomoCafe komoCafe2;
        [TestInitialize]
        public void Arrange()
        {
            komoCafeRepo = new KomoCafeRepo();
            komoCafe = new KomoCafe(1, "Red Soup", "It is red and it is soup", "Water, RedDye", 10.50);
            komoCafe2 = new KomoCafe(2, "Soup", "It is soup", "Hot Water", 5.00);
            komoCafeRepo.CreateMeal(komoCafe2);
        }
        [TestMethod]
        public void CreateMeal_Test()
        {
            bool wasAdded = komoCafeRepo.CreateMeal(komoCafe);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void DeleteMeal_Test()
        {
            bool wasDeleted = komoCafeRepo.DeleteMeal(komoCafe2);
            Assert.IsTrue(wasDeleted);
        }
        [TestMethod]
        public void ViewMeal_Test()
        {
            
        }
    }
}
