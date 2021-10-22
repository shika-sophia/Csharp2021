/* ====== Template ======
static void Main(string[] args)
//public void Main(string[] args)
{
    new CsharpBegin.Exercise.ExerciseEditor("");
}//Main() 

*/
/** ====== Document ======
 *@title CsharpBegin / Exercise / ExerciseEditor.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 練習問題用のアプリ / Documentの作成 / Appendixに日時と正答率
 *
 *@class ExerciseEditor.cs
 *       /◇FileExecute fileExe,
 *        ◇MultiScan multi,
 *        ◇CorrectScan correct /
 *        ExerciseEditor()
 *        ExerciseEditor(string)
 *        + void ExerciseExe()
 *        - string BuildAppendix(
 *            string date, DateTime start, DateTime finish)
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
        private readonly FileDocExecute fileExe;
        private readonly MultiScan multi;
        private readonly CorrectScan correct;

        public ExerciseEditor() : this("") { }
        
        public ExerciseEditor(string contentDoc)
        {
            this.fileExe = new FileDocExecute("", contentDoc);
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
            string result = multi.ShowList(
                correct.correctAnsList, $"==== Exercise Result / {date} ====");
            string appendix = BuildAppendix(date, start, finish);

            //---- File ReadWrite ----
            fileExe.ReadWriteExe(document: "", appendix, result);
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
            bld.Append("*/ \n");

            //Console.WriteLine($"bld.Length: {bld.Length}");
            Console.WriteLine(bld.ToString());
            return bld.ToString();
        }

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            new ExerciseEditor("");
        }//Main()
    }//class
}

/*
==== Question ====
◆Quest:[-99: to Answer] [-88: Return]
〔1〕Q1
〔2〕Q2
〔3〕Q3
〔4〕-99
<?> Quest(3)で終了します。
終了 よろしいですか？ [Y / N]: t
t は不正な入力です。
[Y / N] で入力してください。

終了 よろしいですか？ [Y / N]: y

==== Answer ====
◆〔1〕Q1
◇Answer:[-99: QuestEnd] [-88: Return]
(1) A1 - 1
(2) A1 - 2
(3) - 99
<?> Answer(2)で終了します。
終了 よろしいですか？ [Y / N]: y

◆〔2〕Q2
◇Answer:[-99: QuestEnd] [-88: Return]
(1) A2 - 1
(2) A2 - 2
(3) - 99
<?> Answer(2)で終了します。
終了 よろしいですか？ [Y / N]: y

◆〔3〕Q3
◇Answer:[-99: QuestEnd] [-88: Return]
(1) A3 - 1
(2) - 99
<?> Answer(1)で終了します。
終了 よろしいですか？ [Y / N]: y

==== Judge Correct ====
◇正誤入力:[0: ○ ] [1: × ] [-88: Return]
◆〔1〕Q1
(1) A1 - 1: 0
  (2) A1 - 2: 1
 => ○: modi

◆〔2〕Q2
(1) A2 - 1: 0
  (2) A2 - 2: 0

◆〔3〕Q3
(1) A3 - 1: 1
 => ○: modi
correctRate: 60.00％ (○ 3 問 / 全 5 問)
bld.Length: 159
/＊
==== Exercise Result / 2021-10-22(金) ====
◆〔1〕Q1
○ (1) A1-1
× (2) A1-2 => ○: modi

◆〔2〕Q2
○ (1) A2-1
○ (2) A2-2

◆〔3〕Q3
× (1) A3-1 => ○: modi
＊/

/＊==== Appendix ====
 *@date: 2021-10-22(金)
 *@time: 17:37 ～ 17:39 (1分)
 *@rate: 60.00％ (○ 3 問 / 全 5 問)
＊/

<○> this Document just has inserted.

*/