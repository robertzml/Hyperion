using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hyperion.WebAPI
{
    using Poseidon.Common;
    using Hyperion.Core.Utility;
    using log4net;
    using log4net.Config;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string cs = AppConfig.GetConnectionString();
            Cache.Instance.Add("ConnectionString", cs);

            string dalPrefix = AppConfig.GetAppSetting("DALPrefix");
            Cache.Instance.Add("DALPrefix", dalPrefix);

            string equipmentHost = AppConfig.GetAppSetting("EquipmentHost");
            Cache.Instance.Add("EquipmentHost", equipmentHost);

            string bizHost = AppConfig.GetAppSetting("BizHost");
            Cache.Instance.Add("BizHost", bizHost);

            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            Logger.Instance.Info("Application Start");
        }
    }
}
