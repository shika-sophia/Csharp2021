/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT11_Ajax.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第11章 Ajax / p572, p580 | 章末 p616 / 解答 p646
 *@subject 練習問題 11-1, 11-2, 
 *@subject 章末問題 １, ２, ３, 
 *  
 *@author shika  
 *@date 2022-06-15  
*/
/*==== Appendix ====  
 *@date: 2022-06-15 (水)  
 *@time: 16:31 ～ 16:37 (6分)  
 *@rate: 80.00％ (○ 4 問 / 全 5 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-06-15 (水) 
 *@time: 17:51 ～ 18:04 (14分) 
 *@rate: 66.67％ (○ 12 問 / 全 18 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet
{
    class NT11_Ajax  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}  
/*  
2022-06-15 (水) 
==== Exercise Result ====  
◆〔1〕第11章 Ajax / 練習問題 11-1  
○ (1) Ajaxの利点: サーバー処理中も手元の操作が可能になる非同期通信。  
○ (2) 部分的更新が可能になり通信トラフィックの改善。  
 
  =>【解答】Ajaxとは、JavaScriptを利用してサーバー側と非同期通信を行い、 
     受け取った結果を DOM (= Document Object Model)などの技術を使って 
     ページに反映する仕組み。 
     Ajaxでは非同期にサーバーと通信を行うので、 
     サーバー処理中もブラウザでの操作は可能。 
     ページの部分的な更新により通信トラフィックを軽減。 
     従来型の同期通信にありがちだった画面のチラつきも最小限に抑えられる。 
 
◆〔2〕11-2  
○ (1) ASP.NET AJAX Extentions: 必須 ScriptManager  
○ (2) 注意点: 部分的更新に見えてもページ全体をViewStateしている。  
× (3) ？？  
 
  => 【ASP.NET AJAX Extentionsの注意点】 
      ・UpdatePanelには利用できないコントロールがある 
      ・送信される Requestはページ全体のもの。 
        (Requestデータが部分化されるわけではない) 
      ・UpdatePanelをネストした場合、UpdateMode=""によって 
        更新される範囲が変化する 
*/  
/*==== Appendix ====  
 *@date: 2022-06-15 (水)  
 *@time: 16:31 ～ 16:37 (6分)  
 *@rate: 80.00％ (○ 4 問 / 全 5 問)  
*/  
/* 
2022-06-15 (水)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) × クライアント側は JavaScriptに標準対応しているので、インストール不要 
○ (2)    サーバー側で jQueryなど JavaScript対応のライブラリをインストールしておく必要がある 
○ (3) × MasterPage: ScriptManager / ContentsPage: ScriptManagerProxy 
× (4) × UpdateProgressは 非同期通信中であることを表示するコントロール。進捗状況は GIFファイルで実装 
  => ×:ポストバック ○: 非同期ポストバック 
○ (5) × jQueryは Microsoft提供ではない 
○ (6) × HTMLから要素を指定するのは $(セレクタ)による 

◆〔2〕２ 
○ (1) ScriptManager 
○ (2) UpdatePanel 
○ (3) UpdateProgress 
○ (4) Timer 
× (5) ?? => ○: Triggers="" 
○ (6) DisplayAfter="" 
× (7) Duration="" => ○: Interval="" 

◆〔3〕３ 
× (1) $('a [target=_self') => ○: $('a [target="_self"]') 
× (2) $('input .validate') => ○: 空白不要 
○ (3) $('#id > option') 
× (4) $('#id span .keyws') => ○: $('#main spam.keywd') 
○ (5) $('bloacquote > img') 
*/ 
/*==== Appendix ==== 
 *@date: 2022-06-15 (水) 
 *@time: 17:51 ～ 18:04 (14分) 
 *@rate: 66.67％ (○ 12 問 / 全 18 問) 
*/ 
