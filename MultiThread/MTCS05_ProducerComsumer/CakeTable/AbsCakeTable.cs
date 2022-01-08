using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    abstract class AbsCakeTable
    {
        public abstract void PutCake(string cake);
        public abstract string TakeCake();

        public virtual void ClearCake()
        {
            throw new NotImplementedException();
        }
    }//class
}
