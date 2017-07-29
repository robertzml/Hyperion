using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Hyperion.UnitTest.Biz
{
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
        [TestMethod]
        public void TestVerifyCode()
        {
            string url = this.host + "freemall/accountToApp/getVerifyCode?phone=18806186009";

            var task = Task.Run(() =>
            {
                var data = Get(url);
                return data;
            });

            var result = task.Result;
            Console.WriteLine(result);
            Assert.IsFalse(string.IsNullOrEmpty(result));

            dynamic newValue = JsonConvert.DeserializeObject<dynamic>(result);


            Console.WriteLine(newValue.status.message);

            Assert.AreEqual(1, newValue.status.code);            
        }

        [TestMethod]
        public void TestLogin()
        {
            string url = host + "freemall/accountToApp/login?userName=呵呵呵&password=1234567&phoneType=0&loginType=1";

            var task = Task.Run(() =>
            {
                var data = Get(url);
                return data;
            });

            var result = task.Result;
            Console.WriteLine(result);
            Assert.IsFalse(string.IsNullOrEmpty(result));

            dynamic newValue = JsonConvert.DeserializeObject<dynamic>(result);
            
            Console.WriteLine(newValue.status.message);

            int code = newValue.status.code; // newValue["status"]["code"];
            
            Console.WriteLine(code.ToString());
            Assert.AreEqual(1, code);
        }
        #endregion //Test
    }
}
