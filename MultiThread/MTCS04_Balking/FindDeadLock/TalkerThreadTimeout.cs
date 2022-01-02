
using CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock
{
    class TalkerThreadTimeout
    {
        private readonly RequestQueueSyncTimeout input;
        private readonly RequestQueueSyncTimeout output;
        private readonly string name;
        private const int LIMIT = 20;

        public TalkerThreadTimeout(
            RequestQueueSyncTimeout input, RequestQueueSyncTimeout output, string name)
        {
            this.input = input;
            this.output = output;
            this.name = name;
        }

        public void Run()
        {
            Console.WriteLine($"{name}: BEGIN");

            for(int i = 0; i < LIMIT; i++)
            {
                RequestMT03 request = input.GetRequest();
                Console.WriteLine($"{name}: GET {request}");

                RequestMT03 requestMod = new RequestMT03(request.GetName() + "!");
                output.PutRequest(requestMod);
                Console.WriteLine($"{name}: PUT {requestMod}");
            }//for

            Console.WriteLine($"{name}: END");
        }//Run()
    }//class
}
