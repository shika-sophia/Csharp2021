/*
 * @see MainDeadLock.cs
 * @content Practice Answer 1-6 DeadLock / p475 / List A1-5 ～ A1-8
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.DeadLock
{
    class MainAvoidDeadLock
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            Console.WriteLine($"Testing EaterThread");
            var spoon = new ToolDeadLock("Spoon");
            var fork = new ToolDeadLock("Fork");

            //デッドロック発生 MainDeadLock [COPY]
            //var eaterA = new EaterThread("Alice", spoon, fork);
            //var eaterB = new EaterThread("Bobby", fork, spoon);

            //【対策１ Pair】デッドロック発生要件①
            // => 複数の SharedResourceを 1つにする。
            var pair = new ToolPair(spoon, fork);
            var eaterA = new EaterThread("Alice", pair);
            var eaterB = new EaterThread("Bobby", pair);

            //【対策２ SameOrder】デッドロック発生要件③
            // => ロック順を一定にすることで回避。
            //var eaterA = new EaterThread("Alice", spoon, fork);
            //var eaterB = new EaterThread("Bobby", spoon, fork);

            new Thread(eaterA.Run).Start();
            new Thread(eaterB.Run).Start();
        }//Main() 
    }//class
}

/*
//#### MainAvoidDeadLock by SameOrder ####
Testing EaterThread
Alice takes up [Spoon] (left).
Alice takes up [Fork] (right).
[0] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
Alice takes up [Spoon] (left).
Alice takes up [Fork] (right).
  :
[4] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
Bobby takes up [Spoon] (left).
Bobby takes up [Fork] (right).
[1] Bobby is eating now, yum yum!
Bobby put down [Fork] (right).
Bobby put down [Spoon] (reft).
Bobby takes up [Spoon] (left).
Bobby takes up [Fork] (right).
  :
[100] Bobby is eating now, yum yum!
Bobby put down [Fork] (right).
Bobby put down [Spoon] (reft).
==== Bobby ate 100 times. ====
[100] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
==== Alice ate 100 times. ====

//#### MainAvoidDeadLock Pair ####
 [99] Bobby is eating now, yum yum!
Bobby put down Pair([Spoon], [Fork]).
Alice takes up Pair([Spoon], [Fork]).
[100] Alice is eating now, yum yum!
Alice put down Pair([Spoon], [Fork]).
==== Alice ate 100 times. ====
Bobby takes up Pair([Spoon], [Fork]).
[100] Bobby is eating now, yum yum!
Bobby put down Pair([Spoon], [Fork]).
==== Bobby ate 100 times. ====

 */
