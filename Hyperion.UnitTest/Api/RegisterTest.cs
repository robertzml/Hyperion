using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hyperion.UnitTest.Api
{
    using Poseidon.Common;

    [TestClass]
    public class RegisterTest
    {
        #region Field
        private string host;

        private string sslhost;
        #endregion //Field

        #region Constructor
        public RegisterTest()
        {
            this.host = "http://localhost:6024/api/";
            //this.host = "http://192.168.0.111:8030/api/";

            //this.sslhost = "https://localhost:44315/api/";
            this.sslhost = "https://192.168.0.111:4432/api/";
        }
        #endregion //Construcor

        #region Function
        #endregion //Function

        #region Test
        [TestMethod]
        public void TestGetCode()
        {
            string phone = "15995202790";
            string accessId = "15995202790";
            string url = string.Format("{0}RegistrationMessage?phone={1}&accessId={2}",
                host, phone, accessId);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);

            var obj = JsonConvert.DeserializeObject<dynamic>(node);
            int code = obj.code;

            Assert.AreEqual(0, code);
        }

        /// <summary>
        /// 注册测试2
        /// </summary>
        [TestMethod]
        public void TestRegister2()
        {
            int registerType = 0;
            //string accessId = "15012340000";
            string accessId = "zml1";
            string password = "123456";
            string phone = "15995202790";
            int userType = 1;
            string imsi = "0";
            string imei = "9B3BEEC3-C83F-4D51-8F08-21D682D6E4ED";
            string validateCode = "839968";
            int osType = 2;

            string url = string.Format("{0}RegistrationMessage?registerType={1}&accessId={2}&password={3}&phone={4}&userType={5}&imsi={6}&imei={7}&validateCode={8}&osType={9}",
                host, registerType, accessId, password, phone, userType, imsi, imei, validateCode, osType);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);

            Assert.IsFalse(string.IsNullOrEmpty(node));
        }
        #endregion //Test
    }
}
