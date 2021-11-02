/** 
 *@title CsharpBegin / SampleCode / DelegateArgs.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 10.1.2 DelegateArgs / p476 / List 10-2, 10-3
 *         デリゲートを他メソッドの引数に代入
 *         
 *         //==== DOutputSampleに対応したメソッド ====
 *         delegate void DOutputSample (string str);
 *@subject AryWalkUsed(string[])                //デリゲート利用しない場合
 *@subject AryWalkUsed(string[], DOutputSample) //デリゲート利用時
 *@subject AryWalkUsed(string[], DOutputSample) //メソッドの切替
 *         同じメソッド呼出で異なる挙動
 *@subject マルチキャスト・デリゲート
 *         del = ShowData; 
 *         del += SHowFront4;
 *@subject 登録メソッドの削除
 *         del -= SHowFront4;
 *         
 *         //==== DOutputReturnに対応したメソッド ====
 *         delegate string DOutputReturn(string str);
 *@subject AryWalkRe(string[], DOutputReturn)
 *         最後に登録した ShowFront3()の結果のみ表示
 *
 *@author shika 
 *@date 2021-11-02 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class DelegateArgs 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            string[] dataAry = new[] { "いろはにほへと", "ちりぬるを", "わかよたれそ" };
            var delImpl = new DelegateUse();

            //==== DOutputSampleに対応したメソッド ====
            //デリゲート利用しない場合
            delImpl.AryWalkNoused(dataAry);

            //デリゲート利用
            DOutputSample del = delImpl.ShowData;
            delImpl.AryWalkUsed(dataAry, del);

            //メソッドの切替
            del = delImpl.GetLength;
            delImpl.AryWalkUsed(dataAry, del);
            Console.WriteLine($"totalLength: {delImpl.Result}");

            //マルチキャスト・デリゲート
            del = delImpl.ShowData;
            del += delImpl.ShowFront3;
            delImpl.AryWalkUsed(dataAry, del);

            //登録メソッドの削除
            del -= delImpl.ShowFront3;
            delImpl.AryWalkUsed(dataAry, del);

            //==== DOutputReturnに対応したメソッド ====
            //戻り値のあるデリゲート
            DOutputReturn delRe = delImpl.ShowDataRe;
            delRe += delImpl.ShowFront3Re;
            delImpl.AryWalkRe(dataAry, delRe);
        }//Main()
    }//class 

    delegate void DOutputSample (string str);
    delegate string DOutputReturn(string str);

    class DelegateUse
    {
        public int Result { get; set; }

        internal void AryWalkNoused(string[] dataAry)
        {
            foreach (string data in dataAry)
            {
                Console.WriteLine($"[{data}]");
            }
        }//AryWalkNoused()

        //==== DOutputSampleに対応したメソッド ====
        internal void AryWalkUsed(string[] dataAry, DOutputSample del)
        {
            foreach (string data in dataAry)
            {
                del(data);
            }
        }//AryWalkUsed()

        internal void ShowData(string data)
        {
            Console.WriteLine($"[{data}]");
        }

        internal void GetLength(string data)
        {
            Result += data.Length;
        }

        internal void ShowFront3(string data)
        {
            Console.WriteLine($"Front3: {data.Substring(0, 3)}");
        }

        //==== DOutputReturnに対応したメソッド ====
        internal void AryWalkRe(string[] dataAry, DOutputReturn delRe)
        {
            foreach (string data in dataAry)
            {
                Console.WriteLine(delRe(data));
            }
        }//AryWalkRe()

        internal string ShowDataRe(string data)
        {
            return $"[{data}]";
        }

        internal string ShowFront3Re(string data)
        {
            return $"Front3: {data.Substring(0, 3)}";
        }
    }//class
}

/*
//==== DOutputSampleに対応したメソッド ====
//---- AryWalkNoused(string[]) ----
[いろはにほへと]
[ちりぬるを]
[わかよたれそ]

//---- AryWalkUsed(string[], DOutputSample) ----
[いろはにほへと]
[ちりぬるを]
[わかよたれそ]

//---- AryWalkUsed(string[], DOutputSample) ----
//同じメソッド呼出で異なる挙動
totalLength: 18

//マルチキャスト・デリゲート
[いろはにほへと]
Front3: いろは
[ちりぬるを]
Front3: ちりぬ
[わかよたれそ]
Front3: わかよ

//登録メソッドの削除
[いろはにほへと]
[ちりぬるを]
[わかよたれそ]

//==== DOutputReturnに対応したメソッド ====
//---- AryWalkRe(string[], DOutputReturn) ----
//最後に登録した ShowFront3()の結果のみ表示
Front3: いろは
Front3: ちりぬ
Front3: わかよ
 */