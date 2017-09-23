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
    public class LoginTest
    {
        #region Field
        private string host;

        private string sslhost;
        #endregion //Field

        #region Constructor
        public LoginTest()
        {
            //this.host = "http://localhost:6024/api/";
            this.host = "http://192.168.0.111:8030/api/";

            //this.sslhost = "https://localhost:44315/api/";
            this.sslhost = "https://192.168.0.111:4432/api/";
        }
        #endregion //Construcor

        #region Function
        #endregion //Function

        #region Test
        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            string accessId = "123456a";
            string password = "123456";
            int userType = 1;
            string imei = "EFF17490-1D6E-41B0-BC12-ED8192A473B7";
            int userLoginType = 1;
            int getStatus = 1;
            int osType = 1;

            string url = string.Format("{0}LoginMessage?accessId={1}&password={2}&osType={3}&userType={4}&imei={5}&userLoginType={6}&getStatus={7}",
                host, accessId, password, osType, userType, imei, userLoginType, getStatus);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);
            var obj = JsonConvert.DeserializeObject<dynamic>(node);

            int code = obj.bizstatus.code;

            Assert.AreEqual(0, code);
        }

        /// <summary>
        /// 注销测试
        /// </summary>
        [TestMethod]
        public void TestLogout()
        {
            int accessType = 0;
            string accessId = "123456a";
            string imei = "9B3BEEC3-C83F-4D51-8F08-21D682D6E4ED";

            string url = string.Format("{0}LogoutMessage?accessType={1}&accessId={2}&imei={3}",
               host, accessType, accessId, imei);

            var node = TestUtility.GetString(url, accessId);
            Console.WriteLine(node);
            var obj = JsonConvert.DeserializeObject<dynamic>(node);

            int code = obj.code;

            Assert.AreEqual(0, code);
        }
        #endregion //Test
    }
}
