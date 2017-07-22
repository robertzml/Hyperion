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
    /// 用户测试
    /// </summary>
    [TestClass]
    public class UserTest
    {
        #region Field
        private string host;
        #endregion //Field

        #region Constructor
        public UserTest()
        {
            this.host = "http://localhost:6024/api/";
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

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[node.ServerResult.ToString("X")]}");
            Assert.AreEqual(0, node.ServerResult);
        }
        #endregion //Test
    }
}
