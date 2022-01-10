using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    class DataMT06
    {
        private readonly char[] buffer;
        private readonly AbsReadWrite lockRW;
            
        public DataMT06(int bufferSize, AbsReadWrite lockRW)
        {
            this.buffer = new char[bufferSize];
            this.lockRW = lockRW;
            
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = '*';
            }
        }

        public char[] TryRead()
        {
            lockRW.ReadLock();
            try
            {
                return DoRead();
            }
            finally
            {
                lockRW.ReadUnlock();
            }
        }//TryRead()

        public void TryWrite(char c)
        {
            lockRW.WriteLock();
            try
            {
                DoWrite(c);
            }
            finally
            {
                lockRW.WriteUnlock();
            }
        }//TryWrite()

        private char[] DoRead()
        {
            char[] newBuffer = new char[buffer.Length];

            for(int i = 0; i < buffer.Length; i++)
            {
                newBuffer[i] = buffer[i];
            }

            Slowly();

            return newBuffer;
        }//DoRead()

        private void DoWrite(char c)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = c;
                Slowly();
            }
        }//DoWrite()

        private void Slowly()
        {
            try
            {
                Thread.Sleep(50);
            }
            catch (ThreadInterruptedException) { }
        }//Slowly()
    }//class
}
