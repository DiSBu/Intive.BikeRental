using System.Data;
using Intive.BikeRental.Repository.Transformers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Intive.BikeRental.Repository.Test.Transformers
{
    [TestClass]
    public abstract class BaseTransformerTest<T>
    {
        private readonly IDataReader _dataReader;

        protected BaseTransformerTest()
        {
            _dataReader = new DataTableReader(CreateDataTable());
        }

        public abstract DataTable CreateDataTable();

        public abstract void CheckAsserts(T model);

        public void ValidateTranform(BaseTransformer<T> transformer)
        {
            var result = transformer.Transform(_dataReader);
            Assert.IsTrue(result.Count == 1);
            CheckAsserts(result[0]);
        }
    }
}