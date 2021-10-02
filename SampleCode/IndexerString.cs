/**
 * @title CsharpBegin / SampleCode / IndexerString.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第８章 オブジェクト指向 Indexer / p338 / List 8-7, 8-8
 *   ◆Indexer string -> int
 *   ◆Indexer int -> string
 *       
 * @author shika
 * @date 2021-10-02
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class IndexerString
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var jpMonthAry = new JapanMonthArray();
            Console.WriteLine(jpMonthAry["如月"]);
            Console.WriteLine(jpMonthAry[2]);
        }//Main()
    }//class

    class JapanMonthArray
    {
        private readonly string[] _jpMonthAry = {
            "睦月","如月","弥生","卯月","皐月","水無月",
            "文月","葉月","長月","神無月","霜月","師走"};

        //indexer string name -> int index
        public int this[string name]
        {
            get
            {
                return Array.IndexOf(_jpMonthAry, name) + 1;
            }
        }

        //indexer int index -> string name
        public string this[int index]
        {
            get
            {
                return _jpMonthAry[index - 1];
            }
        }
    }//class JapanMonthArray
}

/*
2
如月

*/