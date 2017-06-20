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

    internal class EquipmentService : IEquipmentService
    {
        private string host = "http://localhost:6024/api/";

        public long Count()
        {
            throw new NotImplementedException();
        }

        public long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public Equipment Create(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public Equipment Create(Equipment entity, bool generateKey)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> FindAllNormal()
        {
            throw new NotImplementedException();
        }

        #region Method
        public async Task<Equipment> FindById(long id)
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

        public IEnumerable<Equipment> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public Equipment FindOneByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public bool Update(Equipment entity)
        {
            throw new NotImplementedException();
        }

        Equipment IBaseService<Equipment, long>.FindById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
