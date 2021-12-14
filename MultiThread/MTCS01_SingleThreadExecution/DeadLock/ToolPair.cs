namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.DeadLock
{
    public class ToolPair
    {
        public ToolDeadLock Left { get; private set; }
        public ToolDeadLock Right { get; private set; }

        public ToolPair(ToolDeadLock left, ToolDeadLock right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override string ToString()
        {
            return $"Pair({Left}, {Right})";
        }
    }//class
}

