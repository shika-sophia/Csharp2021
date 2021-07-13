/**
 * @title CsharpBegin / Introduction / ConcatString.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第３章 演算子 / p80 / List 3-1, 3-2
 *          「+」演算子と StringBuilderの string結合処理速度の比較
 *          
 * @reference ◆C# 処理時間計測 Stopwatch 入門
 * @URL       http://s170199.ppp.asahi-net.or.jp/tech/cs/Stopwatch.html
 * @content System.Diagnostics.Stopwatchクラスで処理速度を計測
 * 
 * @author shika
 * @date 2021-07-13
 */


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intoroducion
{
    class ConcatString
    {
        private void Main(string[] args)
        //static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            //---- 「+」演算子 ----
            //var result = "";
            //for (int i = 0; i < 10000; i++)
            //{
            //    result += "いろは";
            //}

            //---- StringBuilder ----
            var bld = new StringBuilder(30000);
            for (int i = 0; i < 10000; i++)
            {
                bld.Append("いろは");
            }
            var result = bld.ToString();

            sw.Stop();
            TimeSpan span = sw.Elapsed;    //  計測した時間を span に代入
            Console.WriteLine(span.TotalMilliseconds);    // トータルミリ秒をコンソールに表示
        }//Main()
    }//class
}

/*
 * 実行結果
 * //---- 「+」演算子 ----
 * result += "いろは";
 * 21.1226 mili-second
 * 
 * //---- StringBuilder ----
 * bld.Append("いろは");
 * 0.27 mili-second
 *
 *【考察】
 * VSプロジェクト内には１つしか Main()を持てず、エラーとなるので、
 * 実行させる Main()以外は staticを消去し privateとすると解決。
 */