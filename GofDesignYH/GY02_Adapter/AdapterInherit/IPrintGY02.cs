﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterInherit
{
    interface IPrintGY02
    {
        void PrintStrong(); //暗黙的に public abstract
        void PrintWeak();   //暗黙的に public abstract
    }//interface
}
