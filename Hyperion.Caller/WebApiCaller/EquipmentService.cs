using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.WebApiCaller
{
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;
    using Poseidon.Base.Framework;

    /// <summary>
    /// 设备访问服务类
    /// </summary>
    public class EquipmentService : AbstractApiService<Equipment, long>, IEquipmentService
    {
        #region Constructor
        /// <summary>
        /// 设备访问服务类
        /// </summary>
        public EquipmentService() : base("equipment")
        {
            this.host = "http://localhost:6024/api/";
            //this.bl = this.baseBL as EquipmentBusiness;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        //protected override Equipment GetEntity(string url)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        Equipment entity = new Equipment();

        //        HttpResponseMessage response = client.GetAsync(url).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            entity = response.Content.ReadAsAsync<Equipment>().Result;
        //        }

        //        return entity;
        //    }
        //}
        #endregion //Function

        #region Method
        public Equipment GetByFake(long id)
        {
            string url = host + "equipment?fake=" + id.ToString();
            var entity = GetEntity(url);
            return entity;
        }

        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        //public override Equipment FindById(long id)
        //{
        //    string url = host + controller + "/" + id.ToString();
        //    Equipment entity = GetEntity(url);

        //    if (entity == null)
        //        throw new Exception("Some thing happen");
        //    return entity;
        //}
        #endregion //Method
    }
}
