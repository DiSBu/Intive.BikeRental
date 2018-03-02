using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Model.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void CheckCustomerInstance_CreateInstance_ShouldBeCreated()
        {
            var customer = new Customer()
            {
                CustomerId = 1,
                LastName = "Bond",
                Name = "James",
                RentalsList = new List<Rent> { new Rent { From = DateTime.Now.Date, To = DateTime.Now.Date } }
            };

            Assert.AreEqual(1, customer.CustomerId);
            Assert.AreEqual("Bond", customer.LastName);
            Assert.AreEqual("James", customer.Name);
            Assert.AreEqual(1, customer.RentalsList.Count);
        }

        [TestMethod]
        public void CheckFamilyRentalDiscountOf30Percent_WhenCheckingPrice_DiscountOf30PercentShouldBeApplied()
        {
            var customer = new Customer()
            {
                CustomerId = 1,
                LastName = "Bond",
                Name = "James",
                RentalsList = new List<Rent>
                {
                    new Rent {RentType = RentType.Hourly, From = DateTime.Now.Date, To = DateTime.Now.Date.AddHours(1) },
                    new Rent {RentType = RentType.Daily, From = DateTime.Now.Date, To = DateTime.Now.Date.AddDays(1) },
                    new Rent {RentType = RentType.Weekly, From = DateTime.Now.Date, To = DateTime.Now.Date.AddDays(7) }
                }
            };
     
            Assert.AreEqual(59.5, customer.CheckPrice(), 0.00000001);
        }
    }
}