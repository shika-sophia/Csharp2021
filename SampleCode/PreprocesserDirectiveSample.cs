/**
 * @title CsharpBegin / SampleCode / PreprocesserDirectiveSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第４章 制御構文 / p141 / List 4-32, 4-33
 *          ◆プリプロセッサ・ディレクティブ
 *          コンパイラに対する命令を「#」で記述
 *          #define: ファイル先頭にのみ記述可
 *            DEBUG | TESTED デバッグ時 | テスト時のみ有効
 *            [VS]ソリューション -> プロジェクト名 -> 右クリック
 *            -> [プロパティ] -> [ビルド] -> DEBUG変数(既定で有効)
 *            
 *          【考察】
 *           デバッグ時(= 実行時)のみ表示。
 *           リリース時には除去するための注釈
 *            
 *          #if: 条件分岐
 *          #region: 折りたたみ可能なブロック
 *       
 * @author shika
 * @date 
 */
#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class PreprocesserDirectiveSample
    {
        static void Main(string[] args)
        //internal void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("デバッグ時のみ表示");
#endif
#if (DEBUG || TESTED)
            Console.WriteLine("デバッグ時とテスト時のみ表示");
#endif

            #region ---- 変数定義 region ----
            const string Pubulisher = "翔泳社";
            const double Tax = 1.08;
            var author = "山田祥寛";
            var title = "『独習 C＃ [新版] 』";
            var price = 3600;
            #endregion

            Console.WriteLine($"{author}{title}({Pubulisher})");
            Console.WriteLine($"{price * Tax}円");
        }//Main()
    }//class
}

/*
デバッグ時のみ表示
デバッグ時とテスト時のみ表示
山田祥寛『独習 C＃ [新版] 』(翔泳社)
3888円

 */
