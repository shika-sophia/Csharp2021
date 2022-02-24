/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / ResponseGUI  / MainResponseGUI.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content GUIのButton応答性を速くする
 */
#region -> [C#] GUIプログラム
/*
 *@subject [C#] GUIプログラム 〔VS2019〕
 *         ASP.NET Frameworkを利用すべきだが、
 *         Windows Formは C#プログラムから起動できる GUIである。
 *         => see /WinFormGUI
 *         
 *@subject Main
 *         void System.Windows.Forms.Application.
 *             EnableVisualStyles();  スタイル描画を有効化
 *         void System.Windows.Forms.Application.
 *             Run(Form);             実行
 *             
 *         ◆System.Windows.Forms
 *         ＊Label
 *         string label.Text;
 *         
 *         ＊Button
 *         string button.Text;
 *         Size   button.Size;
 *         EventHandler button.Click;
 *            += new EventHandler(object sender, EventArgs e);
 *         
 *         ＊Form
 *         Point form.Location;
 *         bool  form.AutoSize;
 *         ControlCollection form.Controls
 *               form.Controls.Add(Control);
 *         
 */
#endregion
/*
 *@content Console表示で再現
 *         MyFrame.BtnClick()内のボタン時の処理を切替
 *         public void Btn_OnClick()
 *         {
 *             //btnAct.DoAction();
 *             //btnAct.ActThreadPerMessage();
 *             //btnAct.ActSingle();
 *             //btnAct.ActBalking();
 *             btnAct.ActInterrupt();
 *           }
 *           
 *@subject ButtonAction.DoAction()
 *         これだけを呼び出すと、MainThreadで処理をする SingleThread
 *         処理完了まで制御は戻らず、Buttonの応答性は処理完了までなくなる。
 *         
 *@subject 【解答１】ButtonAction.ActThreadPerMessage()
 *         ||Thread per Message||パターンを利用して
 *         DoAction()の実行中も、ボタンが押されると
 *         new Threadで DoAction()を実行。
 *         
 *@subject 【解答２】ButtonAction.ActSingle()
 *          ||Thread per Message|| + ||SingleThreadExecution||
 *          実行するのは 1 Threadのみ。
 *          ボタンを押した回数だけ実行。表示は混在しない。
 *          
 *@subject 【解答３】ButtonAction.ActBalking() 
 *          ||Thread per Message|| + ||Balking||
 *          他Thread実行中は returnして制御を返す。
 *          応答性は常にボタン実行可能。
 *          処理は 1 Threadずつで、他Threadと完了まで次のThreadは実行されない。
 *          表示は他Threadと混在しない。
 *          
 *@subject 【解答４】ButtonAction.ActInterrupt()
 *          実行中のThreadがあれば、Interrupt()して、new Threadが実行する。
 *          応答性は常に確保される。
 *          
 *@author shika 
 *@date 2022-02-20 
*/
using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.ResponseGUI 
{ 
    class MainResponseGUI 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var form = new MyFormMT07();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(form);

            ////---- ボタンを押すThread ----
            //int thNum = 3;  //Thread数
            //Random random = new Random();
            //for (int i = 0; i < thNum; i++)
            //{
            //    new Thread(() =>
            //    {
            //        while (true)
            //        {
            //            Thread.Sleep(500 + random.Next(500));
            //            form.Btn_OnClick();
            //        }//while
            //    }).Start();
            //}//for

        }//Main() 
 
    }//class 
}


/*
//==== DoAction() / 初期の設定 ====
ButtonAction.DoAction()中は 次のボタン操作を受け付けず、
前回終了後に,次の処理を開始
act
.act
.act..........................................................done
done
done
act
.act
...act
.......................................................done
done
.done
act
..act
.act

/==== ActThreadPerMessage ====
//Thread per Messageパターンを利用して
//DoAction()の実行中も、ボタンが押されると new Threadで DoAction()を実行
act
.act
.act
........act
....act
..act
..................act
.......act
...act
..................act
......act
...act
...........................................act
.....act
.........act
..............................act
.................act
...........act
...........done
..........done
..done
........................act
...........done
..act
....act
........done
............done
................act
..........................done
....act
..act
..........done
..done

//==== ActSingle() ====
//実行するのは 1 Threadのみ、表示は混在しない。
act
....................done
act
....................done
act
....................done
act
....................done

//==== ActBalking() ====
act
.(Busy)(Busy)..(Busy).(Busy).(Busy)...
(Busy)(Busy).(Busy).(Busy)..(Busy)(Busy).
(Busy)...(Busy)(Busy).(Busy)..(Busy)(Busy).done
act
..(Busy).(Busy).(Busy).(Busy)..(Busy).
(Busy).(Busy).(Busy).(Busy).(Busy).
(Busy)..(Busy)..(Busy)(Busy)..

//==== ActInterrupt() ====
act
.... canceled
act
....... canceled
act
... canceled
act
..... canceled
act
........ canceled
*/