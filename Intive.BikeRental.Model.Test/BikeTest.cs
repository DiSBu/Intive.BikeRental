using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Model.Test
{
    [TestClass]
    public class BikeTest
    {
        [TestMethod]
        public void CheckBikeInstance_CreateInstance_ShouldCreated()
        {
            var bike = new Bike
            {
                BikeId = 1,
                Brand = "Schwinn",
                Model = DateTime.Now.Date
            };

            Assert.AreEqual(1, bike.BikeId);
            Assert.AreEqual("Schwinn", bike.Brand);
            Assert.AreEqual(DateTime.Now.Date, bike.Model);
        }
    }
}