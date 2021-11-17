/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLeranChap04.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第４章 制御構文 / 練習問題 4-1, 4-2, 4-3, 章末問題, 
 *
 *         ◆コマンドライン引数による実行
 *           [プロジェクト] 右クリック -> [プロパティ] -> [デバッグ]タブ
 *           -> コマンドライン引数: 編集 -> ファイル保存 -> デバッグなし実行
 *           (プロジェクト全体に影響するので、元に戻しておく)
 *  
 *@author shika  
 *@date 2021-11-18  
*/  
/*==== Appendix ====  
 *@date: 2021-11-18 (木)  
 *@time: 01:26 ～ 01:38 (12分)  
 *@rate: 94.12％ (○ 16 問 / 全 17 問)  
*/  
/*==== Appendix ==== 
 *@date: 2021-11-18 (木) 
 *@time: 02:42 ～ 02:47 (5分) 
 *@rate: 100.00％ (○ 6 問 / 全 6 問) 
*/ 
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLeranChap04  
    {  
        //static void Main(string[] args)    
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");

            //var here = new SelfLeranChap04(); 
            //here.SumOdd(); //章末問題 1 
            //here.SumOver();  //章末問題 2 
            //here.ArgsMultiple(args); //章末問題 3
            //here.SwitchLanguage(); //章末問題 4 
            //章末問題 5 略 
        }//Main() 

        //章末問題 1. for文で 100-200の奇数の合計を求める 
        private void SumOdd() 
        { 
            int sum = 0; 
            int start = 100; 
            int end = 200; 
 
            for(int i = start; i < end; i++) 
            { 
                if(i % 2 != 0) 
                { 
                    sum += i; 
                } 
            }//for 
 
            Console.WriteLine($"Sum Odd-Number({start} - {end}): {sum}"); 
            //Result// Sum Odd-Number(100 - 200): 7500 
        }//SumOdd() 
 
        //章末問題 2. List 4-26を while文に書き換え 
        private void SumOver() 
        { 
            int LIMIT = 1000; 
            int sum = 0; 
            int i = 0; 
 
            while (i < 100) 
            { 
                ++i; 
                sum += i; 
 
                if(sum > 1000) { break; } 
            }//while 
 
            Console.WriteLine( 
                $"Sum over {LIMIT}: when 1 ～ {i} added, sum: {sum}"); 
            //Result// Sum over 1000: when 1 ～ 45 added, sum: 1035 
        }//SumOver() 

        //章末問題 3.コマンドライン引数を 1.5倍にして返す。型判定を追加。
        private void ArgsMultiple(string[] args)
        {
            double MULTIPLE = 1.5; //固定倍数

            if(args.Length == 0)
            {
                Console.WriteLine(
                    "<!> コマンドライン引数を追加して実行してください。");
            }

            int inputInt = 0;
            foreach (string input in args)
            {
                try
                {
                    inputInt = Int32.Parse(input);
                } 
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.GetType()}:");
                    Console.WriteLine(
                        "<!> コマンドライン引数を整数で入力してください。");
                    break;
                }

                Console.WriteLine($"Args {input}: Result {inputInt * MULTIPLE}");
                //Result//
                //Args 3: Result 4.5
                //Args 10: Result 15
                //System.FormatException:
                //<!> コマンドライン引数を整数で入力してください。
                
            }//foreach
        }//ArgsMutiple()

        //章末問題 4. switch文を用いて　言語の区別をする 
        private void SwitchLanguage() 
        { 
            reAsk: 
            Console.Write("Which Language? :"); 
            string language = Console.ReadLine(); 
            string langLower = language.ToLower(); 
 
            string langType = ""; 
            switch (langLower) 
            { 
                case "java": 
                    langType = "Conpile Language"; 
                    break; 
                case "c#": 
                case "csharp": 
                case "f#": 
                case "fsharp": 
                case "vb": 
                case "visual basic": 
                    langType = ".NET Language"; 
                    break; 
                case "python": 
                case "ruby": 
                    langType = "Script Language"; 
                    break; 
                default: 
                    Console.WriteLine($"{language}: <!> Not Defined"); 
                    goto reAsk; 
            }//switch 
 
            Console.WriteLine($"{language}: {langType}"); 
        }//SwitchLanguage() 
 
        //---- SwitchLanguage() Result ---- 
        //Which Language? :Java 
        //Java: Conpile Language 
        //Which Language? :C# 
        //C#: .NET Language 
        //Which Language? :python 
        //python: Script Language 
        // 
        //Which Language? :ghwn 
        //ghwn: <!> Not Defined 
        //Which Language? :Perl 
        //Perl: <!> Not Defined 
        //Which Language? : 
 
    }//class  
} 
/*  
2021-11-18 (木) 
==== Exercise Result ====  
◆〔1〕制御構文 練習問題 4-1  
○ (1) int point = 75;  
○ (2) if(point >= 90) { }  
○ (3) else if(70 <= point && point < 90) { }   
○ (4) else if(50 <= point && point < 70) { }  
○ (5) else { }  
○ (6) //point = 75;  
○ (7) 2. 別紙  
 
◆〔2〕4-2  
○ (1) while: 条件式が trueの間はずっと繰り返し  
○ (2) do{ }while: まず１度は必ず実行し、while  
○ (3) 2.別紙  
 
◆〔3〕4-3  
○ (1) skip the loop: continue;  
○ (2) escape the loop: break;  
○ (3) 2. int i = 0;  
○ (4) while(i <= 100){  
○ (5) if(i % 2 != 0) { continue; }  
× (6) sum += i++;  
    => ○: i++;は if文の前  
○ (7) }  
*/ 
/*==== Appendix ====  
 *@date: 2021-11-18 (木)  
 *@time: 01:26 ～ 01:38 (12分)  
 *@rate: 94.12％ (○ 16 問 / 全 17 問)  
*/ 
/* 
2021-11-18 (木)
==== Exercise Result ==== 
◆〔1〕章末問題 
○ (1) see SumOdd() 
○ (2) see SumOver() 
○ (3) 1. foreach 
○ (4) 2. args 
○ (5) 3. Parse 
○ (6) 4. i 

*/ 
/*==== Appendix ==== 
 *@date: 2021-11-18 (木) 
 *@time: 02:42 ～ 02:47 (5分) 
 *@rate: 100.00％ (○ 6 問 / 全 6 問) 
*/ 
