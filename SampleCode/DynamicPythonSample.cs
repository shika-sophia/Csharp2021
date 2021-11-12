/** 
 *@title CsharpBegin / SampleCode / DynamicPythonSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 11.3.2 dynamic 動的型付け / p554 / List 11-18, 11-19, 11-A
 *@subject ◆IronPython.Hosting.Pythonクラス
 *         ◆Microsoft.Scripting.Hosting.ScriptRuntimeクラス
 *           ScriptRuntime Python.CreateRuntime()
 *           ScriptScope   ScriptRuntime.UseFile(string path)
 *           Xxxx          ScriptScope.Xxxx() //.pyクラスのインスタンス
 *           
 *@library CsharpBegin/参照
 *           Microsoft.Dynamic
 *           IronPython
 *           IronPython.Modules
 *           IronPython.SQLite
 *           IronPython.Wpf
 *           
 *@prepare ◆IronPython インストール
 *          .NET Frameworkで動作する Pythonの実行環境
 *          DLR: Dynamic Language Runtimeも同時にインストールされる。
 *          
 *          [ソリューション] -> [プロジェクト 右クリック] -> [NuGet]
 *          -> [参照] -> [IronPython] -> 最新安定版　-> [インストール]
 *          
 *         ◆別解 NuGetからのインストール方法
 *         [ツール] -> [NuGet] -> [パッケージマネージャ コンソール]  or 
 *         [表示] -> [その他のウインドウ] -> [パッケージマネージャ コンソール]
 *         PM> Install-Package IronPython
 *         
 *         ◆「.py」の実行準備
 *         「.exe」ビルド済ファイルと同じフォルダ
 *         「C:\data\プロジェクト名\bin\Debug」にコピー(出力)する。
 *         [ソリューション] -> [プロジェクト 選択] -> [プロパティ ウインドウ]
 *         -> [出力ディレクトリにコピー] -> [常にコピー]
 *         
 *         これだと UseFile("Data/PythonSample.py")と相対パスで記述可。
 *         または下記コードのように「.py」の絶対パスを指定する。
 *         
 *@see Data/PythonSample.py
 *@author shika 
 *@date 2021-11-12 
*/
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class DynamicPythonSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            ScriptRuntime py = Python.CreateRuntime();
            dynamic script = py.UseFile(
                @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\PythonSample.py");
            dynamic instance = script.PythonSample();
            Console.WriteLine(instance.greet("Shika"));
        }//Main() 
    }//class
}

/*
PythonSample.greet(): execute
Hello, Shika

【参照】Data/PythonSample.py
class PythonSample:
  def greet(self, name):
    print "PythonSample.greet(): execute"
    return "Hello, " + name
 
 */