using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest.Api
{
    [TestClass]
    public class ThreadTest
    {
        #region Field
        private string host;
        #endregion //Field

        #region Constructor
        public ThreadTest()
        {
            //this.host = "http://localhost:6024/api/";
            this.host = "http://192.168.0.111:8030/api/";
        }
        #endregion //Construcor

        #region Test
        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            //string accessId = "15012340000";
            string accessId = "zml12345";
            string password = "123456";
            int userType = 1;
            string imei = "ZML1234567";
            int userLoginType = 1;
            int getStatus = 0;
            int osType = 1;

            string url = string.Format("{0}LoginMessage?accessId={1}&password={2}&osType={3}&userType={4}&imei={5}&userLoginType={6}&getStatus={7}",
                host, accessId, password, osType, userType, imei, userLoginType, getStatus);

            int count = 5;
            List<Task<dynamic>> tasks = new List<Task<dynamic>>();
            for (int i = 0; i < count; i++)
            {
                var task = Task.Run(() =>
                {
                    var node = TestUtility.GetString(url, accessId);                   
                    var obj = JsonConvert.DeserializeObject<dynamic>(node);
                    Console.WriteLine("In task {0}", i);

                    return obj;
                });

                tasks.Add(task);
                Console.WriteLine("Out task {0}", i);
            }

            Task.WaitAll(tasks.ToArray());

            for (int i = 0; i < count; i++)
            {
                dynamic r = tasks[i].Result;
                Console.WriteLine(r);
            }
        }
        #endregion //Test
    }
}
