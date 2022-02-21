/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / ResponseGUI  / MainWindowsFrame.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content GUIのButton応答性を速くする
 */
#region -> [C#] GUIプログラム (未完成)
/*
 *@subject [C#] GUIプログラム 〔VS2019〕
 *         ASP.NET Frameworkを利用すべきだが、
 *         [C#] System.Windows.Controls名前空間に Frameクラスが用意されている。
 *         
 *         ◆System.Windows.Controls.Frameクラス
 *         Buttonクラス
 *         //var frame = new Frame();
 *         //var button = new Button();
 *         //frame.Content = button;
 *         //System.InvalidOperationException:
 *         //呼び出しスレッドは、多数の UI コンポーネントが必要としているため、
 *         //STA である必要があります。
 *         
 *         //これを利用するには力不足。GUIのプログラムは別途、学習すべし。
 *         
 *         ここでは、Console表示を使って、GUIの応答性をあげる機能のみを実装
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
            Random random = new Random();
            var frame = new MyFrame();
            int thNum = 3;  //Thread数

            //ボタンを押すThread
            for(int i = 0; i < thNum; i++)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500 + random.Next(500));
                        frame.Btn_OnClick();
                    }//while
                }).Start();                        
            }//for

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