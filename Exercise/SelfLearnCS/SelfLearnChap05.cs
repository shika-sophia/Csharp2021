/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap05.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第５章 標準ライブラリ / p160, p177, p188, p207 /
 *@subject 練習問題 5-1 String, 5-2 Regex, 5-3 DateTime,  
 *@subject 章末問題 File, Directory, Math, BigInteger, Array 
 *@subject ◆章末問題３ コマンドライン引数を「,」で連結。
 *          dataChap.datに書き出し、追記。文字コードは Shift-JIS
 *          
 *          StreamWriter new StreamWriter(
 *              string path, [bool append, [Enccoding, [int bufferSize]]])
 *          void writer.Write(T);
 *          void writer.WriteLine(T);
 *          void writer.Close();
 *          
 *          void File.WriteAllLines(string path, T[]);
 *          
 *          Encoding.UTF8 (既定値)
 *          Encoding.GetEncoding(string); "Shift-JIS"など
 *
 *          ◆コマンドライン引数による実行
 *           [プロジェクト] 右クリック -> [プロパティ] -> [デバッグ]タブ
 *           -> コマンドライン引数: 編集 -> ファイル保存 -> デバッグなし実行
 *           (プロジェクト全体に影響するので、元に戻しておく)
 *           args = new[]{ ... };で代用。
 *           
 *@see Data / dataChap.dat
 *@author shika  
 *@date 2021-11-23  
*/
/*==== Appendix ====  
 *@date: 2021-11-23 (火)  
 *@time: 03:24 ～ 03:44 (20分)  
 *@rate: 54.55％ (○ 6 問 / 全 11 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-11-23 (火) 
 *@time: 04:16 ～ 04:31 (15分) 
 *@rate: 50.00％ (○ 9 問 / 全 18 問) 
*/
using System;  
using System.Collections.Generic;
using System.IO;
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap05  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {
            //◆章末問題３ コマンドライン引数を「,」で連結。
            //dataChap.datに書き出し、追記。文字コードは Shift-JIS
            args = new[] { "あいうえお", "かきくけこ", "さしすせそ" };

            if(args.Length == 0)
            {
                Console.WriteLine(
                    "<!> コマンドライン引数を入力して実行してください。");
                goto exit;
            }

            string result = "";
            foreach(string argBit in args)
            {
                result += argBit + ", ";
            }
            //【解答】 string result = String.Join(",", args);

            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\";
            using (StreamWriter writer = new StreamWriter(
                dir + "dataChap.dat", append: true, Encoding.GetEncoding("Shift-JIS")))
            {
                writer.Write(result + "\n");
                writer.Close();
            }

        exit:
            Console.WriteLine("Main(): end");
        }//Main()   
    }//class  
}

/*
//◆章末問題３
<!> コマンドライン引数を入力して実行してください。
Main(): end

＊/Data/dataChap.dat
あいうえお, かきくけこ, さしすせそ, 
あいうえお, かきくけこ, さしすせそ, 
あいうえお, かきくけこ, さしすせそ, 
*/
/*  
2021-11-23 (火) 
==== Exercise Result ====  
◆〔1〕第５章 標準ライブラリ / 練習問題 5-1  
× (1) "プログラミング言語".Substring(5, 3)  
    => ○: Substring(4,3)  
        0|プ 1|ロ 2|グ 3|ラ 4|ミ 5|ン 6|グ と数える。 
 
○ (2) string[] strSplit = str.Split("\t);  
 
◆〔2〕5-2  
○ (1) Regex regex =@ "〒\d{3}-\d{4}";  
× (2) MutchCollection matchCollection = str.Matches(regex); 
    => ○: regex.Matches(string);  
○ (3) foreach(Match match in matchCollection){  
× (4)     Console.WriteLine($"{match.Value}"); }  
    => ○: 変数だけなら(match.Value)でOK  
× (5) 2. regex.Replace(str, "<a href=@"mailto:'$1'">'$'</a>  
    => ○: 「"」は第2引数全部をくくる必要がある 
            href=" "は「'」で可。 
            $0: マッチ文字列全体、$1, $2..:サブマッチ文字列 
            regex.Replace(str, "<a href='meolto:$0'>$0</a>"); 
 
◆〔3〕5-3  
○ (1) DateTime dt = DateTime.Parse("2018/02/15 13:17:25");  
○ (2) dt.Day, dt.Hour  
○ (3) DateTime now = DateTime.Now;  
× (4) DateTime after = now.AddDays(15);  
    => ○: 本文参照した Day ではなく、Daysに注意。 
*/
/*==== Appendix ====  
 *@date: 2021-11-23 (火)  
 *@time: 03:24 ～ 03:44 (20分)  
 *@rate: 54.55％ (○ 6 問 / 全 11 問)  
*/
/* 
2021-11-23 (火)
==== Exercise Result ==== 
◆〔1〕章末問題 
○ (1) int lastIndex = str.LastIndexOf("きゃく"); 
× (2) String.format("$sの気温は%{f:.1}℃");
    => ○: String.Format()の仮変数は {0}, {1}, ..
       String.Format("{0}の気温は、{1:F1}℃", "弘前", 15.156);

○ (3) str.Replace("ボク", "私"); 
× (4) DateTime now = DateTime.Now; => ○: dt.Add(new TimeSpan( 5, 4, 0, 0)); 
× (5) DateTime after = now.AddDays(5).AddHours(4); => ○: 上記 
× (6) TimeSpan span = ... 
    => ○: DateTime dt1 = new DateTime(...);
          DateTime dt2 = new DateTime(...);
          Console.WriteLine(dt2.Subtract(dt1));

◆〔2〕２ 
× (1) System.RegularExpression; 
    => ○: using System.Text.RegularExpressions; 
○ (2) using() 
○ (3) @ 
× (4) reader.EndOfLine() => ○: reader.EndOfStream 
○ (5) ReadLine() 
× (6) rgx.Match() => ○: rgx.Matches() 
○ (7) match.Value 

◆〔3〕３ 
○ (1) 別紙 

◆〔4〕４ 
× (1) Math.Power(5, 3); => ○: Math.Pow(5, 3); 
○ (2) Math.Abs(-12); 
○ (3) int[] ary = new int[]{105, 18, 25, 30}; 
× (4) int sortedAry = Array.Sort(ary); 
    => ○: 参照型なので代入不要。Array.Sort(T[])でOK 
*/
/*==== Appendix ==== 
 *@date: 2021-11-23 (火) 
 *@time: 04:16 ～ 04:31 (15分) 
 *@rate: 50.00％ (○ 9 問 / 全 18 問) 
*/
