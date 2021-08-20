/**
 * @title CsharpBegin / SampleCode / GotoSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p235 /  6-9
 *          ◆Dictionary
 *          int dic.Count
 *          Dictionary.KeyCollection dic.Keys
 *          Dictionary.ValueCollection dic.Values
 *          bool dic.TryGetValue(T key, out T value)
 *          void dic.Add(T, T)
 *          void dic.Remove(T)
 *          bool dic.ContainsKey(T)
 *          bool dic.ContainsValue(T)
 *                    
 *          ◆KeyValuePair pair
 *          T pair.Key, T pair.Value
 *          
 *          ◆$"{ }"構文, ブラケット[]構文
 *          
 * @author shika
 * @date 2021-08-20
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class DictionarySample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var dic = new Dictionary<string, string>()
            {
                ["Rose"] = "バラ",
                ["Lily"] = "ゆり",
                ["Sunflower"] = "ひまわり",
            };

            Console.WriteLine("Count: " + dic.Count);
            Console.WriteLine("Contains: " + dic.ContainsKey("Rose"));
            Console.WriteLine("Contains: " + dic.ContainsValue("Rose"));

            dic.TryGetValue("Lily", out string name);
            Console.WriteLine("name: " + name);

            dic.Add("Tulip", "チューリップ");
            dic["Sunflower"] = "向日葵";

            foreach(string key in dic.Keys)
            {
                Console.WriteLine($"{key}: {dic[key]}");
            }

            foreach(string value in dic.Values)
            {
                Console.WriteLine(value);
            }

            dic.Remove("Rose");

            foreach(KeyValuePair<string,string> pair in dic)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }//Main()
    }//class
}

/*
Count: 3
Contains: True
Contains: False

//TryGetValue()
name: ゆり

//foreach(string key in dic.Keys)
Rose: バラ
Lily: ゆり
Sunflower: 向日葵
Tulip: チューリップ

//foreach(string value in dic.Values)
バラ
ゆり
向日葵
チューリップ

//foreach(KeyValuePair<string,string> pair in dic)
Lily: ゆり
Sunflower: 向日葵
Tulip: チューリップ

 */