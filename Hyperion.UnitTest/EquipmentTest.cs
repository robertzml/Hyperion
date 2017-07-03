using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    /// <summary>
    /// 设备测试
    /// </summary>
    [TestClass]
    public class EquipmentTest
    {
        #region Constructor
        public EquipmentTest()
        {
            GlobalAction.Initialize();

            Cache.Instance.Add("CallerType", "webapi");
        }
        #endregion //Constructor

        #region Function
        private Task FindFakeInTask(long id)
        {
            var task = Task.Run(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                var result = CallerFactory<IEquipmentService>.Instance.GetByFake(id);

                st.Stop();

                Assert.AreEqual(id, result.Id);

                Console.WriteLine(string.Format("find id:{0}, in {1} milliseconds", id, st.ElapsedMilliseconds));
            });

            return task;
        }

        private Task FindOneInTask(long id)
        {
            var task = Task.Run(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                var result = CallerFactory<IEquipmentService>.Instance.FindById(id);

                st.Stop();

                Assert.AreEqual(id, result.Id);

                Console.WriteLine(string.Format("find id:{0}, in {1} milliseconds", id, st.ElapsedMilliseconds));
            });

            return task;
        }


        private Task FindOneInAsync(long id)
        {
            var task = Task.Run(() =>
            {
                var result = CallerFactory<IEquipmentService>.Instance.FindByIdAsync(id).Result;

                Assert.AreEqual(id, result.Id);

                Console.WriteLine(string.Format("find id:{0}, number: {1}", id, result.SerialNumber));
            });

            return task;
        }
        #endregion //Function

        #region Test
        [TestMethod]
        public void TestFindOne()
        {
            long id = 5;

            var call = CallerFactory<IEquipmentService>.Instance;
            var entity = call.FindById(id);

            Assert.AreEqual("abcedfg2", entity.SerialNumber);
        }

        /// <summary>
        /// 异步获取设备
        /// </summary>
        [TestMethod]
        public void TestFindOneAsync()
        {
            long id = 2;

            var call = CallerFactory<IEquipmentService>.GetInstance(CallerType.WebApi);
            var entity = call.FindByIdAsync(id).Result;

            Assert.AreEqual("qwerty", entity.SerialNumber);
        }

        /// <summary>
        /// 顺序访问同步调用
        /// </summary>
        [TestMethod]
        public void TestFindSeq()
        {
            long count = 10;

            Stopwatch total = new Stopwatch();

            total.Start();
            for (long i = 1; i <= count; i++)
            {
                var entity = CallerFactory<IEquipmentService>.Instance.FindById(i);
                Assert.AreEqual(i, entity.Id);
                Console.WriteLine("equipment id is {0}, number is {1}", entity.Id, entity.SerialNumber);
            }

            total.Stop();
            Console.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }

        /// <summary>
        /// 顺序访问异步调用
        /// </summary>
        [TestMethod]
        public void TestFindSeqAsync()
        {
            long count = 10;

            Stopwatch total = new Stopwatch();

            total.Start();
            for (long i = 1; i <= count; i++)
            {
                var entity = CallerFactory<IEquipmentService>.Instance.FindByIdAsync(i).Result;
                Assert.AreEqual(i, entity.Id);
                Console.WriteLine("equipment id is {0}, number is {1}", entity.Id, entity.SerialNumber);
            }

            total.Stop();
            Console.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }

        /// <summary>
        /// 顺序访问异步调用
        /// </summary>
        [TestMethod]
        public void TestFindSeqAsyncInThread()
        {
            long count = 10;

            Stopwatch total = new Stopwatch();
            total.Start();

            List<Task> tasks = new List<Task>();
            
            for (long i = 1; i <= count; i++)
            {
                var task = FindOneInAsync(i);

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            total.Stop();
            Console.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }

        /// <summary>
        /// 并发读取设备,不访问数据库
        /// </summary>
        [TestMethod]
        public void TestFindFakeInThread()
        {
            long count = 5;

            List<Task> tasks = new List<Task>();

            Stopwatch total = new Stopwatch();

            total.Start();
            for (long i = 1; i <= count; i++)
            {
                var task = FindFakeInTask(i);

                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            total.Stop();
            Console.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }

        /// <summary>
        /// 并发读取设备
        /// </summary>
        [TestMethod]
        public void TestFindOneInThread()
        {
            long count = 5;

            List<Task> tasks = new List<Task>();

            Stopwatch total = new Stopwatch();

            total.Start();
            for (long i = 1; i <= count; i++)
            {
                var task = FindOneInTask(i);

                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            total.Stop();
            Console.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }
        #endregion //Test
    }
}
