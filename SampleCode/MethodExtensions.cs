/**
 *@title CsharpBegin / SampleCode / MethodExtensions.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content MethodExtensions / 拡張メソッド
 *         ◆System.String
 *         string string.Repeat(int count)を追加定義。
 * 
 *@author shika 
 *@date 2021-10-16 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    //static class MethodExtensions
    //{

    //    public static string Repeat(this string str, int count)
    //    {
    //        var bld = new StringBuilder();
    //        for(int i = 0; i < count; i++)
    //        {
    //            bld.Append(str);
    //        }//for
    //        bld.Append("\n");

    //        return bld.ToString();
    //    }//String.Repeat()

    //    //static void Main(string[] args)
    //    public void Main(string[] args)
    //    {
    //        string data = "Thank you! ";
    //        Console.WriteLine(data.Repeat(3));
    //    }//Main()
    //}//class
}

/*
Thank you! Thank you! Thank you!
*/
