/** 
 *@title CsharpBegin / SampleCode / ReflectionSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 11.2 Reflection / p548 / List 11-14 ～ 11-16
 *@subject ◆System.Activatorクラス: インスタンス生成
 *         ＊引数なしコンストラクタ
 *         object Activator.CreateInstance(Type);
 *         
 *         ＊引数ありコンストラクタ
 *         ConstructorInfo type.GetConstructor(Type[] argsType)
 *         object constructorInfo.Invoke(T[] argsValue)
 *         
 *@sublect ◆System.Type / System.Reflection.MethodInfo
 *         Type typeof(T) T:staticのみ、オブジェクト変数不可
 *         Type obj.GetType()
 *         
 *         ＊全メソッド
 *         MethodInfo[] type.GetMethods()
 *         string methodInfo.Name;
 *         
 *         ＊メソッド取得 -> 実行
 *         MethodInfo type.GetMethod(string name, Type[] argsType)
 *         object methodInfo.Invoke(
 *             object instance, object[] argsValue)
 *         
 *@author shika 
 *@date 2021-11-08 
*/ 
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{
    class ReflectionSample
    {
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //◆Activatorクラス
            //＊引数なしコンストラクタでインスタンス生成
            Type person = typeof(PersonReflect);
            object personIns = Activator.CreateInstance(person);
            Console.WriteLine(personIns); //結果: 名無し 権兵衛

            //＊引数ありコンストラクタでインスタンス生成
            ConstructorInfo constructor =
                person.GetConstructor(
                    new[] { typeof(string), typeof(string) });
            object instance = constructor.Invoke(new[] { "Sophia","Shika" });
            Console.WriteLine(instance);

            //＊String 全メソッド (重複除去)
            Type strType = typeof(string);
            MethodInfo[] methodAry = strType.GetMethods();
            
            IEnumerable<string> itr = methodAry
                .Select(method => method.Name)
                .Distinct();
            foreach(string methodName in itr)
            {
                Console.WriteLine(methodName);
            }

            //＊Method取得 -> 実行
            MethodInfo main = person.GetMethod(
                "Main", new Type[] { typeof(string[]) });
            main.Invoke(instance, new[] { args });
        }//Main() 
    }//class

    class PersonReflect
    {
        private string firstName;
        private string lastName;

        public PersonReflect() : this("権兵衛","名無し") { }
        public PersonReflect(string firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void Main(string[] args)
        {
            Console.WriteLine(
                $"{nameof(PersonReflect)} Main(): {ToString()}");
        }

        public override string ToString()
        {
            return $"{lastName} {firstName}";
        }
    }//class
}

/*
◆PersonReflect
＊引数なしコンストラクタ
名無し 権兵衛

＊引数ありコンストラクタ
Shika Sophia

◆String 全メソッド (重複除去)
Join
Equals
op_Equality
op_Inequality
CopyTo
ToCharArray
IsNullOrEmpty
IsNullOrWhiteSpace
GetHashCode
Split
Substring
Trim
TrimStart
TrimEnd
IsNormalized
Normalize
Compare
CompareTo
CompareOrdinal
Contains
EndsWith
IndexOf
IndexOfAny
LastIndexOf
LastIndexOfAny
PadLeft
PadRight
StartsWith
ToLower
ToLowerInvariant
ToUpper
ToUpperInvariant
ToString
Clone
Insert
Replace
Remove
Format
Copy
Concat
Intern
IsInterned
GetTypeCode
GetEnumerator
get_Chars
get_Length
GetType

＊メソッド取得 => 実行
PersonReflect Main(): Shika Sophia
 */
