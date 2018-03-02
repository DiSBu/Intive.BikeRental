using System.Data;
using Intive.BikeRental.Model;
using Intive.BikeRental.Repository.Transformers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Repository.Test.Transformers
{
    [TestClass]
    public class CustomerTransformerTest : BaseTransformerTest<Customer>
    {
        [TestMethod]
        public void ValidateTranform_ClientTransformation_ValidTransformation()
        {
            ValidateTranform(new CustomerTransformer());
        }

        public override DataTable CreateDataTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(CustomerFieldParameter.CustomerId.ToString());
            dataTable.Columns.Add(CustomerFieldParameter.Name.ToString());
            dataTable.Columns.Add(CustomerFieldParameter.LastName.ToString());

            dataTable.Rows.Add(
                new object[]
                    {
                        1,
                        "Name",
                        "LastName"
                    });

            return dataTable;
        }

        public override void CheckAsserts(Customer model)
        {
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.CustomerId);
            Assert.AreEqual("Name", model.Name);
            Assert.AreEqual("LastName", model.LastName);
        }
    }
}