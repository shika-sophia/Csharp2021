/** 
 *@title CsharpBegin / Application / ProcessMainExe.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content ProcessMainExe
 *         [VS] static Main()は１つのみなので、
 *         各クラスの public Main()から実行するプログラム
 * 
 *@reference ■ C#のコマンド実行するには
 *@url https://www.fenet.jp/dotnet/column/language/5722/
 *@see Reference / ProcessStart.txt 
    //Command Prompt呼出, コマンド入力, 実行
    new ProcessStartInfo("cmd.exe", string command)
        command: "/k dir" 
           「/k」は実行後にコンソールを閉じないようにする
           「/c」は実行後に消える？

    Process.Start(ProcessStartInfo)
     
    // ウィンドウを表示しない
    processStartInfo.CreateNoWindow = true;
    processStartInfo.UseShellExecute = false; 
 
     // 標準出力、標準エラー出力を取得できるようにする
    processStartInfo.RedirectStandardOutput = true;
    processStartInfo.RedirectStandardError = true; 
 
     // コマンド実行
    Process process = Process.Start(processStartInfo); 
 
     // 標準出力・標準エラー出力・終了コードを取得する
    string standardOutput = process.StandardOutput.ReadToEnd();
    string standardError = process.StandardError.ReadToEnd();
    int exitCode = process.ExitCode; 
 
     process.Close(); 
 
     // MessageBoxに標準出力を表示
    MessageBox.Show(standardOutput);

 *@author shika 
 *@date 2021-11-18 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
using System.Windows;

namespace CsharpBegin.Application 
{ 
    class ProcessMainExe 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            //コマンドプロンプト呼出
            string command = "/k csc /version";
            ProcessStartInfo psInfo = new ProcessStartInfo("cmd.exe", command);
            
            //// ウィンドウを表示しない
            psInfo.CreateNoWindow = true;
            //psInfo.UseShellExecute = false;

            // 標準出力、標準エラー出力を取得できるようにする
            //psInfo.RedirectStandardOutput = true;
            //psInfo.RedirectStandardError = true;
            
            //コマンド実行
            Process process = Process.Start(psInfo);

            //// 標準出力・標準エラー出力・終了コードを取得する
            //string standardOutput = process.StandardOutput.ReadToEnd();
            //string standardError = process.StandardError.ReadToEnd();
            //int exitCode = process.ExitCode;

            //process.Close();
            ////MessageBox.Show(standardOutput);
            //Console.WriteLine($"{standardOutput}");
        }//Main() 
    }//class 

}

/*
>csc /version
3.11.0-4.21403.6 (ae1fff34)
*/