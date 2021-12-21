/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / BreakImmutable / MainFieldMutable.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content / p109, p483 / 練習問題 2-4
 *         ■ Immutable ３要件
 *           ＊class 継承不可
 *           ＊private readonly フィールド
 *           ＊setterが存在しない
 *           
 *         ■ Immutabilityを壊す原因
 *         FieldMutableクラスは Immutable３要件は満たしているが、
 *         mutableなフィールドを 外部クラスに漏らすと、改変される可能性がある。
 *         
 *         buildは readonlyを宣言しているが、
 *         StringBuilderオブジェクトは 元のまま変更されておらず、
 *         StringBuolderオブジェクトの内部フィールドが変更している。
 *         
 *         string        string.Replace()        stringは不変オブジェクト immutable
 *         StringBuilder stringBuilder.Replace() StringBuilderは可変オブジェクト mutable
 *         
 *@class MainFieldMutable / ◆Main() new FieldMutable()
 *@class FieldMutable
 *       / - readonly StringBuilder bulid /
 *       + StringBuilder GetBuilder()
 *       + string ToString()
 *         
 *@author shika 
 *@date 2021-12-21 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.BreakImmutable
{
    class MainFieldMutable
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var bm = new FieldMutable("Alice", "Alaska");
            Console.WriteLine(bm);

            //フィールドの取得、改変
            StringBuilder build = bm.GetBuilder();
            build.Replace("Alice", "Bobby");
            Console.WriteLine(bm);
        }//Main()
    }//class

    sealed class FieldMutable
    {
        private readonly StringBuilder build;

        public FieldMutable(string name, string address)
        {
            this.build = new StringBuilder(
                $"Info [ Name: {name} / Address: {address} ]");
        }

        public StringBuilder GetBuilder()
        {
            return build;
        }

        public override string ToString()
        {
            return build.ToString();
        }
    }//class
}

/*
// [NG] immutableなはずが、Nameが変更してしまった。
Info [ Name: Alice / Address: Alaska ]
Info [ Name: Bobby / Address: Alaska ]
 */
