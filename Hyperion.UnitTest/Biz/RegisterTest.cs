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
    /// 注册测试
    /// </summary>
    [TestClass]
    public class RegisterTest
    {
        #region Field
        private string host = "http://192.168.0.111:9000/";
        #endregion //Field

        #region Constructor
        public RegisterTest()
        {
            Cache.Instance.Add("BizHost", host);
        }
        #endregion //Constructor

        #region Function
        public async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = new TimeSpan(0, 0, 15);

                var response = await client.GetAsync(url);
                string result = "";

                if(response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    
                }

                return result;
            }
        }
        #endregion //Function

        #region Test
        /// <summary>
        /// 获取验证码测试
        /// </summary>
        [TestMethod]
        public void TestVerifyCode()
        {
            string phone = "18806186009";

            RegisterRequest request = new RegisterRequest();
            var obj = request.GetVerifyCode(phone);

            Console.WriteLine(obj.Message);

            int code = obj.Code;
            Assert.AreEqual(1, code);
        }

        /// <summary>
        /// 注册测试
        /// </summary>
        [TestMethod]
        public void TestRegister()
        {
            /*
           http://192.168.0.111:9000/freemall/accountToApp/register?userName=123456&password=123456&
           phone=18806186009&accountType=1&imsi=1114555&imei=458956&validateCode=075724&OsType=0
           */

            string username = "123456";
            string password = "123456";
            string phone = "18806186009";
            int accountType = 1;
            string imsi = "1114555";
            string imei = "458956";
            string validateCode = "803705";
            int ostype = 0;

            RegisterRequest request = new RegisterRequest();
            var obj = request.Register(username, password, phone, accountType, imsi, imei, validateCode, ostype);

            Console.WriteLine(obj.Message);

            int code = obj.Code;
            Assert.AreEqual(1, code);
        }
        #endregion //Test
    }
}
