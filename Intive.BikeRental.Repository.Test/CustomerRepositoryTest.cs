using Intive.BikeRental.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Repository.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private ICustomerRepository _customerRepository;

        [TestInitialize]
        public void Initialize()
        {
            _customerRepository = new CustomerRepository();
        }

        [TestMethod]
        public void GetAllCustomers_WhenGetAllCustomers_ShouldReturnFive()
        {
            var customers = _customerRepository.GetAllCustomers();
            Assert.IsTrue(customers.Count == 3);
        }
    }
}