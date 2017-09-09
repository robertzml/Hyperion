using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hyperion.UnitTest.Biz
{
    using Hyperion.BizAdapter.Protocol;
    using Poseidon.Common;

    /// <summary>
    /// 登录测试
    /// </summary>
    [TestClass]
    public class LoginTest
    {
        #region Field
        private string host = "http://192.168.0.111:9000/";
        #endregion //Field

        #region Constructor
        public LoginTest()
        {
            Cache.Instance.Add("BizHost", host);
        }
        #endregion //Constructor

        #region Test
        [TestMethod]
        public void TestLogin()
        {
            string username = "呵呵呵";
            string password = "1234567";
            int ostype = 1;
            int loginType = 1;
            string imei = "asdf";

            LoginRequest request = new LoginRequest();
            dynamic obj = request.Login(username, password, ostype, loginType, imei);

            Console.WriteLine(obj.status.message);

            int code = obj.status.code;

            Assert.AreEqual(1, code);
        }

        [TestMethod]
        public void TestLogout()
        {
            string username = "呵呵呵";

            LogoutRequest request = new LogoutRequest();
            dynamic obj = request.Logout(username);

            Console.WriteLine(obj);

            int code = obj.status.code;

            Assert.AreEqual(1, code);
        }
        #endregion //Test
    }
}
