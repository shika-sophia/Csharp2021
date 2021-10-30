/** 
 *@title CsharpBegin / SampleCode / GenericsSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content GenericsSample / p441 / List 9-43 ～ 9-47
 *@subject + void ArrayResize<T>(T[] array, int newSize)
 *         Arrayクラス static Array.Resize()として
 *         実際にあるジェネリックメソッド。
 *         配列のサイズを拡張する。
 *         
 *@subject - T CreateInstance<T>() where T : new()
 *         コンストラクタ制約付きのジェネリックメソッド
 *         ListGenericSample<T>のインスタンスを返す。
 *         
 *subject ListGenericSample<T>
 *        Listぽいジェネリッククラス
 * 
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
    class GenericsSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //==== Test ArrayResize() ====
            var dataAry = new[] { 1, 2, 3 };
            var here = new GenericsSample();
            here.ArrayResize(ref dataAry, 10);

            Console.WriteLine($"dataAry.Length: {dataAry.Length}");

            //==== Test CreateInstance<T>() ====
            //here.CreateInstance(); 
            //  -> 型を推論できないので、明示的に型指定する必要がある。
            var listSample = here.CreateInstance<ListGenericSample<string>>();
            Console.WriteLine($"listSample.Count: {listSample.Count}");
        }//Main()

        public void ArrayResize<T>(
            ref T[] array, int newSize) where T : struct
        {
            T[] tempAry = array;

            if(tempAry == null)
            {
                array = new T[newSize];
                return;
            }

            if(tempAry.Length != newSize)
            {
                T[] newAry = new T[newSize];
                Array.Copy(tempAry, 0, newAry, 0,
                    (tempAry.Length > newSize)? newSize : tempAry.Length);
                array = newAry;
            }
        }//ArrayResize<T>()

        private T CreateInstance<T>() where T : new()
        {
            return new T();
        }
    }//class
    
    class ListGenericSample<T>
    {
        private T[] _items;
        private int _size;

        public ListGenericSample() : this(10) { }

        public ListGenericSample(int size)
        {
            this._items = new T[size];
            this._size = size;
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }//Indexer

        public int Count
        {
            get { return _size; }
            set { _size = value; }
        }

        public void Add(T item)
        {
            _items[_size++] = item;
        }//Add()

        public List<T> ToList()
        {
            return new List<T>(_items);
        }
    }//class
}

/*
//==== Test ArrayResize() ====
dataAry.Length: 10

//==== Test CreateInstance<T>() ====
listSample.Count: 10
 */