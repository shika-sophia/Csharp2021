/** 
 *@title CsharpBegin / GofDesignYH / GY03_TemplateMethod / ExerciseGY03.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第３章 TemplateMethod / p44, p384
 *@subject 練習問題 3-1, 3-2, 3-3, 3-4, 
 * 
 *@author shika 
 *@date 2022-06-17
*/ 
/*==== Appendix ==== 
 *@date: 2022-06-17 (金) 
 *@time: 16:32 ～ 16:44 (12分) 
 *@rate: 77.78％ (○ 7 問 / 全 9 問) 
*/ 
namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod 
{ 
    class ExerciseGY03 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    } 
} 
/* 
2022-06-17 (金)
==== Exercise Result ==== 
◆〔1〕第３章 TemplateMethod / 練習問題 3-1 
○ (1) java.io.InputStreamのサブクラスで実装を要請されているメソッドは何か: 
× (2) close() => ○: read() 

◆〔2〕3-2 
○ (1) [Java] public final void display() 
○ (2) finalの意味: サブクラスでの override不可 
○ (3) C#ではデフォルトで final設定。
      overrideを想定しているメソッドは abstract / virtualを付加 

◆〔3〕3-3 
○ (1) 他パッケージからアクセス不可にするには, 
× (2) アクセス修飾子を(無印): package privateにする 
  => ○: protected: 継承関係にあるものからのみ 

◆〔4〕3-4 
○ (1) AbsDisplayTemplateに インターフェイス不可の理由: 
○ (2) Diaplay()が abstractではなく、一般メソッドだから。
      インターフェイスは全てのメソッドを abstractで構成する。
      [C#]でも同様。[Java 8-] static, defaultメソッド可 
*/ 
/*==== Appendix ==== 
 *@date: 2022-06-17 (金) 
 *@time: 16:32 ～ 16:44 (12分) 
 *@rate: 77.78％ (○ 7 問 / 全 9 問) 
*/ 
