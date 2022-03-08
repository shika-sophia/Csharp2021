using System;
using System.Net;

namespace CsharpBegin.MultiThread.MTCS09_Future.WebContentSingle
{
    internal class ReadContentSync : AbsContentMT09
    {
        private byte[] byteAry;

        public ReadContentSync(string url)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    this.byteAry = wc.DownloadData(url);
                    wc.Dispose();
                }//using
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//ReadContentSync()

        public override byte[] GetByteAry()
        {
            return byteAry;
        }
    }
}