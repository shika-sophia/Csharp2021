/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT01_Introduction.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content 第１章 Introduction / p10, p15, p27, p27 / 
 *@subject 練習問題 1-1, 1-2, 1-3, 
 *@subject 章末問題 １, ２, ３, ４,
 *  
 *@author shika  
 *@date 2021-11-25  
*/
/*==== Appendix ====  
 *@date: 2021-11-25 (木)  
 *@time: 01:59 ～ 02:17 (18分)  
 *@rate: 75.00％ (○ 9 問 / 全 12 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-11-25 (木) 
 *@time: 02:36 ～ 02:52 (15分) 
 *@rate: 61.54％ (○ 8 問 / 全 13 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfAspNet  
{  
    class NT01_Introduction  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
} 
/*  
2021-11-25 (木) 
==== Exercise Result ====  
◆〔1〕第１章 Introduction / 練習問題 1-1  
○ (1) 動的なサイト: 固定ページを表示するだけの静的なサイトとの対比語。  
○ (2) ユーザーの入力値に応じて、データを加工して表示するページのこと。  
○ (3) クライアント側のスクリプトは事前に全てのコンテンツをロードしておく必要があり、 
      静的なページである。  
○ (4) 動的なページを作るためには、サーバーを経由しそこで処理をしたWebアプリにする必要がある。  
○ (5) 2. HTTP: HyperText Transfer Protocolの略  
○ (6) インターネット間の通信をするための文法規則 (=プロトコル)のこと。  
 
◆〔2〕1-2  
× (1) .NET Frameworkを構成するコンポーネント:  
    => ○: CLR: Common Language Runtime 共通言語実行プログラム 
          .NET Framework クラスライブラリ: 以下 
○ (2) ASP.NET, .NET Core, ADO.NET, .NET MVC  
× (3) プログラミング言語: C#, Visual Basic => ○: F#, C++も可  
 
◆〔3〕1-3  
× (1) VS上の DocumentView, DesignView  
    => ○: DocumentWindow, SourceView, DesignView  
○ (2) ServerControl: ASP.NETで定義され、 
    　サーバーへのアクセス、サーバー処理の出力を抽象化  
      <asp: >タグによって表し、 
○ (3) HTML出力を内部化して、GUI操作によって、 
      一連の処理ができるようにしたWebページ上の部品のこと。  
*/ 
/*==== Appendix ====  
 *@date: 2021-11-25 (木)  
 *@time: 01:59 ～ 02:17 (18分)  
 *@rate: 75.00％ (○ 9 問 / 全 12 問)  
*/ 
/* 
2021-11-25 (木)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
× (1) サーバーサイドの利点: ユーザー入力に応じた動的なページの作成が可能、初期ロードの軽減。 
=> ○: 解答【サーバーサイドの利点】
      ＊DB, FileSystemなど、サーバー側のリソースとの連携が可能。
      ＊個人情報などの機密情報を扱いやすい。
      ＊処理結果は最終的な出力である HTMLなので、トラフィックを抑えやすい。
      ＊クライアント環境に依存しにくい。

× (2) クライアント側は毎回通信を行わなくても、簡単なページ変化が可能。
        最初に全てのコンテンツをロードするため、初期パフォーマンスに劣る。 
=> ○: 上記の逆 
○ (3) Ajaxによる非同期通信で クライアント側も欠点を補うことができる。 

◆〔2〕２ 
○ (1) × -> VSがなくても可能だが、必要なクラスライブラリやWebサーバー、DBサーバーを揃えてくれるので、導入するほうが便利。 
○ (2) × -> SQL Serverでなくてもいいが、Microsoft社製どうし相性がよく、認証も自動化されるので導入するほうが便利。 
○ (3) × -> クラスライブラリも 
    => Application Frameworkは、.NET Framewokクラスライブラリの一部。
○ (4) × -> IIS 10.0は Windows10用の WebServer 

◆〔3〕３ 
○ (1) ManagedCode: .NET Frameworkでサポートしているクラスのこと。
      それ以外のクラスを UnmanagedCodeと呼ぶ。
      => Windows上で直接動作する UnmanagedCode

◆〔4〕４ 
× (1) CLR => ○: 基本クラスライブラリ 
○ (2) ADO.NET 
× (3) Application Library => ○: Application Framework 
× (4) WFP => ○: Windows Form (WPF) 
○ (5) ASP.NET 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-25 (木) 
 *@time: 02:36 ～ 02:52 (15分) 
 *@rate: 61.54％ (○ 8 問 / 全 13 問) 
*/ 
