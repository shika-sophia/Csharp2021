using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.ResponseGUI
{
    class MyFrame
    {
        private ButtonAction btnAct = new ButtonAction();
        public MyFrame()
        {
            //Instead of GUI
        }//Constructor

        public void Btn_OnClick()
        {
            //btnAct.DoAction();
            //btnAct.ActThreadPerMessage();
            //btnAct.ActSingle();
            //btnAct.ActBalking();
            btnAct.ActInterrupt();
        }
        
    }//class
}
