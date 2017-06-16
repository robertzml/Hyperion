using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.UnitTest
{
    using Poseidon.Common;

    public static class GlobalAction
    {
        /// <summary>
        /// 数据库连接初始化
        /// </summary>
        public static void Initialize()
        {
            string cs = "server=192.168.0.116;user=hcDev;database=water_heater;port=3306;password=Molan@2017!@#;allow zero datetime=true";
            Cache.Instance.Add("ConnectionString", cs);
        }
    }
}
