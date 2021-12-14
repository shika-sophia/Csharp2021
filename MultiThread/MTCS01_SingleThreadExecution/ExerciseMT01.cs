/** 
 *@title CsharpBegin / Exercise / MultiThread / ExerciseMT01.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第１章 SingleThreadExecution / p78, p468
 *@subject 練習問題 1-1, 1-2, 1-3, 1-4, 1-5, 1-6, 1-7, 
 * 
 *@author shika 
 *@date 2021-12-14 
*/
/*==== Appendix ==== 
 *@date: 2021-12-14 (火) 
 *@time: 10:03 ～ 10:35 (32分) 
 *@rate: 88.89％ (○ 16 問 / 全 18 問) 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution
{ 
    class ExerciseMT01
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2021-12-14 (火)
==== Exercise Result ==== 
◆〔1〕第１章 SingleThreadExecution / 練習問題 1-1 
○ (1) in Gate class, between 'this.name = name;' and 'this.address = address;' 
○ (2) insert 'Thread.Sleep(100);' 

◆〔2〕1-2 
○ (1) 'private' field can not access from another classes. 
○ (2) if it change to 'protected' or 'public',  
○ (3) 'protected' can change field value in inherit class. 
○ (4) 'public' can change field value form any class. 
○ (5) To certain thread-safe in Gate lock, 
    can break in 'protected' or 'public' class. 

◆〔3〕1-3 
○ (1) see MainSafeGate【NOTE】 

◆〔4〕1-4 
○ (1) ○ final class 
○ (2) × it is true if following code don't have setVlue() method. 
○ (3) ○ synchronized 
○ (4) × same reason as (2) 
× (5) ○ moveReverse(int dy, int dx) { y += dy; x += dx }  
    => ○: It can not judge only this class. 
    Need see another class which use this class. 

◆〔5〕1-5 
○ (1) × these ++, -- can change count value to -1, 0, 1, 2,... 
    / it's not thread safe. 
○ (2) both ++, --, getCounter() need append 'synchronized'. or 
× (3) field count should change type to AtomicInteger 
    => ○: Need change to 'volatail count'. 

◆〔6〕1-6 
○ (1) How to avoid DeadRock: 
    The order of spoon and fork taking up, should be same. 
    => Another Answer:
    Pair class (spoon, fork) should be defined.

◆〔7〕1-7 
○ (1) (in another class) 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-14 (火) 
 *@time: 10:03 ～ 10:35 (32分) 
 *@rate: 88.89％ (○ 16 問 / 全 18 問) 
*/ 
