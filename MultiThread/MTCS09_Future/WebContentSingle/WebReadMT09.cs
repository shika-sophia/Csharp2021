
namespace CsharpBegin.MultiThread.MTCS09_Future.WebContentSingle
{
    class WebReadMT09
    {
        public static AbsContentMT09 ReadSiteSync(string url)
        {
            return new ReadContentSync(url);
        }
    }//class
}