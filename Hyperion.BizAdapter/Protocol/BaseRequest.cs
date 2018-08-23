using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{
    using Poseidon.Base.System;
    using Poseidon.Common;

    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class BaseRequest
    {
        #region Field
        /// <summary>
        /// 请求服务器地址
        /// </summary>
        protected string host;
        #endregion //Field

        #region Constructor
        public BaseRequest()
        {
            this.host = Cache.Instance["BizHost"].ToString();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = new TimeSpan(0, 0, 15);

                var response = client.GetAsync(url).Result;
                string result = "";

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }

                return result;
            }
        }

        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="key">需要返回的Header键</param>
        /// <returns></returns>
        protected Tuple<string, string> GetContentAndHeader(string url, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = new TimeSpan(0, 0, 15);

                var response = client.GetAsync(url).Result;
                string result = "";
                string header = "";

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;

                    var headers = response.Headers.GetValues(key).ToList();
                    if (headers.Count > 0)
                        header = headers[0];
                }

                return new Tuple<string, string>(result, header);
            }
        }
        #endregion //Function
    }
}
