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

        #region Method
        public async Task<Equipment> FindByIdAsync(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                Equipment equipment = null;
                string url = host + "equipment/" + id.ToString();

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    equipment = await response.Content.ReadAsAsync<Equipment>();
                }

                return equipment;
            }
        }
        #endregion //Method
    }
}
