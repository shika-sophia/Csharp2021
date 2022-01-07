
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.Exchanger
{
    class ExchangerCS<T>
    {
        private T obj1;
        private T obj2;

        public ExchangerCS() { }
        public ExchangerCS(T obj1, T obj2)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
        }

        public T Exchange(T objArg)
        {
            if(obj1 == null)
            {
                obj1 = objArg;

                while(obj2 == null)
                {
                    Thread.SpinWait(100);
                }//while

                return obj2;
            }

            if (objArg.Equals(obj1))
            {
                while(obj2 == null)
                {
                    Thread.SpinWait(100);
                }//while

                return obj2;
            }
            else // objArg != obj1
            {
                //【型判定】ジェネリックの場合はコンパイルエラーとなるので不要
                // Actually, this case is not necessary,
                // because it throws 'Compile Error' in Generic class.

                //if (objArg.GetType() != obj1.GetType())
                //{
                //    throw new ArgumentException(
                //        "<!> different Type of the argument.");
                //}

                if (obj2 == null)
                {
                    obj2 = objArg;
                    Thread.Yield();

                    return obj1;
                }
                else //obj2 != null
                {
                    T objTemp = obj1;
                    obj1 = objArg;
                    obj2 = objTemp;

                    //====【Algorism】Example ====
                    //---- Fhase 1 ----
                    //obj1 = a, obj2 = b
                    //---- Fhase 2 ----
                    //objArg = c
                    //objTemp = a, obj1 = c, obj2 = a
                    //---- Fhase 3 ----
                    //objArg = b
                    //objTemp = c, obj1 = b, obj2 = c
                    //---- Fhase 4 ----
                    //objArg = a
                    //objTemp = b, obj1 = a, obj2 = b

                    return objTemp;
                }
            }            
        }//Exchange()

    }//class
}
