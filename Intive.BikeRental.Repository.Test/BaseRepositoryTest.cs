using Intive.BikeRental.Repository.Interfaces;
using Intive.BikeRental.Utility;

namespace Intive.BikeRental.Repository.Test
{
    public abstract class BaseRepositoryTest<TCreateParameter> where TCreateParameter : struct
    {
        protected static IDataAccessHelper DbHelper = new DataAccessHelper("Intive");
        protected static SqlCreateParameterBuilder<TCreateParameter> Builder = new SqlCreateParameterBuilder<TCreateParameter>();
    }
}