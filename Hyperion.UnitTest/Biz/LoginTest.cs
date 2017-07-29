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

        [TestMethod]
        public void TestLogin()
        {
            //string url = host + "freemall/accountToApp/login?userName=呵呵呵&password=1234567&phoneType=0&loginType=1";

            //var task = Task.Run(() =>
            //{
            //    var data = Get(url);
            //    return data;
            //});

            //var result = task.Result;
            //Console.WriteLine(result);
            //Assert.IsFalse(string.IsNullOrEmpty(result));

            //dynamic newValue = JsonConvert.DeserializeObject<dynamic>(result);

            //Console.WriteLine(newValue.status.message);

            //int code = newValue.status.code; // newValue["status"]["code"];

            //Console.WriteLine(code.ToString());
            //Assert.AreEqual(1, code);
        }
    }
}
