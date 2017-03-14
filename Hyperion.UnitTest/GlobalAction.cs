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
            string cs = "server = 192.168.0.111; user = hc; database = test_zml; port = 3306; password = webDev;";
            Cache.Instance.Add("ConnectionString", cs);            
        }
    }
}
