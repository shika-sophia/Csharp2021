/** 
 *@title CsharpBegin / SampleCode / OperatorEquals.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 9.6 OperatorEquals / p460 / List 9-54
 *@subject public static operator ==(object, object) 「==」を再定義 
 *         public static operator !=(object, object) 「!=」を再定義 
 *
 *@notice  (註)static method はコメントアウト中。
 *         / static methods have been to comment out.
 *         
 *         「==」を再定義すると「!=」も再定義が必要
 *         「==」を再定義すると、
 *         Object.Equals(), Object.GetHashCode()の overrideも求められる。
 *         
 *         null判定の前に(object)キャストをしないと、
 *         ここの「==」オーバーロードが呼び出され永久ループとなるので注意。
 *
 *@see EqualOverrideSample / PersonOverrideSample.cs
 *@author shika 
 *@date 2021-10-31 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class OperatorEquals 
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            //==== Test OpeEquals ====
            var p1 = new PersonOpe("Sophia", "Shika");
            var p2 = p1;
            var p3 = new PersonOpe("Sophia", "Shika");
            var p4 = new PersonOpe("Lily", "Kouhara");

            var personList = new List<PersonOpe> {p1, p2, p3, p4};
            int count = 1;
            personList.ForEach(p => Console.WriteLine($"p{count++} {p}"));

            Console.WriteLine($"Reference / p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"Property Value / p1 == p2: {p1 ==p2}");
            Console.WriteLine($"Reference / p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine($"Property Value / p1 == p3: {p1 == p3}");
            Console.WriteLine($"Reference / p1.Equals(p3): {p1.Equals(p4)}");
            Console.WriteLine($"Property Value / p1 == p4: {p1 == p4}");
        }//Main() 
    }//class 

    class PersonOpe
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public PersonOpe(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        //==== 「==」Property同値性 ====
        //public static bool operator ==(PersonOpe p1, PersonOpe p2)
        //{
        //    if(Object.ReferenceEquals(p1, p2)) 
        //    { 
        //        return true;
        //    }
        //    if((object) p1 == null || (object) p2 == null ||
        //        p1.GetType() != p2.GetType())
        //    {
        //        return false;
        //    }

        //    return p1.FirstName == p2.FirstName && 
        //           p1.LastName == p2.LastName;
        //}//「==」

        ////==== 「!=」: this.「==」Property同値性を反転 ====
        //public static bool operator !=(PersonOpe p1, PersonOpe p2)
        //{
        //    return !(p1 == p2);
        //}

        //====  参照同一性 Object.Equals() ====
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}";
        }
    }//class
}

/*
p1 Name: Sophia Shika
p2 Name: Sophia Shika
p3 Name: Sophia Shika
p4 Name: Lily Kouhara
Reference / p1.Equals(p2): True
Property Value / p1 == p2: True
Reference / p1.Equals(p3): False
Property Value / p1 == p3: True
Reference / p1.Equals(p3): False
Property Value / p1 == p4: False
 */
