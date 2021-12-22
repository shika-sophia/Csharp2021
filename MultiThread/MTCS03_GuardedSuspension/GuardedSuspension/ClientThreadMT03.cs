using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension
{
    class ClientThreadMT03
    {
        private readonly RequestQueue queue;
        private readonly string thName;
        private readonly Random random;
        private const int LIMIT = 10_000;

        public ClientThreadMT03(RequestQueue queue, string thName, int seed)
        {
            this.queue = queue;
            this.thName = thName;
            this.random = new Random(seed);
        }

        public void Run()
        {
            for(int i = 0; i < LIMIT; i++)
            {
                var request = new RequestMT03($"No.{i}");
                Console.WriteLine($"ClientThread {thName}: requests {request}");
                queue.PutRequest(request);

                Thread.Sleep(random.Next(1000));
            }//for
        }//Run()
    }//class
}
