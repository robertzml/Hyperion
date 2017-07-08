using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 报文测试
    /// </summary>
    [TestClass]
    public class MessageTest
    {
        #region Test
        /// <summary>
        /// 组合报文测试
        /// </summary>
        [TestMethod]
        public void MakeMessageTest()
        {
            string userId = "gh-qc-ios";//Guid.NewGuid().ToString();
            string serialNumber = "G123456789";

            WebControlMessage message = new WebControlMessage(userId, serialNumber);

            var msg = message.GetMessage();

            Console.WriteLine(msg);

            Assert.AreEqual("Homeconsole01.00000000010030004F00060001200340001400010009gh-qc-ios0127000AG123456789001A0001100120009000100010", msg);
        }
        #endregion //Test
    }
}
