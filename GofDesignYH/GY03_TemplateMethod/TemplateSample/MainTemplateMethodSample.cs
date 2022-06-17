/** 
*@title CsharpBegin / GofDesignYH / GY03_TemplateMethod / TemplateSample / MainTemplateSample.cs 
*@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
*@reference GY 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
*@content 第３章 TemplateMethod / p32 / List 3-1 ～ 3-4
*         || TemplateMethod ||
*         ・Abstract: 抽象クラスで設計図を定義
*            abstractメソッドで継承すべきメソッドを規定
*            TemplateMethodで 各メソッドの呼出方法を規定 
*            TemplateMethodは overrideさせるべきではない。
*         ・Concrete: サブクラスで具体的なメソッドの処理内容を定義
*         
*         ・「サブクラスの責任」subclass responsibility
*            サブクラスには基底クラスで宣言されているメソッドを overrideする責任がある。
*         ・「設計の責任」どのレベルの処理を共通化しておくかは設計者に任されている。
*         
*         ・ロジックの共通化: アルゴリズムが Abstractに一元化されているので、
*           各Concreteクラスにアルゴリズムを記述する必要がなくなる
*           => 変更時に１か所だけ修正すれば済む。(保守性)
*         ・メソッドの呼出は TemplateMethodである Display()で記述。
*           各Concreteクラスのメソッド処理の記述は呼出される経緯を理解しておく必要がある。
*         ・Abstractによって各Concreteクラスを同一視
*           [Java] instanceof演算子 / [C#] is演算子で判定せずとも実行時に振り分けられる。
*         ・LSP (= The Liskov Substitution Principle リスコフ置換法則) by バーバラ・リスコフ:
*           基底クラスの変数に、どの派生クラスのインスタンスを代入しても、
*           正しく動作し、コードの妥当性は損なわれない。〔JG5, DJ102, CS64〕
*           
*         ・|| TemplateMethod || 継承を利用
*         ・|| Strategy ||       委譲を利用
*/
#region Class Chart 〔TemplateSample〕
/*
*@class MainTemplateSample
*       // 
*       ◆Main()
*         new CharDisplayConcrete()
*         new StringDisplayConcrete()
*         AbsDisplayTemplate.Display()
*         
*@class AbsDisplayTemplate
*       + abstract void Open(), Show(), Close()
*       + void Display()  // <- Template Method 
*       
*@class CharDisplayConcrete() : AbsDisplayTemplate
*       / - char c /
*       + CharDisplayConcrete(char)
*       + override void Open(), Show(), Close()
*
*@class StringDisplayConcrete() : AbsDisplayTemplate
*       / - string str
*         - const int width /
*       + StringDisplayConcrete(string)
*       - BuildWidth(string) 
*       + override void Open(), Show(), Close()
*       - ShowLine()
*/
#endregion
/* 
 *@subject System.Grlbalization.StringInfoクラス 〔CS17〕機能しない
 *         ・サロゲートペア: Unicode 2byte文字で表現できる 65536文字を越える 4byte文字
 *         ・String.Lengthは 4byte文字も ２byte文字としてカウント
 *         ・new StringInfo(string).LengthInTextElements 4byte文字を 1文字としてカウント
 *         =>〔CsharpBegin　/ SampleCode / StringSample.cs〕
 *         
 *@subject 半角・全角で widthを変更する
 *         ・Char.IsSurrogate(c): 機能しない 
 *         ・'\u007E'は「~」の Unicodeで半角の最後？より大きい場合 ２文字とす。
 *              if ((int) c > '\u007E')
 *
 *@NOTE【Error】「デバッグ機能付き実行」で内部的エラーとのこと
 *      ・実行結果が Consoleに ちゃんと反映しない。
 *      ・原因となっているのは DynamicJson.cs辺りと思われる
 *      ・関連クラスを削除すれば解決するかもしれないが、
 *        SampleCode, package.configなどにも影響が及ぶため、そのまま放置。
 *      ・ブレイクポイントを設定した Debugは可能。
 *      
 *      => 「▲開始」[F5] ではなく、「△デバッグなしで実行」[Shift + F5]で
 *          実行すれば解決。
 *          
 *@author shika 
 *@date 2022-06-16 
 */
using System;

namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod.TemplateSample
{
    class MainTemplateMethodSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            AbsDisplayTemplate d1
                = new CharDisplayConcrete('A');
            AbsDisplayTemplate d2
                = new StringDisplayConcrete("Hello World");
            AbsDisplayTemplate d3
                = new StringDisplayConcrete("こんにちは");

            d1.Display();
            d2.Display();
            d3.Display();

            Console.WriteLine("Main() END");
        }//Main() 
    }//class 
}

/*
//---- width: str.Length ----
<< AAAAA >>
+-------------+
| Hello World |
| Hello World |
| Hello World |
| Hello World |
| Hello World |
+-------------+
+-------+
| こんにちは |
| こんにちは |
| こんにちは |
| こんにちは |
| こんにちは |
+-------+
Main() END

//---- width: 半角'~'以上は 2文字 ----
<< AAAAA >>
+-------------+
| Hello World |
| Hello World |
| Hello World |
| Hello World |
| Hello World |
+-------------+
+------------+
| こんにちは |
| こんにちは |
| こんにちは |
| こんにちは |
| こんにちは |
+------------+
Main() END
 */