/** 
 *@title CsharpBegin / SampleCode / DynamicObjectSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 11.3.4 Dynamic Object / p560 / List 11-21, 11-22
 *         任意の型を受け取るプロパティ、未定義でも利用できる。
 *         
 *@subject ◆System.Dinamic.DynamicObject
 *         ＊コンストラクタ呼出
 *         dynamic new Xxxx() : DynamicObject
 *           クラスを自己定義し、DynamicObjectを継承する。
 *           通常、new Xxxx()をすると、インスタンスの型は Xxxxだが、
 *           それを dynamic型で受ける。
 *           
 *         ＊dynamic型の set, get時
 *         SetXxxxBinder / GetXxxxBinder:
 *           dynamic型のメンバーを呼び出したときの情報を自動的に格納するクラス。
 *           未定義のメンバーでも可。
 *           呼出時の情報を格納し、自動でメソッド呼出。
 *           TrySetXxxx(SetXxxxBinder, object value),
 *           TryGetXxxx(GetXxxxBinder, out object)
 *           
 *           XxxXxxxBinderのプロパティ (いずれも readonly)
 *           bool   XxxXxxxBinder.IgnoreCase
 *           string XxxXxxxBinder.Name
 *           Type   XxxXxxxBinder.ReturnType
 *           
 *         ＊メソッド
 *         ・未定義のプロパティを set, get
 *         bool DynamicObject?.TrySetMenber(
 *                 SetMemberBinder, object value)
 *         bool DynamicObject?.TryGetMenber(
 *                 GetMemberBinder, out object result)
 *         
 *         ・インデクサー経由での set, get
 *         bool DynamicObject.TrySetIndex(
 *                 SetIndexBinder, object[] indexs, object result)
 *         bool DynamicObject.TryGetIndex(
 *                 GetIndexBinder, object[] indexs, out object result)
 *                 
 *         ・未定義メソッドの呼出時
 *         bool DynamicObject.TryInvokeMember(
 *                 InvokeMemberBinder, object[] args, out object result)
 *                 
 *         ・未定義の二項演算子の呼出時
 *         bool DynamicObject.TryBinaryOperation(
 *                 BinaryOperationBinder, object arg, out object result)
 *                 
 *         ・未定義の単項演算子の呼出時
 *         bool DynamicObject.TryUnaryOperation(
 *                 UnaryOperationBinder, out object result)
 *                 
 *@see ExpandoObjectSample.cs
 *@author shika 
 *@date 2021-11-13 
*/
using System; 
using System.Collections.Generic;
using System.Dynamic;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class DynamicObjectSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            dynamic dyObj = new FreeMember();
            //未定義プロパティに set
            dyObj.Count = 1;     
            dyObj.Name = "山田";

            //未定義プロパティを get
            Console.WriteLine($"Count: {dyObj.Count}");
            Console.WriteLine($"Name : {dyObj.Name}");

            //未定義メソッドを呼出
            string echo = dyObj.Echo("鈴木");
            Console.WriteLine($"Echo : {echo}");
        }//Main() 
    }//class 

    class FreeMember : DynamicObject
    {
        private Dictionary<string, object> items;

        public FreeMember()
        {
            this.items = new Dictionary<string, object>();
        }

        //未定義のプロパティ set時の処理
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            this.items[binder.Name] = value;
            return true;
        }

        //未定義プロパティの get時の処理
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            if(!items.TryGetValue(binder.Name, out result))
            {
                result = null;
            }
            return true;
        }

        //未定義メソッドの呼出時の処理
        public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;

            //引数なしの場合
            if(args.Length == 0)
            {
                items.TryGetValue(binder.Name, out result);
            }
            else if (args.Length == 1)//引数１つの場合
            {
                //メソッド名に対応するkeyに 引数の値を渡す
                items[binder.Name] = args[0];

                if (binder.Name.Equals("Echo"))
                { 
                    result = args[0];
                }//if Echo
            }
            
            return true;
        }
    }//class FreeMember
}

/*
Count: 1
Name : 山田
Echo : 鈴木

【考察】if (binder.Name.Equals("Echo"))
メソッド固有の処理を記述しないと resultが出ないのなら、
通常通りにメソッド定義すべきでは？

 */