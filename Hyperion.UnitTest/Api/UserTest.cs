using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Hyperion.UnitTest.Api
{
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Poseidon.Common;

    /// <summary>
    /// 用户测试
    /// </summary>
    [TestClass]
    public class UserTest
    {
        #region Field
        private string host;

        private string sslhost;
        #endregion //Field

        #region Constructor
        public UserTest()
        {
            this.host = "http://localhost:6024/api/";
            //this.host = "http://192.168.0.111:8030/api/";

            //this.sslhost = "https://localhost:44315/api/";
            this.sslhost = "https://192.168.0.111:4432/api/";
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

        protected T GetEntitySSL<T>(string url, string accessId)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

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

        protected string GetString(string url, string accessId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string auth = Hasher.SHA1Encrypt(accessId + "Mu lan");
                client.DefaultRequestHeaders.Add("auth", auth);

                string entity = "";

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    entity = response.Content.ReadAsStringAsync().Result;
                }

                return entity;
            }
        }
        #endregion //Function

        #region Test
        /// <summary>
        /// 注册测试
        /// </summary>
        [TestMethod]
        public void TestRegister()
        {
            int registerType = 0;
            //string accessId = "15012340000";
            string accessId = "14812440012";
            long userId = 11;
            int userType = 1;
            string imei = "C1234567890";

            string url = string.Format("{0}RegistrationMessage?registerType={1}&accessId={2}&userId={3}&userType={4}&imei={5}",
                host, registerType, accessId, userId, userType, imei);

            var node = GetEntity<RegistrationNode>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]}");
            Assert.AreEqual(0, node.ServerResult);
        }

        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            string accessId = "17858655030";
            long userId = 0;
            int userType = 1;
            string imei = "1234567890";
            int userLoginType = 1;
            int getStatus = 0;

            string url = string.Format("{0}LoginMessage?accessId={1}&userId={2}&userType={3}&imei={4}&userLoginType={5}&getStatus={6}",
                host, accessId, userId, userType, imei, userLoginType, getStatus);

            var node = GetEntity<LoginNode>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.serverresult.ToString("X")]}");
            Assert.AreEqual(0, node.serverresult);
        }

        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void TestSSLLogin()
        {
            string accessId = "17858655030";
            long userId = 0;
            int userType = 1;
            string imei = "1234567890";
            int userLoginType = 1;
            int getStatus = 0;

            string url = string.Format("{0}LoginMessage?accessId={1}&userId={2}&userType={3}&imei={4}&userLoginType={5}&getStatus={6}",
                sslhost, accessId, userId, userType, imei, userLoginType, getStatus);

            var node = GetEntitySSL<LoginNode>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.serverresult.ToString("X")]}");
            Assert.AreEqual(0, node.serverresult);
        }

        /// <summary>
        /// 注销测试
        /// </summary>
        [TestMethod]
        public void TestLogout()
        {
            int accessType = 0;
            string accessId = "17858655030";
            string imei = "1234567890";

            string url = string.Format("{0}LogoutMessage?accessType={1}&accessId={2}&imei={3}",
                host, accessType, accessId, imei);

            var node = GetEntity<string>(url, accessId);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node]}");
            Assert.AreEqual(0, Convert.ToInt32(node, 16));
        }

        /// <summary>
        /// 获取验证码测试
        /// </summary>
        [TestMethod]
        public void TestGetCode()
        {
            string phone = "";
            string accessId = "";
            string url = string.Format("{0}RegistrationMessage?phone={1}&accessId={2}",
                host, phone, accessId);

            var node = GetString(url, accessId);
            Console.WriteLine($"ack result: {node}");
            Assert.IsFalse(string.IsNullOrEmpty(node));

            var obj = JsonConvert.DeserializeObject<dynamic>(node);
            int code = obj.Code;

            Assert.AreEqual(1, code);
        }

        /// <summary>
        /// 注册测试2
        /// </summary>
        [TestMethod]
        public void TestRegister2()
        {
            int registerType = 0;
            //string accessId = "15012340000";
            string accessId = "zml123";
            string password = "123456";
            string phone = "";
            int userType = 1;
            string imsi = "2334";
            string imei = "ZML12345";
            string validateCode = "295518";
            int osType = 1;

            string url = string.Format("{0}RegistrationMessage?registerType={1}&accessId={2}&password={3}&phone={4}&userType={5}&imsi={6}&imei={7}&validateCode={8}&osType={9}",
                host, registerType, accessId, password, phone, userType, imsi, imei, validateCode, osType);

            var node = GetEntity<RegistrationNode>(url, accessId);
            Console.WriteLine("ack result:{0}, message:{1}, code:{2}", TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]);

            Assert.AreEqual(0, node.ServerResult);
        }

        [TestMethod]
        public void TestLogin2()
        {
            //string accessId = "15012340000";
            string accessId = "呵呵呵";
            string password = "1234567";
            int userType = 1;
            string imei = "ZML12345";
            int userLoginType = 1;
            int getStatus = 0;
            int osType = 1;

            string url = string.Format("{0}LoginMessage?accessId={1}&password={2}&osType={3}&userType={4}&imei={5}&userLoginType={6}&getStatus={7}",
                host, accessId, password, osType, userType, imei, userLoginType, getStatus);

            var node = GetString(url, accessId);
            Console.WriteLine(node);
            var obj = JsonConvert.DeserializeObject<dynamic>(node);

            int code = obj.BizStatus.Code;

            Assert.AreEqual(1, code);
        }
        #endregion //Test
    }
}
