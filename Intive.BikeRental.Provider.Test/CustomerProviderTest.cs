using Intive.BikeRental.Model;
using Intive.BikeRental.Repository;
using Intive.BikeRental.Repository.Interfaces;
using Intive.BikeRental.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Intive.BikeRental.Provider.Test
{
    [TestClass]
    public class CustomerProviderTest
    {
        private readonly Mock<IHttpServiceHelper> _httpHelperServiceMock = new Mock<IHttpServiceHelper>();
        private readonly CustomerProvider _customerProvider;
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        public CustomerProviderTest()
        {
            _httpHelperServiceMock.Setup(x => x.Get<IList<Customer>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_customerRepository.GetAllCustomers());
            _customerProvider = new CustomerProvider(_httpHelperServiceMock.Object);
        }

        [TestMethod]
        public void CustomerProvider_WhenGetAllCustomers_ResultShouldBeReturned()
        {
            var result = _customerProvider.GetAllCustomers();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}