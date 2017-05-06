using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Protocol;

    [TestClass]
    public class HttpTest
    {
        [TestMethod]
        public void TestRequest()
        {
            Request request = new Request();

            string userId = Guid.NewGuid().ToString();
            string serialNumber = "G123456789";

            WebControlMessage message = new WebControlMessage(userId, serialNumber);

            var msg = message.GetMessage();

            var task = Task.Run(() =>
            {
                var data = request.Post(msg);

                return data.Result;
            });

            var result = task.Result;
            Console.WriteLine(result);

            Assert.AreEqual("123", result);
        }
    }
}
