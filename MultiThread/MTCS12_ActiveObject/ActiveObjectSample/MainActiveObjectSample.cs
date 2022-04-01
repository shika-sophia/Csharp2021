/** 
 *@title CsharpBegin / MultiThread / MTCS12_ActiveObject / ActiveObjectSample / MainActiveObjectSample.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第12章 Active Object / サンプル１ / p392 / List 12-1 ～ 12-15
 *@subject || Active Object ||
 *           ・多数のオブジェクトが強調して、１つの ActiveObjectを構成。
 *           ・非同期的にメソッド実行 = 非同期メッセージの送信
 *           ・メソッド呼出がオブジェクトになっているので分散処理が可能
 *               => ネットワーク経由で呼出/実行の分離が可能
 *           ・自由な実行スケジュール調整が可能。依頼順と実行順の調整など
 *           ・一方向の呼出だけでなく、複数のActiveObject間で双方向通信にすることも可
 *
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
 *         ＊Proxy 代理人 〔concurrent = 複数Threadから呼ばれてもよい〕
 *         ・Clientによるメソッドの呼出を MethodRequestオブジェクトに変換
 *         ・Clientは、変換された MethodRequestを Scheduleに渡す
 *         
 *         ＊Schedule 
 *         ・|| WorkerThread || 
 *             ScheduleThreadは実行を行うだけのThread
 *         ・ClientThread:   Proxyから渡された MethodRequestを ActiveQueueに渡す。
 *         ・ScheduleThread: ActiveQueueから、MethodRequestを取り出して実行。
 *         ・実行のスケジュール処理を実装するならここに記述。
 *         
 *         ＊MethodRequest
 *         ・Clientからのメソッド呼出を オブジェクト化したもの
 *         ・仮の戻り値を書き込む Future, リクエストを実行する Servantをクラス内に集約
 *         
 *         ＊ConcreteMethodRequest 具体的なリクエスト = MakeStringRequest, DisplayStringRequest
 *         ・MethodRequestを具体的なメソッドに対応させたオブジェクト
 *         ・各クラスのフィールドは、対応するメソッドの引数と同じ
 *         
 *         ＊Servant 召使い = Server 給仕 
 *         〔sequential = 単一Threadのみ実行可〕=> ScheduleThreadからしか呼ばれない
 *         ・実際にリクエストを処理する役
 *         ・ScheduleThreadによって、AciveQueueから、MethodRequestを取り出して実行。
 *         ・AbsActiveObjectによって Proxy, Servantを同一視
 *         ・Proxyが MethodRequestにオブジェクト化したものを、Servantが処理。
 *         
 *         ＊ActiveQueue 活性化キュー
 *         ・MethodRequestを保持するクラス
 *         ・|| Producer-Consumer || invoke(メソッド呼出)と execute(メソッド実行)の分離
 *             ClientThread:   PutRequest() -- invoke
 *             ScheduleThread: TakeRequest()-- execute
 *         
 *         ＊VirtualResult 仮想的な結果 = AbsReaultMT12<T>
 *         ・|| Future ||
 *         ・VirturalResult, RealResultで Futureパターン
 *         ・AbsReaultMT12で両者を同一視
 *         
 *         ＊RealReasult = RealReault<T>
 *         
 *         ＊Future 先物 = FutureReault<T>
 *         ・|| GuardedSuspension ||
 *           RealResultがまだ生成されてない場合は条件式によって待機
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
 *@class AbsActiveObjectMT12  //各Threadが利用するメソッド群APIを定義
 *         └ ProxyMT12 : AbsActiveObjectMT12  
 *         └ ServerMT12 : AbsActiveObjectMT12
 *           
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
 *@date 2022-03-27 ～　03-31
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
        //static void Main(string[] args) 
        public void Main(string[] args) 
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