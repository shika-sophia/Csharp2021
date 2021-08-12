/**
 * @title CsharpBegin / SampleCode / GotoSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p203 /  5-49
 *          BigIntegerクラス 階乗の表示
 * @prepare ◆アセンブリの追加 System.Numerics.dll
 *          [VS] ソリューションエクスプローラ -> プロジェクト右クリック
 *          -> [追加] -> [参照]
 *          -> 参照マネージャーダイアログが開く
 *          -> 左ペイン -> [アセンブリ] -> [フレームワーク]
 *          -> [System.Numerics] -> チェック -> [OK]
 *          
 * @author shika
 * @date 2021-08-12
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class BigIntegerSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //---- long / BigInteger 切替 ----
            //long result = 1;
            BigInteger result = 1;

            //1～25の階乗を計算し出力
            for(var i = 1; i < 26; i++)
            {
                result *= i;
                Console.WriteLine(result);
            }
        }//Main()
    }//class
}

/*
//---- long ----
1
2
6
24
120
720
5040
40320
362880
3628800
39916800
479001600
6227020800
87178291200
1307674368000
20922789888000
355687428096000
6402373705728000
121645100408832000
2432902008176640000
-4249290049419214848
-1250660718674968576
8128291617894825984
-7835185981329244160
7034535277573963776

//---- BigInteger ----
1
2
6
24
120
720
5040
40320
362880
3628800
39916800
479001600
6227020800
87178291200
1307674368000
20922789888000
355687428096000
6402373705728000
121645100408832000
2432902008176640000
51090942171709440000
1124000727777607680000
25852016738884976640000
620448401733239439360000
15511210043330985984000000
 */