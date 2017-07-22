using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Hyperion.WebAPI.Utility
{
    using Hyperion.ControlClient.Communication;

    /// <summary>
    /// 设备服务操作类
    /// </summary>
    public class EquipmentServerAction
    {
        #region Method
        /// <summary>
        /// 发送请求到设备服务器
        /// </summary>
        /// <param name="message">请求报文</param>
        /// <returns></returns>
        public string RequestToServer(string message)
        {
            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(message);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            return content;
        }
        #endregion //Method
    }
}