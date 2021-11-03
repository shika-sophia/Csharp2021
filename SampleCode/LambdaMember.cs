/** 
 *@title CsharpBegin / SampleCode / LambdaMember.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 10.1.6 LambdaMember / p486 / List 10-10
 *@subject ラムダ式定義
 *  コンストラクタ, プロパティ, インデクサ, メソッド, 演算子
 * 
 *@author shika 
 *@date 2021-11-03 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class LambdaMember 
    {
        private int _field;

        //コンストラクタ
        public LambdaMember() : this(0) { }
        public LambdaMember(int args) => this._field = args;

        //プロパティ [C#7-]
        public int Value
        { 
            get => _field;
            private set => this._field = value; //value: set引数を表す暗黙オブジェクト 
        }

        //getのみプロパティ [C#6以前]
        public DateTime Now => DateTime.Now;

        //インデクサー
        public int this[int index] => Value * index;

        //メソッド
        internal int Calculate() => Value * Value;

        //演算子
        //public static bool operator true(LambdaMember here) => here.Value == 0;
        //public static bool operator false(LambdaMember here) => here.Value != 0;


        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new LambdaMember(24);
            Console.WriteLine($"Value: {here.Value}");
            Console.WriteLine($"now: {here.Now}");
            Console.WriteLine($"LambdaMember[2]: {here[2]}");
            Console.WriteLine($"Calculate(): {here.Calculate()}");

            //if (here) 
            //{
            //    Console.WriteLine($"operator true: {nameof(Value)} == 0");
            //}
            //else //if(!here)は記述不可
            //{ 
            //    Console.WriteLine($"operator false: {nameof(Value)} != 0");
            //}
        }//Main() 
    }//class 
}

/*
Value: 24
now: 2021/11/03 13:46:09
LambdaMember[2]: 48
Calculate(): 576
operator false: Value != 0
 */
