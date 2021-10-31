/** 
 *@title CsharpBegin / SampleCode / EqualsOverrideSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 9.6 Objectクラス EqualsOverrideSample / p452 / List 9-48 ～ 9-52
 *         bool Object.Equals(object) // デフォルトでは参照同一性の判定のみ
 *         override bool this.Equals(object) //値の同値性判定をするよう変更
 *         
 *         Equals()を overrideするなら、
 *         Object.GetHashCode()も overrideする必要がある。
 *         慣例的にフィールドの「^」演算(=排他的論理和)
           Equals()で同値判定したフィールドの値を個別に取れるようプロパティ化しておく

 *@see OperatorEquals / PersonOpe.cs
 *@author shika 
 *@date 2021-10-30 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class EqualsOverrideSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var p1 = new PersonOverrideSample(
                firstName: "Sophia", lastName: "Shika");
            var p2 = p1;
            var p3 = new PersonOverrideSample(
                firstName: "Sophia", lastName: "Shika");
            var p4 = new PersonOverrideSample(
                firstName: "Lily", lastName: "Kouhara");

            Console.WriteLine($" p1: {p1}\n p2: {p2}\n p3: {p3}\n p4: {p4}\n"); //ToString()
            Console.WriteLine(
                $"Object.ReferenceEquals(p1,p2): {Object.ReferenceEquals(p1, p2)}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine(
                $"Object.ReferenceEquals(p1,p3): {Object.ReferenceEquals(p1, p3)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine(
                $"Object.ReferenceEquals(p1,p4): {Object.ReferenceEquals(p1, p4)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p4)}");

            Console.WriteLine($"p1.GetHashCode(): {p1.GetHashCode()}");
        }//Main() 
    }//class 

    class PersonOverrideSample
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public PersonOverrideSample(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name is {FirstName} {LastName}.";
        }

        public override bool Equals(object obj)
        {
            //参照同一性の判定
            if(Object.ReferenceEquals(this, obj))
            {
                return true; //参照同一なら、同値性は必ず真。
            }

            //型判定
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            //同値性の判定
            var objPerson = obj as PersonOverrideSample;
            return (this.FirstName == objPerson.FirstName) &&
                (this.LastName == objPerson.LastName);
        }//Equals()

        public override int GetHashCode()
        {
            //return base.GetHashCode();
            // -> public virtual int GetHashCode(); //中身がない。

            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }//GetHashCode()
    }//class
}

/*
 p1: Name is Sophia Shika.
 p2: Name is Sophia Shika.
 p3: Name is Sophia Shika.
 p4: Name is Lily Kouhara.

//参照同一性○, フィールド同値性○
Object.ReferenceEquals(p1,p2): True
p1.Equals(p2): True

//参照同一性×, フィールド同値性○
Object.ReferenceEquals(p1,p3): False
p1.Equals(p3): True

//参照同一性×, フィールド同値性×
Object.ReferenceEquals(p1,p4): False
p1.Equals(p3): False

p1.GetHashCode(): 726001287
 */