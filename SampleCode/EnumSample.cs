/** 
 *@title CsharpBegin / SampleCode / EnumSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第９章 / EnumSample / p416 / List 9-28
 *  ◆System.Enum
 *  string enum.ToString() / 文字列値
 *  int enum.ToString("D") / {enum : D} index値
 *  int enum.ToString("X") / {enum : X} 16進数の８桁
 *  
 *  Array Enum.GetValues(Type)
 *     Type typeof(T)
 *     Type obj.GetType()
 * 
 *@author shika 
 *@date 2021-10-26 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    enum Season
    {
        Spring, Summer, Autumn, Winter,
        All = Spring + Summer + Autumn + Winter,
    }//enum

    class EnumSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Season season = new Season();
            Console.WriteLine($"season.ToString(): {season}");

            Season sp = Season.Spring;
            Console.WriteLine($"sp type: {sp.GetType()}");
            Console.WriteLine($"sp.ToString(): {sp}");
            Console.WriteLine("sp.ToString('D'): " + sp.ToString("D"));
            Console.WriteLine($"Summer index: {Season.Summer:D}");
            Console.WriteLine($"All index16: {Season.All:X}");

            Array enumAry = Enum.GetValues(typeof(Season));
            foreach(Season value in enumAry)
            {
                Console.Write($"{(int)value}:{value}, ");
            }
            Console.WriteLine();
        }//Main()

    }//class
}

/*
season.ToString(): Spring
sp type: CsharpBegin.SampleCode.Season
sp.ToString(): Spring
sp.ToString('D'): 0
Summer index: 1
All index16: 00000006

＊foreach(Season value in enumAry)
   => 0:Spring, 1:Summer, 2:Autumn, 3:Winter, 6:All,

【考察】Season season = new Season();
このインスタンスをしても seasonのメソッドがなく意味がない。
暗黙で最初の要素 Springが代入されている。

要素すべてを表示するなら、
Array Enum.GetValues(Type)
    Arrayは全ての配列のルートとのこと。
    Arrayから enumAry[0]での値取得は不可。
    型を string[]へ代替するのは不可。
    foreach内 ローカル変数 valueは string不可。
    Season valueで解決。
 */