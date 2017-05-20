using System;
using System.Net.Http;
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

            //message.SetAction(new TLV(0x01, "0"));

            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"receive message: {content}");

            Assert.AreEqual(200, Convert.ToInt32(result.StatusCode));

            WebControlAckMessage ackMessage = new WebControlAckMessage();
            ackMessage.ParseAck(content);

            Assert.AreEqual(userId, ackMessage.UserId.Value);
            Assert.AreEqual(serialNumber, ackMessage.EquipmentSerialNumber.Value);
            Assert.AreEqual("A", ackMessage.ServerResult.Value);

            QueryMessage query = new QueryMessage(userId, 1);
            msg = query.GetMessage();
            Console.WriteLine($"send msg: {msg}");

            var task2 = Task.Run(() =>
            {
                var data = request.Post(msg);
                return data;
            });

            result = task2.Result;
            content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"receive message: {content}");
        }
    }
}
