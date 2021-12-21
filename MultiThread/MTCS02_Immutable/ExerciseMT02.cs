/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / ExerciseMT02.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第２章 Immutable / p107, p485 / 練習問題 2-1, 2-2, 2-3, 2-4, 2-5, 2-6, 
 * 
 *@author shika 
 *@date 2021-12-21 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-21 (火) 
 *@time: 10:03 ～ 10:24 (21分) 
 *@rate: 85.71％ (○ 12 問 / 全 14 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable 
{ 
    class ExerciseMT02 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
}
/* 
2021-12-21 (火)
==== Exercise Result ==== 
◆〔1〕第２章 Immutable / 練習問題 2-1 
○ (1) ○ Stringは immutable 
○ (2) × StringBufferは mutable 
○ (3) ○ finalは 二度代入されない。 
○ (4) × privateはそのクラスからのみ 
○ (5) × synchronizedはパフォーマンスを低下させるので 
○ (6) Immutableなら不要だし、DeadLockも考慮する必要がある。 

◆〔2〕2-2 
○ (1) String.replace()は 新たな Stringオブジェクトを生成する。 
○ (2) 元のStringは不変オブジェクトなので、変更されたわけではない。 

◆〔3〕2-3 
○ (1) 別紙 

◆〔4〕2-4 
○ (1) getInfo()は publicなので、これにより infoを得たクラスにおいて、
      infoのStringBufferを変更する可能性があるため 

◆〔5〕2-5 
○ (1) Pointクラスのフィールド x,yは publicなので、 
× (2) どのクラスからも改変できる。 
    => ○: finalになっていない点も指摘する必要がある。 
○ (3) Lineクラスの Pointフィールドは変化する可能性がある。 

◆〔6〕2-6 
× (1) ?? 
    => ○: Immutableクラスのコンストラクタ
    public ImmutablePerson(MutablePerson mutable){
        this.name = mutable.getName();
        this.address = mutable.getAddress();
    }
    * Mutableは常に変化し続けているクラスなので、
    * getName(), getAddress()の呼出と値の取得の間に
    * 他Threadが入り込む可能性がある。
    * ここをクリティカルセクション(= 排他制御したブロック)にする必要がある。
    * ロック取るべきオブジェクトは mutableのほう。

    public ImmutablePerson(MutablePerson mutable){
        synchronized(mutable){
            this.name = mutable.getName();
            this.address = mutable.getAddress();
        }
    }

*/
/*==== Appendix ==== 
 *@date: 2021-12-21 (火) 
 *@time: 10:03 ～ 10:24 (21分) 
 *@rate: 85.71％ (○ 12 問 / 全 14 問) 
*/
