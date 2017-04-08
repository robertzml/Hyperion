using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class AlarmReportTest
    {
        public AlarmReportTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindByUser()
        {
            int userid = 23;

            var data = BusinessFactory<AlarmReportBusiness>.Instance.FindByUser(userid).ToList();

            Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            var count = BusinessFactory<AlarmReportBusiness>.Instance.Count();

            Assert.AreEqual(56, count);
        }

        [TestMethod]
        public void TestFindWithPage()
        {
            var data = BusinessFactory<AlarmReportBusiness>.Instance.FindWithPage(10, 20).ToList();
            Assert.AreEqual(20, data.Count);
        }

        [TestMethod]
        public void TestThread()
        {
            Task<int> task = new Task<int>(() =>
            {
                var data = BusinessFactory<AlarmReportBusiness>.Instance.FindAll();
                return data.Count();
            });

            task.Start();
            Console.WriteLine("Start");

            task.Wait();
            var result = task.Result;
            Console.WriteLine(result.ToString());

            //task.Wait();
            //Console.WriteLine("result:" + task.Result.ToString());
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread(FindAll);
            //    thread.Start();
            //    Console.WriteLine("loop " + i.ToString());
            //}

            Assert.AreEqual(56, result);
            Console.WriteLine("FindAll");
        }

        [TestMethod]
        public void TestThread2()
        {
            Console.WriteLine("test start");

            for (int i = 0; i < 1000; i++)
            {
                var result = FindAll();
                Console.WriteLine(result.Result.ToString());
            }

            Assert.IsTrue(true);
            Console.WriteLine("test end");
        }

        private async Task<int> FindAll()
        {
            Task<int> task = new Task<int>(() =>
            {
                var data = BusinessFactory<AlarmReportBusiness>.Instance.FindAll();
                return data.Count();
            });

            task.Start();

            Console.WriteLine("task is running");
            //var result = await task;
            return await task;
        }
    }
}
