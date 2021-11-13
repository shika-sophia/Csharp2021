/** 
 *@title CsharpBegin / SampleCode / ExpandoObjectSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content ExpandoObject / p563 / List 11-23
 *         未定義プロパティの set, get限定なら、
 *         DynamicObjectではなく、ExpandoObjectを利用する。
 *         継承クラスの定義や TryXxxXxxx()の overrideが不要
 *         
 *@subject ◆System.Dynamic.ExpandoObject
 *         DynamicObjectの仕組みを内部化していると思われる。
 *         => 下記【参考】
 *         
 *         ＊未定義プロパティの set, get
 *         ＊デリゲート型プロパティで疑似的にメソッド定義
 *
 *@see DynamicObjectSample.cs
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
    class ExpandoObjectSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            dynamic expaObj = new ExpandoObject();
            expaObj.Count = 2;
            expaObj.Name = "ゆり";
            Console.WriteLine($"Count: {expaObj.Count}");
            Console.WriteLine($"Name : {expaObj.Name}");

            //デリゲート型のプロパティで疑似的にメソッド定義
            expaObj.Add = (Func<double, double, double>)((x, y) => x + y);
            Console.WriteLine($"Add(10, 5): {expaObj.Add(10, 5)}");
        }//Main() 
    }//class 
}

/*
Count: 2
Name : ゆり
Add(10, 5): 15

【参考】ExpandoObject
namespace System.Dynamic
{
    //実行時にメンバーを動的に追加/削除できるオブジェクト。
    public sealed class ExpandoObject
        : IDynamicMetaObjectProvider,
          IDictionary<string, object>,
          ICollection<KeyValuePair<string, object>>,
          IEnumerable<KeyValuePair<string, object>>,
          IEnumerable,
          INotifyPropertyChanged
    {
        public ExpandoObject();
    }//class
}
 */
