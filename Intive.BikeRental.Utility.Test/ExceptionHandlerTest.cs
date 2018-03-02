using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Utility.Test
{
    [TestClass]
    public class ExceptionHandlerTest
    {
        [TestMethod]
        public void ExceptionHandler_ExcecuteAction_ShouldWork()
        {
            ExceptionHandler.Execute(this, "ExceptionHandler", () => { });
            Assert.IsTrue(true);

            string result = ExceptionHandler.Execute<string>(this, "ExceptionHandler", () => { return ""; });
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionHandler_ExcecuteAction_ShouldThrowException()
        {
            ExceptionHandler.Execute(this, "ExceptionHandler", () => { throw new Exception("Exception");});
        }
    }
}