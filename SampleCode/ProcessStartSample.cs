/**
 *@title CsharpBegin / SampleCode / ProcessStartSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@reference ◆外部アプリケーションを起動する、
 *             ファイルを関連付けられたソフトで開く
 *@url https://dobon.net/vb/dotnet/process/shell.html
 *
 *@reference ◆C#でProcessを使って別アプリを実行（起動）する方法
 *@url https://qiita.com/yasukotelin/items/605b9d4260a8c9ebcbeb
 *
 *@reference ◆[.net、Java連携]C#.netで.jarを実行するンジャー
 *@url https://qiita.com/hagii-x/items/a60d5df95b8e8fc5da10
 *
 *@content Process.Start()は コマンドプロンプトでファイルを実行する仕組み
 *         実行環境があらかじめインストールされている必要がある。
 *         (=コマンドプロンプトで >java を実行できる環境になっている)
 *         
 *  ◆System.Diagnostics.Process
 *  ＊static
 *  Process Process.Start(string exeFile);
 *  Process Process.Start(string exeFile, string args);
 *  Process Process.Start(ProcessStartInfo);
 *  
 *  ＊instance
 *  Process p = new Process();
 *  p.StartInfo.FileName = "notepad.exe";
 *  bool result = p.Start();
 *  
 *  ◆ProcessStartInfo psi
 *  string psi.FileName
 *  string psi.Arguments
 *  bool psi.UseShellExecute
 *  
 *  ◆VSをコマンドプロンプト実行
 *  >code ProcessStartSample.cs
 *  Process.Start("code");
 *  これだと Win32Exceptionが発生するので下記のようにする。
 *  
 *  var app = new ProcessStartInfo();
 *  app.FileName = "code";
 *  app.UseShellExecute = true;
 *  Process.Start(app);
 * 
 *  ◆C#で .jarファイルを起動
 *   .jarファイルは、C#(.net)の実行ファイルが生成されるDebug/Releaseフォルダに
 *   配置するとファイル指定が楽です。
 *   
 *  ＊コマンドプロンプトを表示して実行する場合
 *   Process.Start("java", "-jar (.jarファイル名orパス) (引数) (引数)…"))   
 *  ＊コマンドプロンプトを表示せずに実行する場合
 *   Process.Start("javaw", "-jar (.jarファイル名orパス) (引数) (引数)…")
 *   
 *@author shika 
 *@date 2021-10-15 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class ProcessStartSample
    {
        //static void Main(string[] args)
        public void MainDoc(string[] args)
        {
            //---- メモ帳を起動する ----
            Process process = Process.Start("notepad.exe");

            //---- コマンドライン引数を指定してメモ帳を起動する ----
            //Process process = Process.Start(
            //    "notepad.exe", @"""C:\test\1.txt""");

            //---- ProcessStartInfoオブジェクトを作成する ----
            //ProcessStartInfo psi = new ProcessStartInfo();            
            //psi.FileName = "notepad.exe";
            //psi.Arguments = @"""C:\test\1.txt""";
            //Process p = Process.Start(psi);

        }//Main()
    }//class
}

/*
◆Process.Start("notepad.exe");
=> メモ帳が起動する。

◆PowerShell (失敗)
[ソリューションエクスプローラ] -> フォルダ -> 左クリック
-> [ターミナルで開く] -> PS起動

PS C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\SampleCode
> code ProcessStartSample.cs
code : 用語 'code' は、コマンドレット、関数、スクリプト ファイル、または操作可能なプログ
ラムの名前として認識されません。名前が正しく記述されていることを確認し、パスが含まれてい
る場合はそのパスが正しいことを確認してから、再試行してください。
発生場所 行:1 文字:1

◆CommandPronpt (失敗)
C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\SampleCode>
code ProcessStartSample.cs
'code' は、内部コマンドまたは外部コマンド、
操作可能なプログラムまたはバッチ ファイルとして認識されていません。

【参考】
◆ConnectJar.cs
public static bool Excecute(string msg)
{
    bool result = false;
    Process jar = null;
    try
    {
        // .jarをプロセスとして起動
        using (jar = Process.Start("java", "-jar Sample.jar " + msg))
        {
            // 終了待ち
            jar.WaitForExit();
            // 結果取得(0:正常終了)
            if (jar.ExitCode == 0) result = true;
        }
    }
    catch (Exception e)
    {
        MessageBox.Show("例外発生\n" + e.Message);
    }
    return result;
}

◆Sample.java
public static void main(String[] args) {
    // TODO 自動生成されたメソッド・スタブ
    if (args.length <= 0) {
        System.out.println("出力メッセージなし");
    } else {
        System.out.println("出力メッセージ：" + args[0]);
    }
    // Enterキー入力待ち
    // 参考：https://stackoverflow.com/questions/26184409/java-console-prompt-for-enter-input-before-moving-on
    System.out.println("Press \"ENTER\" to exit...");
    Scanner scanner = new Scanner(System.in);
    scanner.nextLine();
}
 */