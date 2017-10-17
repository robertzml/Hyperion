using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest.Api
{
    using Poseidon.Common;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 设备测试
    /// </summary>
    [TestClass]
    public class DeviceTest
    {
        #region Field
        private string host;
        #endregion //Field

        #region Constructor
        public DeviceTest()
        {
            this.host = "http://localhost:6024/api/";
            //this.host = "http://192.168.0.111:8030/api/";
        }
        #endregion //Construcor

        #region Function
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected T GetEntity<T>(string url, string accessId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string auth = Hasher.SHA1Encrypt(accessId + "Mu lan");
                client.DefaultRequestHeaders.Add("auth", auth);

                T entity = default(T);

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    entity = response.Content.ReadAsAsync<T>().Result;
                }

                return entity;
            }
        }
        #endregion //Function

        #region Test
        [TestMethod]
        public void DeviceGetCode()
        {
            int accountId = 52;
            string imei = "E0ED6BCC-7AB3-4ABF-ACEC-FE274E2EFDA2";
            string phone = "18852547810";
            string serialNumber = "ff10000000000000";

            string url = string.Format("{0}UnifiedMessage?accountId={1}&imei={2}&phone={3}&serialNumber={4}",
               host, accountId, imei, phone, serialNumber);

            var node = TestUtility.GetString(url, "123");
            Console.WriteLine(node);
        }

        [TestMethod]
        public void DeviceAdd2Test()
        {
            string accessId = "123456a";
            int accountId = 52;
            string imei = "E0ED6BCC-7AB3-4ABF-ACEC-FE274E2EFDA2";
            int houseNumber = 22;
            int roomNumber = 21;
            string deviceName = "TEST1";
            string deviceType = "0";
            string serialNumber = "ff10000000000000";
            string verifyCode = "123456";

            string url = string.Format("{0}UnifiedMessage?accountId={1}&accessId={2}&imei={3}&houseNumber={4}&roomNumber={5}&deviceName={6}&deviceType={7}&serialNumber={8}&verifyCode={9}",
                host, accountId, accessId, imei, houseNumber, roomNumber, deviceName, deviceType, serialNumber, verifyCode);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);

            Assert.IsFalse(string.IsNullOrEmpty(node));
        }

        /// <summary>
        /// 设备列表测试
        /// </summary>
        [TestMethod]
        public void DeviceListTest()
        {
            int accessType = 0;
            string accessId = "zml1";
            string imei = "9B3BEEC3-C83F-4D51-8F08-21D682D6E4ED";
            int houseNumber = 15;
            int roomNumber = 14;

            string url = string.Format("{0}DeviceListMessage?accessType={1}&accessId={2}&imei={3}&houseNumber={4}&roomNumber={5}",
               host, accessType, accessId, imei, houseNumber, roomNumber);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);

            Assert.IsFalse(string.IsNullOrEmpty(node));
        }

        /// <summary>
        /// 增加设备测试
        /// </summary>
        [TestMethod]
        public void DeviceAddTest()
        {
            string accessId = "zml1";
            string imei = "9B3BEEC3-C83F-4D51-8F08-21D682D6E4ED";
            int houseNumber = 15;
            int roomNumber = 14;
            string deviceName = "TEST1";
            string deviceType = "0000";
            string serialNumber = "abcedfg0";

            string url = string.Format("{0}UnifiedMessage?accessId={1}&imei={2}&houseNumber={3}&roomNumber={4}&deviceName={5}&deviceType={6}&serialNumber={7}",
                host, accessId, imei, houseNumber, roomNumber, deviceName, deviceType, serialNumber);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);

            Assert.IsFalse(string.IsNullOrEmpty(node));

            //var node = GetEntity<UnifiedNode>(url, accessId);

            //Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]}");
            //Assert.AreEqual(0, node.ServerResult);
        }

        /// <summary>
        /// 修改设备测试
        /// </summary>
        [TestMethod]
        public void DeviceEditTest()
        {
            string accessId = "17858655030";
            string imei = "1234567890";
            string deviceName = "TEST0712";
            string serialNumber = "qwerty";

            string url = string.Format("{0}UnifiedMessage?accessId={1}&imei={2}&deviceName={3}&serialNumber={4}",
                host, accessId, imei, deviceName, serialNumber);

            var node = GetEntity<UnifiedNode>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]}");
            Assert.AreEqual(0, node.ServerResult);
        }

        /// <summary>
        /// 删除设备测试
        /// </summary>
        [TestMethod]
        public void DeviceDeleteTest()
        {
            string accessId = "17858655030";
            string imei = "1234567890";
            string serialNumber = "qwerty";

            string url = string.Format("{0}UnifiedMessage?accessId={1}&imei={2}&serialNumber={3}",
              host, accessId, imei, serialNumber);

            var node = GetEntity<UnifiedNode>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]}");
            Assert.AreEqual(0, node.ServerResult);
        }

        /// <summary>
        /// 设备列表长连接测试
        /// </summary>
        [TestMethod]
        public void DeviceListPersisTest()
        {
            string accessId = "zml1";
            string imei = "9B3BEEC3-C83F-4D51-8F08-21D682D6E4ED";
            int houseNumber = 15;
            int roomNumber = 14;
            string deviceName = "TEST1";
            string deviceType = "0000";
            string serialNumber = "abcedfg0";

            string url = string.Format("{0}UnifiedMessage?accessId={1}&imei={2}&houseNumber={3}&roomNumber={4}&deviceName={5}&deviceType={6}&serialNumber={7}",
                host, accessId, imei, houseNumber, roomNumber, deviceName, deviceType, serialNumber);


            HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string auth = Hasher.SHA1Encrypt(accessId + "Mu lan");
            client.DefaultRequestHeaders.Add("auth", auth);

            string entity = "";

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                entity = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine(entity);

            Assert.IsFalse(string.IsNullOrEmpty(entity));


            //second 
            string result2 = "";
            response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                result2 = response.Content.ReadAsStringAsync().Result;
            }

            Console.WriteLine(result2);
            Assert.IsFalse(string.IsNullOrEmpty(result2));

            //client.Dispose
        }
        #endregion //Test
    }
}
