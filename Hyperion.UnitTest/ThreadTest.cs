using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public class ThreadTest
    {
        private readonly ITestOutputHelper output;


        public ThreadTest(ITestOutputHelper output)
        {
            this.output = output;
            GlobalAction.Initialize();
        }

        private Foo foo = new Foo();

        public Task<int> RunFind(int x, int y)
        {
            var task = Task<int>.Run(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                int sum = foo.Add(x, y);

                st.Stop();

                output.WriteLine(string.Format("x is {0}, y is {1}, sum is {2}", x, y, sum));

                int g = foo.GetSum();

                Assert.Equal(sum, g);

                return sum;
            });

            return task;
        }


        [Fact]
        public void TestSum()
        {
            List<Task> tasks = new List<Task>();

            Stopwatch total = new Stopwatch();

            total.Start();
            for (int i = 1; i < 10; i++)
            {
                var task = RunFind(i, i * 3);                
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            total.Stop();
            output.WriteLine(string.Format("total time is {0} millisecond", total.ElapsedMilliseconds));
        }

    }
}
