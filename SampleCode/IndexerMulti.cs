/**
 * @title CsharpBegin / SampleCode / IndexerMulti.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第８章 オブジェクト指向 Indexer / p337 / List 8-6
 *   ◆Indexer 2次元配列
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
    class IndexerMulti
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var aryMulti = new IndexerMultiArray(3, 2);
            aryMulti[0, 0] = 1;
            aryMulti[0, 1] = 2;
            aryMulti[1, 0] = 3;
            aryMulti[1, 1] = 4;
            aryMulti[2, 0] = 5;
            aryMulti[2, 1] = 6;

            Console.WriteLine(aryMulti[2, 1]);
            Console.WriteLine(aryMulti[-1, 0]);
            Console.WriteLine(aryMulti[4, 0]);
        }//Main()
    }//class

    class IndexerMultiArray
    {
        private int[] _sizeAry; //配列サイズ
        private int[,] _aryMulti; //二次元配列

        public IndexerMultiArray(int size1, int size2)
        {
            this._sizeAry = new[] { size1, size2 };
            this._aryMulti = new int[size1, size2];
        }

        //indexer
        public int this[int index1, int index2]
        {
            set
            {
                _aryMulti[
                    GetIndex(index1, 0), 
                    GetIndex(index2, 1)] = value;
            }

            get
            {
                return _aryMulti[
                    GetIndex(index1, 0),
                    GetIndex(index2, 1)];
            }
        }//indexer

        private int GetIndex(int index, int dimention)
        {
            if(index < 0)
            {
                return 0;
            }

            return index % _sizeAry[dimention];
        }//GetIndex()
    }//class IndexerMultiArray
}

/*
6 //aryMulti[2, 1]
1 //aryMulti[-1, 0] -> aryMulti[0, 0]
3 //aryMulti[4, 0] -> aryMulti[1, 0]
 */
