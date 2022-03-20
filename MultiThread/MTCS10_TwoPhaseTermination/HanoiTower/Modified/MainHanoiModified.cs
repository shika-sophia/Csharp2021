/** 
 *@see ../Original/MainHanoiOriginal.cs
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.HanoiTower.Modified 
{ 
    class MainHanoiModified 
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            Console.WriteLine("Main() BEGIN");
            Thread.CurrentThread.Name = "MainThread";
            var hanoi = new HanoiThreadModified();
            try
            {
                Thread th = new Thread(hanoi.Run);
                th.Name = "HanoiThread";
                th.Start();

                Thread.Sleep(3000);

                Console.WriteLine("Main ShutdownRequest()");
                hanoi.ShutdownRequest(th);

                Console.WriteLine("Main Join()");
                th.Join();
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Interrupt()");
            }

            Console.WriteLine("Main() END");
        }//Main() 

    } 
}

/*
Main() BEGIN
==== Level 0 ====

==== Level 1 ====
A -> B,
==== Level 2 ====
A -> C, A -> B, C -> B,
==== Level 3 ====
A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B,
==== Level 4 ====
A -> C, A -> B, C -> B, A -> C, B -> A, B -> C, A -> C, A -> B, C -> B, C -> A, B -> A, C -> B, A -> C, A -> B, C -> B,
 :
A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B, Main ShutdownRequest()
C -> A, C -> B, A -> C, A -> B, A -> C, A -> B,
DoShutDown() costTime = 2 msec
Main Join()
Main() END
 */