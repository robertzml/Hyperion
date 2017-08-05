using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.UnitTest
{
    using Poseidon.Common;

    public static class TestUtility
    {
        #region Method
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static T GetEntity<T>(string url, string accessId)
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

        /// <summary>
        /// 获取响应结果
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="accessId"></param>
        /// <returns></returns>
        public static string GetString(string url, string accessId)
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
        #endregion //Method
    }
}
