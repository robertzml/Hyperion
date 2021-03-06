﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 响应设备信元
    /// </summary>
    [DataContract]
    public class DeviceNode
    {
        #region Constructor
        public DeviceNode()
        {
            this.Name = "";
            this.Vendor = "";
            this.Type = "";
            this.Version = "";
            this.SerialNumber = "";
            this.HasStatus = 0;
        }
        #endregion //Constructor

        #region Property
        /// <summary>
        /// 设备名称 0x123
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 设备厂商 0x124
        /// </summary>
        [DataMember(Name = "vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// 设备类型 0x125
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 设备版本 0x126
        /// </summary>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// 设备序列号 0x127
        /// </summary>
        [DataMember(Name = "serialnumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 表示是否包含状态 0:不包含 1:包含
        /// </summary>
        [DataMember(Name = "hasstatus")]
        public int HasStatus { get; set; }

        /// <summary>
        /// 设备状态 0x128
        /// </summary>
        [DataMember(Name = "status")]
        public TLV Status { get; set; }

        /// <summary>
        /// 在线状态 0x129
        /// </summary>
        [DataMember(Name = "online")]
        public int Online { get; set; }

        /// <summary>
        /// 主板序列号 0x12B
        /// </summary>
        [DataMember(Name = "mainboardserialnumber")]
        public string MainboardSerialNumber { get; set; }

        /// <summary>
        /// 用户设备编码
        /// </summary>
        [DataMember(Name = "userDeviceCode")]
        public string UserDeviceCode { get; set; }
        #endregion //Property
    }
}
