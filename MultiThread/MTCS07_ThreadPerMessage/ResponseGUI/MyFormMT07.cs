using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.ResponseGUI
{
    class MyFormMT07 : Form
    {
        private ButtonAction btnAct = new ButtonAction();
        public MyFormMT07()
        {
            Label label = new Label();
            label.Text = "";

            Button button = new Button();
            button.Text = "Execute";
            button.Size = new Size(120, 40);
            button.Click += new EventHandler(Btn_OnClick);

            this.AutoSize = true;
            this.Location = new Point(10, 20);
            this.Controls.Add(button);
        }//Constructor

        public void Btn_OnClick(object sender, EventArgs e)
        {
            //btnAct.DoAction();
            btnAct.ActThreadPerMessage();
            //btnAct.ActSingle();
            //btnAct.ActBalking();
            //btnAct.ActInterrupt();
        }
        
    }//class
}
