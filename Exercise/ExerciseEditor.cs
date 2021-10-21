/**
 *@title CsharpBegin / Exercise / ExerciseEditor.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 練習問題用のアプリ / Documentの作成 / Appendixに日時と正答率
 * 
 *@author shika 
 *@date 2021-10-21 
 */
using CsharpBegin.Utility.FileDocumentDiv;
using CsharpBegin.Utility.ScanDiv;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Exercise
{
    class ExerciseEditor
    {
        private readonly InsertDocument doc;
        private readonly MultiScan multi;
        private readonly CorrectScan correct;

        public ExerciseEditor() : this("") { }
        
        public ExerciseEditor(string content)
        {
            this.doc = new InsertDocument(content);
            this.multi = new MultiScan();
            this.correct = new CorrectScan(multi);
            ExerciseExe();
        }

        public void ExerciseExe()
        {
            //---- Exercise input ----
            var start = DateTime.Now;
            multi.BuildQuest();
            multi.BuildAnswer();
            var finish = DateTime.Now;
            correct.InputCorrect();

            //---- build result ----
            string date = start.ToString("yyyy-MM-dd(ddd)");
            string contentAll = multi.ShowList(
                correct.correctAnsList, $"==== Exercise Result / {date} ====");
            string appendix = BuildAppendix(date, start, finish);

            //---- File Write ----
        }//ExerciseExe()

        private string BuildAppendix(
            string date, DateTime start, DateTime finish)
        {
            string costTime = ((int)Math.Round(
                (finish - start).TotalMinutes)).ToString();
            
            var bld = new StringBuilder(120);
            bld.Append($"/*==== Appendix ==== \n");
            bld.Append($" *@date: {date} \n");
            bld.Append($" *@time: {start.ToString("HH:mm")} ～ ");
                bld.Append($"{finish.ToString("HH:mm")} ");
                bld.Append($"({costTime}分) \n");
            bld.Append($" *@rate: {correct.CalcCorrectRate()} \n");
            bld.Append(" */ \n");

            //Console.WriteLine($"bld.Length: {bld.Length}");
            Console.WriteLine(bld.ToString());
            return bld.ToString();
        }

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            new ExerciseEditor();
            //new Utility.FileDocumentDiv.InsertDocument("").InsertExe();
        }//Main()
    }//class
}

/* 
==== Exercise Result / 2021-10-21(木) ====
◆〔1〕Q1
○ (1) A1-1
× (2) A1-2 => ○: modi

◆〔2〕Q2
× (1) A2-1 => ○: modi
○ (2) A2-2
○ (3) A2-3
*/

//bld.Length: 104
/*==== Appendix ====
 *@date: 2021-10-21(木)
 *@time: 14:48 ～ 14:48 (1分)
 *@rate: 60.00％ (○ 3 問 / 全 5 問)
 */