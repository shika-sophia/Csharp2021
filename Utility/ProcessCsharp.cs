/** 
 *@title CsharpBegin / Utility / ProcessCsharp.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content Process.Start()を用いて、C#を実行。
 *         「.cs」ソースファイルの位置ではなく、
 *         「.exe」ファイルのいちに >cd する必要がある。
 *          @"C:\Users\sophia\source\repos\CsharpBegin\
 *          CsharpBegin\bin\Debug\CsharpBegin.exe";
 * 
 *          CsharpBegin内から static Main()で、これを実行すると、
 *          再帰呼出となり、StackOverflowErrorとなりそう。
 *          つまり、
 *          static Main() -> cmd CsharpBegin.exe -> static Main() -> (loop forever)
 *          このクラス意味ないじゃん。
 *          
 *          ソースコードに cdして、クラス指定のコンパイルをすると、
 *          生み出される「.exe」は クラス名.exe、これを実行すればいい。
 *          ただし、static Main()を含んでいないと、コンパイルできない。
 *          
 *          psInfo.WorkingDirectory = dir; //cd dirと同じ
 *          psInfo.Argumens ではコマンド入力できない様子。
 *          
 *@author shika 
 *@date 2021-11-22 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Utility 
{ 
    class ProcessCsharp 
    { 
        public void CmdExe(string fileName)
        {
            string dir = Path.GetDirectoryName(fileName);
            string clazzName = Path.GetFileName(fileName);
        
            ProcessStartInfo psInfo = new ProcessStartInfo(
                "cmd.exe");
            psInfo.WorkingDirectory = dir;
            psInfo.Arguments = $"csc {clazzName}.cs";
            Process.Start(psInfo);
        }//CmdExe()
         
        //static void Main()
        public void Main()
        {
            var here = new ProcessCsharp();
            string fileName = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Utility\ProcessCsharp.cs";
            here.CmdExe(fileName);
        }
    }//class
} 

