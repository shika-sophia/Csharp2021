/**    
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap02.cs    
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017    
 *@content 第２章 C#の基本 / 練習問題 2-1, 2-2, 2-3, 2-4, 章末問題
 *    
 *@author shika    
 *@date 2021-10-24    
*/    
/*==== Appendix ====   
 *@date: 2021-10-24(日)   
 *@time: 15:08 ～ 15:15 (7分)   
 *@rate: 100.00％ (○ 6 問 / 全 6 問)   
*/   
/*==== Appendix ====  
 *@date: 2021-10-25 (月)  
 *@time: 10:43 ～ 10:56 (13分)  
 *@rate: 73.33％ (○ 11 問 / 全 15 問)  
*/  
/*==== Appendix ==== 
 *@date: 2021-10-25 (月) 
 *@time: 11:04 ～ 11:17 (14分) 
 *@rate: 76.19％ (○ 16 問 / 全 21 問) 
*/ 
using System;    
using System.Collections.Generic;    
using System.Linq;    
using System.Text;    
using System.Threading.Tasks;    
    
namespace CsharpBegin.Exercise.SelfLearnCS    
{    
    class SelfLearnChap02    
    {    
        //static void Main(string[] args)    
        public void Main(string[] args)    
        {   
            new CsharpBegin.Exercise.ExerciseEditor("");    
        }//Main()     
    }//class    
}
/*   
2021-10-24 (日)  
==== Exercise Result ====   
◆〔1〕第２章 練習問題 2-1   
○ (1) 1data -> 識別子の先頭に数字不可   
○ (2) Hoge -> 正しい   
○ (3) 整数の箱 -> Unicode文字は指定可能だが、可読性に欠けるので、慣例的に 英数字で指定   
○ (4) for -> 識別子に言語仕様の予約語は不可   
○ (5) @if -> 逐語的識別子 verbatim identifierで正しい   
○ (6) data-1 -> 記号は「_」のみ？   
    => 「-」は演算子。識別子に演算子は不可。  
*/
/*==== Appendix ====   
 *@date: 2021-10-24(日)   
 *@time: 15:08 ～ 15:15 (7分)   
 *@rate: 100.00％ (○ 6 問 / 全 6 問)   
*/
/*  
2021-10-25 (月) 
==== Exercise Result ====  
◆〔1〕2-2  
× (1) 整数型 符号あり: byte, short, int, long => ○: sbyte  
× (2) 整数型 符号なし: sbyte, ushort, uint, ulong, char 
        => ○: byte  
× (3) 小数型: frout, double => ○: float, decimal  
× (4) その他: decimal => ○: bool, char, string, object  
○ (5) 値型: 値そのものをメモリに格納  
○ (6) 参照型: 参照先のアドレスを格納  
 
◆〔2〕2-3  
○ (1) 16進数: 0x1A  
○ (2) 数値セパレータ: 1_000  
○ (3) 改行: \n  
○ (4) 指数: 1.24e5  
○ (5) 文字リテラル: 'A'  
 
◆〔3〕2-4  
○ (1) long m = 10; int i = m; long型のリテラルを intに代入不可  
○ (2) long m = 10L; int i =(int) m;に修正  
○ (3) "15" -> 15: int.Parse("15");  
 
◆〔4〕章末問題  
○ (1) 0  
*/
/*==== Appendix ====  
 *@date: 2021-10-25 (月)  
 *@time: 10:43 ～ 10:56 (13分)  
 *@rate: 73.33％ (○ 11 問 / 全 15 問)  
*/
/* 
2021-10-25 (月)
==== Exercise Result ==== 
◆〔1〕章末問題１ 
○ (1) import -> using 
○ (2) 文字列 -> "" 
○ (3) Console.WriteLine(data) -> ; 

◆〔2〕２ 
○ (1) 完全修飾名 
○ (2) 単純名 
○ (3) using 
○ (4) 名前の解決 

◆〔3〕３ 
× (1) readonly, => ○: const 
        => readonly: フィールドのみ
× (2) 0.1d => ○: 0.9 
○ (3) $ 
○ (4) {sum} 

◆〔4〕４ 
○ (1) ×小数は符号の区別なし 
○ (2) ×文字列は「"」 
○ (3) ×short型のsuffixは存在しない
        => short範囲内の int型を short型に暗黙的変換して作る。
× (4) ○暗黙的変換は型安全が保証され、桁あうふれは起こさない
        => ○: int -> floatは桁落ちの可能性がある 
○ (5) ×staticメンバーへのアクセスはインスタンス不要 

◆〔5〕５ 
○ (1) double value = 10d; 
○ (2) Console.WriteLine($"{name}さん"); 
○ (3) int? i = null; 
        => Nullable<int> i = null; も可
× (4) int[][] data = new int[5][4]; 
        => ○: int[,] data = new int[5,4]; 
× (5) int[][] data = new[][]{ {2, 3, 5}, {1, 2}, {10,11,12,13} };
        => ○: int[][] jagAry = new [3][];
              jagAry[0] = new[] {2, 3, 5};
              jagAry[1] = new[] {1, 2,};
              jagAry[2] = new[] {10, 11. 12, 13};
*/
/*==== Appendix ==== 
 *@date: 2021-10-25 (月) 
 *@time: 11:04 ～ 11:17 (14分) 
 *@rate: 76.19％ (○ 16 問 / 全 21 問) 
*/
