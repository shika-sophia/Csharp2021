/** 
 *@title CsharpBegin / MultiThread / MTCS12_ActiveObject / ActiveObjectSample / MainActiveObjectSample.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第12章 Active Object / サンプル１ / p392 / List 12-1 ～ 12-15
 *@subject || Active Object ||
 *         ＊Client 依頼者 = MakerThread, DisplayThread
 *         ・ActiveObjectのメソッドを呼出、処理を依頼。
 *         ・|| Future || 
 *             制御はすぐに戻り、実際の結果は後で受け取る。
 *             実際の結果ができるまで、仮の結果 futureを受け取る。
 *         
 *         ＊ActiveObject 能動的なオブジェクト = AbsActiveObject
 *         ・Clientに提供するメソッド群を定義。
 *         ・Proxy, Serverを同一視するための抽象クラス
 *         
 *         ＊Proxy 代理人
 *         ・Clientによるメソッドの呼出を MethodRequestオブジェクトに変換
 *         ・Clientは、変換された MethodRequestを Scheduleに渡す
 *         
 *         ＊Schedule 
 */
#region -> Class Summary
/*
 *@class MainActiveObjectSample
 *         //ActiveObject生成。
 *         //MakerThread, DisplayThreadの起動
 *@class MakerThreadMT12        
 *         //new MakeStringRequest -> scedule.Invoke() -> queue.PutRequest()
 *@class DisplayThreadMT12      
 *         //scedule.Invoke(new DisplayStringRequest) -> queue.PutRequest()
 *
 *@class ActiveObjectFactory  //各インスタンスを生成
 *@class ScheduleThreadMT12   //invokeと executeの分離
 *        //Invoke(){ queue.PutRequest() } 
 *        //Run() {queue.TakeRequest
 *                 Execute() }
 *@class ActiveQueueMT12      //AbsRequestを queueに格納
 *@class AbsActiveObjectMT12  
 *         └ ProxyMT12 : AbsActiveObjectMT12
 *         └ ServerMT12 : AbsActiveObjectMT12
 *@class AbsMethodRequest
 *         └ MakeStringRequest : AbsMethodRequest
 *         └ DisplayStringRequest : AbsMethodRequest
 *@class AbsResultMT12<T>
 *         └ FutureResult<T> : AbsResultMT12<T>
 *         └ RealResult<T> : AbsResultMT12<T>
 */
#endregion
/*
 *@author shika 
 *@date 2022-03-27 
*/
using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample 
{ 
    class MainActiveObjectSample 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            AbsActiveObjectMT12 activeObj = 
                ActiveObjectFactory.CreateActiveObject();

            var maker1 = new MakerThreadMT12("Alice", activeObj);
            var maker2 = new MakerThreadMT12("Bobby", activeObj);
            var display = new DisplayThreadMT12("Chris", activeObj);

            var thMaker1 = new Thread(maker1.Run);
            thMaker1.Name = maker1.GetName();
            thMaker1.Start();

            var thMaker2 = new Thread(maker2.Run);
            thMaker2.Name = maker2.GetName();
            thMaker2.Start();

            var thDisplay = new Thread(display.Run);
            thDisplay.Name = display.GetName();
            thDisplay.Start();

        }//Main() 
 
    }//class 
}

/*
Alice: value = A
Bobby: value = B
Alice: value = AA
DisplayString(): Chris: 1
Bobby: value = BB
DisplayString(): Chris: 2
DisplayString(): Chris: 3
Alice: value = AAA
Bobby: value = BBB
DisplayString(): Chris: 4
DisplayString(): Chris: 5
Alice: value = AAAA
DisplayString(): Chris: 6
Bobby: value = BBBB
DisplayString(): Chris: 7
DisplayString(): Chris: 8
DisplayString(): Chris: 9
Alice: value = AAAAA
DisplayString(): Chris: 10
DisplayString(): Chris: 11
Bobby: value = BBBBB
DisplayString(): Chris: 12
DisplayString(): Chris: 13
DisplayString(): Chris: 14
Alice: value = AAAAAA
DisplayString(): Chris: 15
DisplayString(): Chris: 16
DisplayString(): Chris: 17
Bobby: value = BBBBBB
DisplayString(): Chris: 18
DisplayString(): Chris: 19
DisplayString(): Chris: 20
Alice: value = AAAAAAA
DisplayString(): Chris: 21
DisplayString(): Chris: 22
DisplayString(): Chris: 23
DisplayString(): Chris: 24
  :
(CTRL + C)
 */