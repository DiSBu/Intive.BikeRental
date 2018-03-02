using Intive.BikeRental.Model;
using Intive.BikeRental.Provider.Interfaces;
using Intive.BikeRental.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Intive.BikeRental.Provider
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly string _gatewayServiceUriBase;
        private readonly IHttpServiceHelper _httpServiceHelper;

        public CustomerProvider(IHttpServiceHelper httpServiceHelper)
        {
            _gatewayServiceUriBase = ConfigurationManager.AppSettings["GatewayServiceBaseUri"];
            _httpServiceHelper = httpServiceHelper;
        }

        public IList<Customer> GetAllCustomers()
        {
            return ExceptionHandler.Execute(
                this,
                "CustomerProvider ->  GetAllCustomers",
                () =>
                {
                    var result = _httpServiceHelper.Get<IList<Customer>>("api/Customers/GetAllCustomers", _gatewayServiceUriBase); 
                    return result;
                });
        }
    }
}