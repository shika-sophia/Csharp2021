using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterProperties
{
    abstract class AbsPropertyFileGY02
    {
        public abstract void ReadFile(string loadFile);
        public abstract void WriteFile(string saveFile);
        public abstract void SetProperty(string key, string value);
        public abstract string GetValue(string key);
        public abstract string ToStringAll(string header = "");
    }//class
}
