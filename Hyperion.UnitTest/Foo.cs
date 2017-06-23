using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hyperion.UnitTest
{
    public class Foo
    {
        private int sum = 0;

        public int Add(int x, int y)
        {
            this.sum = x + y;
                        
            Thread.Sleep(200);
            return x + y;
        }

        public int GetSum()
        {
            return sum;
        }
    }
}
