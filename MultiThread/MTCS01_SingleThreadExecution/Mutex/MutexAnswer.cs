/*
 *@status NG: DeadLock / I don't find why.
 *
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 練習問題 1-7 / p84, p478 / List 1-17, A1-10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Mutex
{
    class MutexAnswer : AbsMutex
    {
        private volatile int locks = 0;
        private volatile int thCount = 0;
        private volatile Thread owner = null;
        private readonly int thMax;
        private readonly Random random = new Random();

        public MutexAnswer(int thMax)
        {
            this.thMax = thMax;
        }

        internal override void Lock()
        {
            lock (this)
            {
                Thread me = Thread.CurrentThread;
                thCount++;
                while (locks > 0 && owner != me)
                {
                    Thread.SpinWait(random.Next(100) + 50);

                    if (thCount >= thMax)
                    {
                        break;
                    }
                }//while
                thCount--;

                owner = me;
                locks++;
            }//lock() as synchronized
        }//MutexAnswer.Lock()

        internal override void Unlock()
        {
            Thread me = Thread.CurrentThread;
            if (locks == 0 || owner != me)
            {
                return;
            }

            locks--;

            if(locks == 0)
            {
                owner = null;
            }

            Thread.Yield();
        }//Unlock()
    }//class
}

/*
//==== MutexAnswer ====
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN

(-- DeadLock --)
 */