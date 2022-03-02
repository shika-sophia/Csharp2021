
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    class ClientThreadMT08
    {
        private readonly Random random = new Random();
        private readonly AbsChannelMT08 channel;
        private readonly string thName;

        public ClientThreadMT08(
            string thName, AbsChannelMT08 channel)
        {
            this.thName = thName;
            this.channel = channel;
        }

        public void Run()
        {
            try
            {
                for(int i = 0; true; i++)
                {
                    RequestMT08 req = new RequestMT08(thName, i);
                    channel.PutRequest(req);
                    //Thread.Sleep(random.Next(1000));
                }//for loop
            }
            catch (ThreadInterruptedException) { }
        }//Run()
    }//class
}
