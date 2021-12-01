/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap11.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第11章 MultiThread, Attribute, Reflection, dynamic, event
 *         / p537, p565, p572 / 
 *@subject 練習問題 11-1, 11-2,  
 *@subject 章末問題 １, ２, ３, ４
 * 
 *@author shika  
 *@date 2021-12-02  
*/
/*==== Appendix ====  
 *@date: 2021-12-02 (木)  
 *@time: 07:06 ～ 07:23 (16分)  
 *@rate: 75.00％ (○ 9 問 / 全 12 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-12-02 (木) 
 *@time: 07:52 ～ 08:16 (24分) 
 *@rate: 57.69％ (○ 15 問 / 全 26 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap11  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}  
/*  
2021-12-02 (木) 
==== Exercise Result ====  
◆〔1〕第11章 MultiThread, Attribute, dynamic, event/ 練習問題 11-1  
○ (1) lockの役割:  
*     複数スレッドによってアクセスされるとデータレースを起こす可能性がある変数を  
○ (2) オブジェクトを一時的に占有させることでデータレースを防ぐ役割。  
○ (3) フィールド/プロパティなどクラスの状態に関わる変数を 
*     複数スレッドからのアクセスを守る働きをする。  
× (4) Task Main() -> 引数なし？  
    => ○: 引数関係なし  
× (5) new WebClient() -> 引数指定すべき  
    => ○: 引数なしもOK  
○ (6) async 修飾子は メソッド宣言時に付す  
    => 【解答】以下の誤りを指摘する 
*       非同期メソッドには async修飾子が必要 
*       キーワードは　await 
*       resultに返されるのは string 
*       result.Resultではなく、resultでOK 
 
◆〔2〕11-2  
○ (1) [Obsolete("Old Version")]  
    => 本文で確認後の回答 
○ (2) public void Method(){ }  
 
○ (3) dynamic: コンパイル時に型が決まらず、実行時に型が決まる。 
    型が適しているかもコンパイルでは検出できずに、実行時の Runtime例外となる。  
○ (4) var: 初期化子による型推論で型を決定。コンパイル時に型が決定する。  
○ (5) object: 全てのクラスのrootクラス。  
× (6) object[]には、どの型も代入かのうだが、取り出し時にキャストが必要。 
    *  型の整合性は実行時に例外。型安全かどうか実行時までわからない。  
    => ○: 型はコンパイル時に固定される。 
    *  object型の変数からは object型のメンバーしか呼び出せない。 
*/  
/*==== Appendix ====  
 *@date: 2021-12-02 (木)  
 *@time: 07:06 ～ 07:23 (16分)  
 *@rate: 75.00％ (○ 9 問 / 全 12 問)  
*/  
/* 
2021-12-02 (木)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) × 一度使用した Threadは ThreadPoolに待機させて、再利用時に利用するほうが 
○ (2) オーバーヘッド( = 処理負荷)が軽減される。 
○ (3) × MainThreadを待機させるのは同期処理の説明。 
○ (4) 非同期はメソッド呼出と実行が別時点で行われる。 
○ (5) ○ 属性の適用できる要素は決まってる。 
○ (6) × dynamicは存在しないメンバーを呼び出せない 
○ (7) DynamicObjectは、存在しないとき Listに登録してそれを呼び出している。 
× (8) × イベント登録には event修飾子 => ○: 「+=」を利用 

◆〔2〕２ 
× (1) Task => ○: Task<long> 
○ (2) IsCompeted / p533 
○ (3) Wait 
○ (4) Result / p533 
○ (5) async 
○ (6) await 
○ (7) Run 

◆〔3〕３ 
× (1) 正しい varは Type<string> => ○: var t = typeof(string); 
× (2) ? => ○: イベントハンドラーを削除するのは「-=」 
× (3) ? => ○: 正しい 
○ (4) DownloadTaskAsync()の戻り値は string 
× (5) ○ => ○: Inherit = true 

○ (6) ４． 
× (7) event => ○: event MyEventHandler 
× (8) 2 ? => ○: EvenEvent(i) 
× (9) 3 ? => ○: OddEvent(i) 
× (10) .MyEventHandler = => ○: 「+=」 
× (11) 5 19 => ○: 20 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-02 (木) 
 *@time: 07:52 ～ 08:16 (24分) 
 *@rate: 57.69％ (○ 15 問 / 全 26 問) 
*/ 
