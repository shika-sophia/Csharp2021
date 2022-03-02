
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    abstract class AbsChannelMT08
    {
        public abstract void StartWorker();
        public abstract void PutRequest(RequestMT08 req);
        public abstract RequestMT08 TakeRequest();

    }//class
}