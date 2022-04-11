/** 
 *@title CsharpBegin / Utility / SeekPath.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content SeekPath
 *         static Main()を起動したクラスファイルの
 *         ディレクトリと ファイル名を取得するクラス
 *
 *@subject ◆StackTrace 〔CS 99〕
 *         System.Diagnostics.StackTrace
 *         System.Diagnostics.StackFrame
 *         new StackTrace(); メソッド呼出を記録する StackTraceを初期化
 *         new StackTrace(bool fNeedFileInfo); //trueにしないと機能しない
 *         int          trace.FrameCount //Stackにつまれたログの数
 *         StackFrame[] trace.GetFrames()//Stack内Frameの配列
 *         StackFrame trace.GetFrame(int index) //Stack内のログの１つ
 *           └ trace.FrameCount - 1             //static Main()は Stackの最後尾
 *         string       frame.GetFileName()
 *         
 *@author shika 
 *@date 2022-04-11 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Utility 
{ 
    class SeekPath 
    {
        public string SeekFileFull()
        {
            StackTrace trace = new StackTrace(true);
            StackFrame frame = trace.GetFrame(trace.FrameCount - 1); //static Main()          
            return frame.GetFileName();
        }//SeekFile() 

        public string SeekDirectory()
        {
            string thisFileName = SeekFileFull();
            string dir = thisFileName.Substring(
                0, thisFileName.LastIndexOf("\\"));

            return dir;
        }//SeekDirectory()

        public string SeekFileNameOnly()
        {
            string thisFileName = SeekFileFull();
            string fileName = thisFileName
                .Substring(thisFileName.LastIndexOf("\\") + 1); //先頭の「\」を除去

            return fileName;
        }//SeekFileNameOnly()

        //==== Test Main() ====
        //static void Main(string[] args)
        ////public void Main(string[] args) 
        //{
        //    var here = new SeekMainPath();

        //    //==== Test SeekFile(), SeekDirectory() ====
        //    string thisFileName = here.SeekFileFull();
        //    string dir = here.SeekDirectory();
        //    string fileName = here.SeekFileNameOnly();

        //    Console.WriteLine($"thisFileName: {thisFileName}");
        //    Console.WriteLine($"dir: {dir}");
        //    Console.WriteLine($"fileName: {fileName}");
        //}//Main() 
    }//class 
}

/*
thisFileName: 
     C:\Users\xxxxx\source\repos\CsharpBegin\CsharpBegin\Utility\SeekMainPath.cs 
dir: C:\Users\xxxxx\source\repos\CsharpBegin\CsharpBegin\Utility
fileName: SeekMainPath.cs
 */