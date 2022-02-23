using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.MiniServer
{
    class MiniServerMT07
    {
        private readonly MiniServerService service
            = new MiniServerService();
        private readonly int portNum;

        public MiniServerMT07(int portNum)
        {
            this.portNum = portNum;
        }

        public void execute()
        {
            using (var listener = new HttpListener())
            {
                string localhost = $"https://localhost:{portNum}";
                listener.Prefixes.Add(localhost);
                listener.Start();
                Console.WriteLine($"WebLisening on {localhost}");
                
                service.DoResponse(listener);
                
                
            }//using as lister.Stop()
        }//execute()
    }//class
}
