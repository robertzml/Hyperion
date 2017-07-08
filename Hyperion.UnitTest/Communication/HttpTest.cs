using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Common;
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Protocol;

    [TestClass]
    public class HttpTest
    {
        #region Constructor
        public HttpTest()
        {
            string host = "http://192.168.0.116/WEB/";
            Cache.Instance.Add("EquipmentHost", host);
        }
        #endregion //Constructor

        #region Test
        /// <summary>
        /// 单次请求响应
        /// </summary>
        [TestMethod]
        public void RequestTest()
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
        }

        /// <summary>
        /// 请求测试2
        /// </summary>
        [TestMethod]
        public void RequestTest2()
        {
            Request request = new Request();

            string userId = Guid.NewGuid().ToString();
            string serialNumber = "G123456789";

            WebControlMessage message = new WebControlMessage(userId, serialNumber);
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                var data = request.Post2(msg);

                return data;
            });

            var response = task.Result;

            Console.WriteLine($"receive message: {response.ResponseMessage}");

            Assert.AreEqual(200, Convert.ToInt32(response.StatusCode));
        }
        #endregion //Test
    }
}
