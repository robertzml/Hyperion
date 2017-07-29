﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void TestLogin()
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
