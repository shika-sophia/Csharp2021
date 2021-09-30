/**
 * @title CsharpBegin / SampleCode / IteratorSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 Iterator / p311 / List 7-48
 *    ◆System.Collections.Generic
 *    IEnumerable<T> / IEnumerator<T>
 *    yield return T
 *    
 * @author shika
 * @date 2021-09-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class IteratorSample
    {
        static void Main(string[] args)
        //public void Main(string[] args)
        {
            var itr = new IteratorSample();
            foreach(string str in itr.GetStrings())
            {
                Console.WriteLine(str);
            }
        }//Main()

        public IEnumerable<string> GetStrings()
        {
            yield return "あいうえお";
            yield return "かきくけこ";
            yield return "さしすせそ";
        }
    }//class
}

/*
あいうえお
かきくけこ
さしすせそ
 */