using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.DeadLock
{
    class EaterThread
    {
        private int count = 1;
        private const int TIMES = 100;
        private string name;
        private readonly ToolDeadLock left;
        private readonly ToolDeadLock right;
        private readonly ToolPair pair;

        public EaterThread(
            string name, ToolDeadLock left, ToolDeadLock right)
        {
            this.name = name;
            this.left = left;
            this.right = right;
        }

        public EaterThread(string name, ToolPair pair)
            : this(name, pair.Left, pair.Right)
        {
            this.pair = pair;
        }

        public void Run()
        {
            while (count <= TIMES)
            {
                if(pair == null)
                {   //MainDeadLock, MainAvoidDeadLock - SameOrder
                    Eat();
                }
                else //MainAvoidDeadLock - Pair
                {
                    EatByPair();
                }
 
                count++;
            }//while

            count--;
            Console.WriteLine($"==== {name} ate {count} times. ====");
        }

        public void Eat()
        {
            lock (left)
            {
                Console.WriteLine($"{name} takes up {left} (left).");

                lock (right)
                {
                    Console.WriteLine($"{name} takes up {right} (right).");
                    Console.WriteLine($"[{count}] {name} is eating now, yum yum!");
                    Console.WriteLine($"{name} put down {right} (right).");
                }

                Console.WriteLine($"{name} put down {left} (reft).");
            }
        }

        private void EatByPair()
        {
            lock (pair)
            {
                Console.WriteLine($"{name} takes up {pair}.");
                Console.WriteLine($"[{count}] {name} is eating now, yum yum!");
                Console.WriteLine($"{name} put down {pair}.");
            }
        }
    }//class
}
