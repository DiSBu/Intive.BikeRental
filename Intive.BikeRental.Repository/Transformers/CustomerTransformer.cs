using System;
using System.Data;
using Intive.BikeRental.Model;
using Intive.BikeRental.Utility;

namespace Intive.BikeRental.Repository.Transformers
{
    public enum CustomerFieldParameter
    {
        [CreateField(Direction = ParameterDirection.Input, Type = DbType.Int32)]
        CustomerId,
        [CreateField(Direction = ParameterDirection.Input, Type = DbType.String)]
        Name,
        [CreateField(Direction = ParameterDirection.Input, Type = DbType.String)]
        LastName,
        [CreateField(Direction = ParameterDirection.Output, Type = DbType.Int32)]
        NewCustomerId
    }

    public class CustomerTransformer : BaseTransformer<Customer>
    {
        internal override Customer TransformElement(IDataReader dr, Func<IDataReader, Customer, Customer> bindExtraFields = null)
        {
            return ExceptionHandler.Execute(
                this,
                "Customer  => TransformElement",
                () => new Customer
                {
                    CustomerId = Convert.ToInt32(dr[CustomerFieldParameter.CustomerId.ToString()]),
                    Name = dr[CustomerFieldParameter.Name.ToString()].ToString(),
                    LastName = dr[CustomerFieldParameter.LastName.ToString()].ToString()
                });
        }
    }
}