﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Communication
{
    /// <summary>
    /// 控制请求类
    /// </summary>
    public class Request
    {
        #region Field
        private string host = "http://192.168.0.116/WEB/";
        //private string host = "http://localhost";
        #endregion //Field

        #region Method
        /// <summary>
        /// 发送控制请求
        /// </summary>
        /// <param name="message">请求报文</param>
        /// <returns></returns>
        public async Task<string> Post(string message)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 15);

            try
            {
                //var content = new FormUrlEncodedContent(new[]
                //{
                //    new KeyValuePair<string, string>("", message)
                //});

                var content = new StringContent(message);

                var result = await client.PostAsync(this.host, content);

                var statusCode = result.StatusCode;

                var resultContent = await result.Content.ReadAsStringAsync();

                return resultContent;
            }
            catch (HttpRequestException e)
            {
                return $"Http Exception :{e.Message}";
            }
            catch(Exception e)
            {
                return $"Uncatched Exception: {e.Message}";
            }
        }
        #endregion //Method
    }
}
