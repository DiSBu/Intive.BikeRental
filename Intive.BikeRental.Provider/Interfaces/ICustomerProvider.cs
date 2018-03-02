using System.Collections.Generic;
using Intive.BikeRental.Model;

namespace Intive.BikeRental.Provider.Interfaces
{
    public interface ICustomerProvider
    {
        IList<Customer> GetAllCustomers();
    }
}