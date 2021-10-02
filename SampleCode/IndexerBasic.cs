/**
 * @title CsharpBegin / SampleCode / IndexerBasic.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第８章 オブジェクト指向 Indexer / p334 / List 8-5
 *   ◆Indexer １次元配列
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
    class IndexerBasic
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var ary = new IndexerBasicArray(5);
            ary[0] = 1;
            ary[1] = 10;
            ary[2] = 15;
            ary[3] = 30;
            ary[4] = 60;

            Console.WriteLine(ary[2]);
            Console.WriteLine(ary[-10]);
            Console.WriteLine(ary[6]);
        }//Main()
    }//class

    class IndexerBasicArray
    {
        private int _size;
        private int[] _ary;

        public IndexerBasicArray(int size)
        {
            this._size = size;
            this._ary = new int[_size];
        }

        //indexer
        public int this[int index]
        {
            set
            {
                this._ary[GetIndex(index)] = value;
            }
            get
            {
                return _ary[GetIndex(index)];
            }
        }//indexer

        private int GetIndex(int index)
        {
            if(index < 0)
            {
                return 0;
            }

            return index % _size;
        }//GetIndex()
    }//class IndexerBasicArray
}

/*
15 //ary[2]
1  //ary[-10]
10 //ary[6]

*/