/** 
 *@title CsharpBegin / MultiThread / MTCS04_Balking / FileSaveBalking / MainFileSaveBalking.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content   CS 第５章 標準ライブラリ 5.4 File操作 / p189
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content   MT 第４章 Balking / p140 / List 4-1, 4-2, 4-3, 4-4
 *           ～ 必要なかったら、やめちゃおう ～
 *           
 *@subject ◆System.IO.StreamWriter
 *         using(var writer = new StreamWriter(string path)){ }
 *         void writer.WriteLine(string)
 *         void writer.Close()
 *         
 *@subject ◆ガード条件: dataFile内のコンテンツに変更がなければ
 *         => Fileセーブをキャンセルする。
 *         while(!changeFlag) { return; }
 *         data.DoSave();
 *         
 *@class MainFileSaveBalking
 *       / ◆Main()
 *       new DataMT04(string fileName, string content)
 *       new ChangeThreadMT04(string thName, DataMT04);
 *       new SaveThreadMT04(string thName, DataMT04);
 *       new Thread(ThreadStart)
 *         └ delegate void ThreadStart();
 *            └ XxxxThreadMT04().Run();
 *            
 *@class DataMT04
 *       / - readonly string fileName;
 *         - volatile bool changeFlag;
 *         - string content; /
 *       + DataMT04(string fileName, string content)
 *       + Change(string newContent)
 *       + CheckSave() { 
 *           using(var writer = new StreamWriter(string path))
 *           while(!changeFlag) { return; }
 *           data.DoSave();
 *         }
 *       - DoSave()
 *
 *@class ChangeThreadMT04 
 *       / - readonly string thName;
 *         - readonly DataMT04 data;
 *         - readonly Random random; /
 *       + void Run() { data.Change(); data.CheckSave(); }
 *       
 *@class SaveThreadMT04 
 *       / - readonly string thName;
 *         - readonly DataMT04 data; /
 *       + void Run() { data.CheckSave(); }
 *       
 *@author shika 
 *@date 2021-12-29 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS04_Balking.FileSaveBalking 
{ 
    class MainFileSaveBalking 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var data = new DataMT04("dataFileMT04.txt", "(Empty)");
            var change = new ChangeThreadMT04("ChangeThread", data);
            var save = new SaveThreadMT04("SaveThread", data);
            new Thread(change.Run).Start();
            new Thread(save.Run).Start();
        }//Main() 
    }//class 
}

/*
SaveThread: DoSave() content = (Empty)
ChangeThread: DoSave() content = No.0
ChangeThread: DoSave() content = No.1
SaveThread: DoSave() content = No.2
ChangeThread: DoSave() content = No.3
ChangeThread: DoSave() content = No.4
SaveThread: DoSave() content = No.5
SaveThread: DoSave() content = No.6
ChangeThread: DoSave() content = No.7
SaveThread: DoSave() content = No.8
SaveThread: DoSave() content = No.9
SaveThread: DoSave() content = No.10
ChangeThread: DoSave() content = No.11
SaveThread: DoSave() content = No.12
SaveThread: DoSave() content = No.13
ChangeThread: DoSave() content = No.14
SaveThread: DoSave() content = No.15
SaveThread: DoSave() content = No.16
ChangeThread: DoSave() content = No.17
ChangeThread: DoSave() content = No.18
ChangeThread: DoSave() content = No.19
SaveThread: DoSave() content = No.20

【考察】
番号の重複がないので、Balkingが機能していることが分かる。

〔【NOTE】
Because there was not the same number, the Balking did effectively.〕

◆dataMT04.txt
No.20

 */