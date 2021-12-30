/** 
 *@title CsharpBegin / MultiThread / MTCS04_Balking / InitializeSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第４章 Balking / p149 / List 4-5
 *         Balking Pattern Example: The class express Initialized or not.
 *         
 *         latch: (= ラッチ, 掛け金) たった一度だけ状態が変化する変数のこと。
 *         latch: a variable which can change the value in ONLY one times.
 *         
 *@subject Guard Conditionの判定: 
 *             一度しか変化しないので、if文を用いる。
 *         To judge Guard Condition:
 *             It shuold use 'if()', because of ONLY one change.
 *         
 *         ||GuardedSuspension||  while(!condition) { Thread.SpinWait(); }
 *         ||Balking||            if(!condition)    { return; }
 *
 *@subject 通常、Flagには、volatileを付与するが、ここでは不要。
 *         Usually, the Flag should be with 'volatile'.
 *         But in this case, it's not required.
 *
 *@subject Flag判定と Flag操作は [Java] synchronized / [C#] lock()で囲う。
 *         It should be lapped with '[Java] synchronized / [C#] lock()'
 *         on judging and changing the Flag.
 *         
 *@class InitializeSample
 *@author shika 
 *@date 2021-12-30 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS04_Balking 
{ 
    class InitializeSample 
    {
        private bool initialized = false;

        public void init()
        {
            lock (this)
            {
                if (initialized)
                {
                    return;
                }

                DoInit();
                initialized = true;
            }
        }//init()

        private void DoInit()
        {
            //initialize operation
        }//DoInit()

    }//class 
} 
