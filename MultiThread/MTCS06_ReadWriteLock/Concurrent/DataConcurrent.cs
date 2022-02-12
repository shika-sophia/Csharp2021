using CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Concurrent
{
    class DataConcurrent : AbsDataMT06
    {
        private char[] buffer;
        private ReaderWriterLockSlim lockRW;

        public DataConcurrent(int bufferSize, ReaderWriterLockSlim lockRW)
        {
            this.buffer = new char[bufferSize];
            InitCharArray(ref buffer);
            this.lockRW = lockRW;
        }

        private char[] InitCharArray(ref char[] charAry)
        {
            for(int i = 0; i < charAry.Length; i++)
            {
                charAry[i] = '*';
            }

            return charAry;
        }//InitCharArray()

        public override char[] TryRead()
        {
            lockRW.EnterReadLock();
            try
            {
                return DoRead();
            }
            finally
            {
                lockRW.ExitReadLock();
            }
        }

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

        public override void TryWrite(char c)
        {
            lockRW.EnterWriteLock();
            try
            {
                DoWrite(c);
            }
            finally
            {
                lockRW.ExitWriteLock();
            }
        }//TryWrite()

        private void DoWrite(char c)
        {
            for(int i= 0; i < buffer.Length; i++)
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
