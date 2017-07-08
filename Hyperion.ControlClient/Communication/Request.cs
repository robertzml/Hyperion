using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Communication
{
    using Poseidon.Base.System;
    using Poseidon.Common;

    /// <summary>
    /// 控制请求类
    /// </summary>
    public class Request
    {
        #region Field
        /// <summary>
        /// 请求服务器地址
        /// </summary>
        private string host;
        #endregion //Field

        #region Constructor
        public Request()
        {
            this.host = Cache.Instance["EquipmentHost"].ToString();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 发送控制请求
        /// </summary>
        /// <param name="message">请求报文</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post(string message)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 15);

            try
            {
                var content = new StringContent(message);

                var result = await client.PostAsync(this.host, content);

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new PoseidonException($"Http Exception: {e.Message}");
            }
            catch (Exception e)
            {
                throw new PoseidonException($"Uncatched Exception: {e.Message}");
            }
        }

        /// <summary>
        /// 发送控制请求
        /// </summary>
        /// <param name="message">请求报文</param>
        /// <returns></returns>
        public async Task<ResponseContent> Post2(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.Timeout = new TimeSpan(0, 0, 15);

                try
                {
                    var content = new StringContent(message);

                    var response = await client.PostAsync(this.host, content);

                    ResponseContent rc = new ResponseContent();

                    rc.StatusCode = response.StatusCode;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        rc.ResponseMessage = await response.Content.ReadAsStringAsync();
                    else
                        rc.ResponseMessage = await response.Content.ReadAsStringAsync();

                    return rc;
                }
                catch (HttpRequestException e)
                {
                    ResponseContent rc = new ResponseContent();
                    rc.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    rc.ErrorMessage = e.Message;
                    return rc;
                }
                catch (Exception e)
                {
                    ResponseContent rc = new ResponseContent();
                    rc.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    rc.ErrorMessage = e.Message;
                    return rc;
                }
            }
        }
        #endregion //Method
    }
}
