using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hyperion.UnitTest
{
    using Xunit;
    using Xunit.Abstractions;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    public class EquipmentTest
    {
        private readonly ITestOutputHelper output;


        public EquipmentTest(ITestOutputHelper output)
        {
            this.output = output;
            GlobalAction.Initialize();
        }

        public async Task<Equipment> FindById(long id)
        {
            string host = "http://localhost:6024/api/";

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

        [Fact]
        public void TestCreate()
        {
            Equipment entity = new Equipment();
            entity.SerialNumber = "qwerty";
            entity.Vendor = "Mulan";
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = entity.CreateTime;
            entity.Online = 1;
            entity.Status = 0;

            var result = BusinessFactory<EquipmentBusiness>.Instance.Create(entity);


            Assert.Equal(entity.SerialNumber, result.SerialNumber);
        }

        [Fact]
        public void TestFind()
        {
            var data = BusinessFactory<EquipmentBusiness>.Instance.FindAll();

            Assert.Equal(1, data.Count());
        }

        [Fact]
        public void TestCreateBatch()
        {
            int index = 0;
            for (int i = 0; i < 10000; i++)
            {
                Equipment entity = new Equipment();
                entity.SerialNumber = "abcedfg" + i.ToString();
                entity.Vendor = i % 3 == 0 ? "Mulan" : "Aupu";
                entity.CreateTime = DateTime.Now;
                entity.UpdateTime = entity.CreateTime;
                entity.Online = 1;
                entity.Status = 0;

                var result = BusinessFactory<EquipmentBusiness>.Instance.Create(entity);
                index = i;
            }

            Assert.Equal(9999, index);
        }

        [Fact]
        public void TestFindInThread2()
        {
            List<Task> tasks = new List<Task>();

            Stopwatch total = new Stopwatch();

            total.Start();
            for (int i = 1; i < 3; i++)
            {
                var task = RunFind2(i);
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            total.Stop();
            output.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));

            Assert.InRange(total.ElapsedMilliseconds, 0, 500000);
        }


        public Task RunFind2(int id)
        {
            var task = Task.Run(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                var result = BusinessFactory<EquipmentBusiness>.Instance.FindById(id);

                st.Stop();

                Assert.Equal(id, result.Id);

                output.WriteLine(string.Format("find time id is {0}, in {1} milliseconds", id, st.ElapsedMilliseconds));
            });

            return task;
        }

        public Task RunFind(int id)
        {
            var task = Task.Run(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                var t = FindById(id);

                var equipment = t.Result;

                st.Stop();

                output.WriteLine(string.Format("find time id is {0}, in {1} milliseconds", id, st.ElapsedMilliseconds));
            });

            return task;
        }
        

        [Fact]
        public void TestFindInThread()
        {
            List<Task> tasks = new List<Task>();
            

            Stopwatch total = new Stopwatch();

            total.Start();
            for (int i = 1; i < 7; i++)
            {
                var task = RunFind(i);
                
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            total.Stop();
            output.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));

            Assert.InRange(total.ElapsedMilliseconds, 0, 500000);
        }
        
    }
}
