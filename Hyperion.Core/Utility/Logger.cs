using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.Utility
{
    using Poseidon.Common;

    /// <summary>
    /// 日志类
    /// </summary>
    public class Logger
    {
        #region Field
        /// <summary>
        /// 单件实例
        /// </summary>
        private static volatile Logger instance = null;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object lockHelper = new object();

        /// <summary>
        /// 实例锁变量
        /// </summary>
        private static object lockInstance = new object();

        /// <summary>
        /// 日志路径
        /// </summary>
        private string folder;

        /// <summary>
        /// 启用调试日志
        /// </summary>
        private bool enableDebug = true;
        #endregion //Field

        #region Constructor
        private Logger()
        {
            this.folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

            string d = AppConfig.GetAppSetting("EnableDebug");
            this.enableDebug = Convert.ToBoolean(d);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message">错误信息</param>
        private void WriteLine(string message)
        {
            string text = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]\t\t") + message + "\r\n";
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                File.AppendAllText(Path.Combine(folder, fileName), text, Encoding.GetEncoding("utf-8"));
            }
            catch (Exception e)
            {
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            if (this.enableDebug)
            {
                this.WriteLine(message);
            }
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            this.WriteLine(message);
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void Exception(string message, Exception e)
        {
            this.WriteLine(message + "\r\n" + e.Message);
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 单件实例
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion //Property
    }
}
