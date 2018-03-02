using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Model.Test
{
    [TestClass]
    public class RentTest
    {
        [TestMethod]
        public void CheckRentInstance_CreateInstance_ShouldCreated()
        {
            var rent = GetRent(DateTime.Now, DateTime.Now);
            Assert.AreEqual(DateTime.Now.Date, rent.From.Date);
            Assert.AreEqual(DateTime.Now.Date, rent.To.Date);
            Assert.IsNotNull(rent.Bike);
            Assert.AreEqual(1, rent.Bike.BikeId);
        }

        [TestMethod]
        public void Rent_CheckHourlyRent_ShouldBeCorrect()
        {
            var rent = GetRent(DateTime.Now, DateTime.Now.AddHours(1), RentType.Hourly);
            Assert.AreEqual(5, rent.GetPrice());

            rent = GetRent(DateTime.Now, DateTime.Now.AddHours(15), RentType.Hourly);
            Assert.AreEqual(75, rent.GetPrice());
        }

        [TestMethod]
        public void Rent_CheckDailyRent_ShouldBeCorrect()
        {
            var rent = GetRent(DateTime.Now, DateTime.Now.AddDays(1), RentType.Daily);
            Assert.AreEqual(20, rent.GetPrice());

            rent = GetRent(DateTime.Now, DateTime.Now.AddDays(3), RentType.Daily);
            Assert.AreEqual(60, rent.GetPrice());
        }

        [TestMethod]
        public void Rent_CheckWeeklyRent_ShouldBeCorrect()
        {
            var rent = GetRent(DateTime.Now, DateTime.Now.AddDays(7), RentType.Weekly);
            Assert.AreEqual(60, rent.GetPrice());

            rent = GetRent(DateTime.Now, DateTime.Now.AddDays(21), RentType.Weekly);
            Assert.AreEqual(180, rent.GetPrice());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Rent_CheckExceptionWhenNoneRentType_ShouldBeCorrect()
        {
            var rent = GetRent(DateTime.Now, DateTime.Now.AddDays(7), RentType.None);
            rent.GetPrice();
        }

        private static Rent GetRent(DateTime from, DateTime to, RentType rentType = RentType.None)
        {
            var rent = new Rent()
            {
                From = from,
                To = to,
                RentType = rentType,
                Bike = new Bike {BikeId = 1}
            };

            return rent;
        }
    }
}