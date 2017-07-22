using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// TLV相关编码
    /// </summary>
    public static class TLVCode
    {
        /// <summary>
        /// 服务器返回值
        /// </summary>
        public static Dictionary<string, string> ServerReturnCode = new Dictionary<string, string>
        {
            ["0"] = "操作成功",
            ["1"] = "操作失败",
            ["2"] = "用户名/设备序列号不正确",
            ["3"] = "用户名/用户密码不正确",
            ["4"] = "房屋名称/房屋序列号不正确",
            ["5"] = "房间名称/房间序列号不正确",
            ["6"] = "设备名称/设备序列号不正确",
            ["7"] = "房屋名称已经存在",
            ["8"] = "房间名称已经存在",
            ["9"] = "用户不在线/请用户重新登录",
            ["A"] = "设备不在线",
            ["B"] = "验证码错误",
            ["C"] = "验证码过期",
            ["D"] = "用户不存在",
            ["E"] = "用户的手机号码不存在或者格式不正确",
            ["F"] = "用户已经注册",
            ["65"] = "SELECT查询无复合条件结果",
            ["CB"] = "登陆用户名/密码不匹配",
            ["D0"] = "增加的设备在当前用户下已经存在",
            ["D1"] = "删除的设备在当前用户下不存在"
        };
    }
}
