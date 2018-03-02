using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Utility.Test
{
    [TestClass]
    public class SqlParameterBuilderTest
    {
        private enum TestCreateParameter
        {
            [CreateField(Direction = ParameterDirection.Input, Type = DbType.String)]
            TestValue1,
            [CreateField(Direction = ParameterDirection.Input, Type = DbType.Int32)]
            TestValue2
        }

        [TestMethod]
        public void Bind_CreateParameterEnum_ArrayOfParameter()
        {
            var builder = new SqlCreateParameterBuilder<TestCreateParameter>();
            var parameter = builder.Bind(TestCreateParameter.TestValue1).On("Test Value 1")
                                   .Bind(TestCreateParameter.TestValue2).On(2).Build();
            Assert.AreEqual("Test Value 1", parameter[0].Value.ToString());
            Assert.AreEqual(2, Convert.ToInt32(parameter[1].Value));
            Assert.AreEqual(ParameterDirection.Input, parameter[0].Direction);
            Assert.AreEqual(ParameterDirection.Input, parameter[1].Direction);
            Assert.AreEqual(DbType.String, parameter[0].DbType);
            Assert.AreEqual(DbType.Int32, parameter[1].DbType);
        }
    }
}