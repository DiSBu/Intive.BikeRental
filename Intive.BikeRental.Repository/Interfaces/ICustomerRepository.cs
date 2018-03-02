using System.Collections.Generic;
using Intive.BikeRental.Model;

namespace Intive.BikeRental.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository
    {
        IList<Customer> GetAllCustomers();
    }
}