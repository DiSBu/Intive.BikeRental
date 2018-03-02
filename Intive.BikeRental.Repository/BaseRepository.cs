using Intive.BikeRental.Repository.Interfaces;
using Intive.BikeRental.Utility;

namespace Intive.BikeRental.Repository
{
    public abstract class BaseRepository<TCreateParameter> where TCreateParameter : struct 
    {
        protected IDataAccessHelper DbHelper { get; set; }

        protected SqlCreateParameterBuilder<TCreateParameter> Builder { get; set; }

        protected int cacheTimeOut;

        protected string cacheKey;


        public void Initialize(string repositoryName, string connectionStringKey = "Intive")
        {
	        ExceptionHandler.Execute(
		        this,
		        repositoryName,
		        () =>
		        {
		            cacheTimeOut = 900;
                    DbHelper = new DataAccessHelper(connectionStringKey);
                    Builder = new SqlCreateParameterBuilder<TCreateParameter>();
                    cacheKey = repositoryName;
		        });
        }
    }
}