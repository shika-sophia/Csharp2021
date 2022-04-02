/** 
 *@title CsharpBegin / MultiThread / MTCS12_ActiveObject / AppendMethod / MainAppendMethod.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第12章 Active Object / 練習問題 12-2 / p434, p595 /
 *@subject ◆メソッドの追加
 *         ActiveObjectにメソッドを追加する
 *         【手順】p419
 *           ・AbsActiveObject: abstractメソッドを追加
 *           ・MethodRequest:   サブクラスとしてそのメソッド呼出のクラスを定義
 *           ・Proxy:   メソッド追加
 *                      メソッドの戻り値が必要な場合は || Future ||
 *           ・Servant: メソッドを追加し、実際の処理を定義
 *        ScheduleThreadを修正する必要はない。
 *        Scheduleは ActiveObjectの情報は一切なく request.Execute()を呼び出しているだけ
 *
 *@subject ◆[C#] BigInteger (System.Numerics.BigInteger) 〔CS 38〕
 *         ・long / ulong を越える整数値を扱うクラス
 *         ・算術演算子, 代入演算子, 関係演算子, ビット演算子が用意されている。
 *         ・BigInteger big = 1; //リテラルをそのまま代入可
 *         ・[VS]デフォルトでは利用不可
 *            => アセンブリ System.Numerics.dllをインポート
 *          
 *          BigInteger new BigInteger(T)
 *          BigInteger static BigInteger.Parse(string)
 *          string     big.ToString()
 *         
 *@class MainAppendMethod
 *@class AbsActiveObject{
 *         + abstract AbsResultMT12<string> AddString(string x, string y); }
 *@class AddStringRequest : AbsMethodRequest
 *@class ProxyMT12 : AbsActiveObject
 *         + override AbsResultMT12<string> AddString(string x, string y)
 *@class ServerMT12 : AbsActiveObject
 *         + override AbsResultMT12<string> AddString(string x, string y)
 * 
 *@author shika 
 *@date 2022-04-02 
*/
using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.AppendMethod 
{ 
    class MainAppendMethod 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            var activeObject = ActiveObjectFactory.CreateActiveObject();
            var add = new AddThreadMT12("Diana", activeObject);
            var thAdd = new Thread(add.Run);
            thAdd.Name = add.GetName();
            thAdd.Start();
        }//Main() 
    }//class 
}

/*
Diana: 1 + 1 = 2
Diana: 1 + 2 = 3
Diana: 2 + 3 = 5
Diana: 3 + 5 = 8
Diana: 5 + 8 = 13
Diana: 8 + 13 = 21
Diana: 13 + 21 = 34
Diana: 21 + 34 = 55
Diana: 34 + 55 = 89
Diana: 55 + 89 = 144
Diana: 89 + 144 = 233
Diana: 144 + 233 = 377
Diana: 233 + 377 = 610
Diana: 377 + 610 = 987
Diana: 610 + 987 = 1597
Diana: 987 + 1597 = 2584
Diana: 1597 + 2584 = 4181
Diana: 2584 + 4181 = 6765
Diana: 4181 + 6765 = 10946
Diana: 6765 + 10946 = 17711
Diana: 10946 + 17711 = 28657
Diana: 17711 + 28657 = 46368
Diana: 28657 + 46368 = 75025
Diana: 46368 + 75025 = 121393
Diana: 75025 + 121393 = 196418
Diana: 121393 + 196418 = 317811
Diana: 196418 + 317811 = 514229
Diana: 317811 + 514229 = 832040
Diana: 514229 + 832040 = 1346269
Diana: 832040 + 1346269 = 2178309
Diana: 1346269 + 2178309 = 3524578
Diana: 2178309 + 3524578 = 5702887
Diana: 3524578 + 5702887 = 9227465
Diana: 5702887 + 9227465 = 14930352
Diana: 9227465 + 14930352 = 24157817
Diana: 14930352 + 24157817 = 39088169
Diana: 24157817 + 39088169 = 63245986
Diana: 39088169 + 63245986 = 102334155
Diana: 63245986 + 102334155 = 165580141
Diana: 102334155 + 165580141 = 267914296
Diana: 165580141 + 267914296 = 433494437
Diana: 267914296 + 433494437 = 701408733
Diana: 433494437 + 701408733 = 1134903170
Diana: 701408733 + 1134903170 = 1836311903
Diana: 1134903170 + 1836311903 = 2971215073
Diana: 1836311903 + 2971215073 = 4807526976
Diana: 2971215073 + 4807526976 = 7778742049
Diana: 4807526976 + 7778742049 = 12586269025
Diana: 7778742049 + 12586269025 = 20365011074
  :
(CTRL + C)
 */