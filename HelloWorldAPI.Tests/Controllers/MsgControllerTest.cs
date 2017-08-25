using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldAPI;
using HelloWorldAPI.Controllers;

namespace HelloWorldAPI.Tests.Controllers
{
    [TestClass]
    class MsgControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            MsgController controller = new MsgController();

            // Act
            string result = controller.Get();

            // Assert
            Assert.AreEqual("Hello World", result);
        }
    }
}
