/** 
 *@title CsharpBegin / Cryptography / AskTextCR.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content テキストのユーザー入力
 *         [plain: lower] = 平文　: 小文字
 *         [cipher: upper]= 暗号文: 大文字
 *         
 *@subject bool JudgeAlphabet(string input, out char[] charAry)
 *         アルファベットかどうかの判定
 *         IEnumerable<T>.All(Predicate<T>)
 *         bool Char.IsLower()
 *         bool Char.IsUpper()
 *         
 *@NOTE 全角「ＡＢ」なども通ってしまう。
 *      bool Char.IsSurrogate(char) では判定できない。
 *      理由: char 'ａ' = 65345, char 'Ａ' = 65313 であり、整数扱い？
 *      少なくとも サロゲートではない様子。
 *      
 *      bool isSurrogate = charAry.Any<char>(c => (int) c > 65000);
 *      これで解決。
 *      
 *@author shika 
 *@date 2022-01-19 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography 
{ 
    class AskTextCR 
    { 
        public char[] ReadText(string quest)
        {
            char[] charAry;

            while (true)
            {
                Console.Write($"{quest} ");
                string input = Console.ReadLine();
                bool isAlphabet = JudgeAlphabet(input, out charAry);

                if (isAlphabet)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "<!> Please input alphabets with all lower or all upper.");
                    Console.WriteLine();
                    continue;
                }
            }//while loop

            return charAry;
        }//ReadText()

        private bool JudgeAlphabet(string input, out char[] charAry)
        {
            charAry = input.ToCharArray();
            bool isSurrogate = charAry.Any<char>(c => (int) c > 65000);
            bool allLower = charAry.All<char>(c => Char.IsLower(c));
            bool allUpper = charAry.All<char>(c => Char.IsUpper(c));

            if (isSurrogate)
            {
                Console.WriteLine(
                    "<!> It cannot input the Surrogate Character like 'Ａ', 'ａ'.");
                return false;
            }
            bool allAlphabet;
            if (allLower || allUpper)
            {
                allAlphabet = true;
            }
            else 
            {
                allAlphabet = false;
            }

            return allAlphabet;
        }//JudgeAlpabet()

        ////==== Test Main() ====
        //static void Main(string[] args) 
        ////public void Main(string[] args) 
        //{
        //    var here = new AskTextCR();
        //    char[] charAry = here.ReadText(
        //        "◆Alphabet ONLY \n[plain: lower] [cipher: upper] >");

        //    Console.WriteLine($"char[]: {String.Join("", charAry)}");
        //}//Main() 
    }//class 
}

/*
//---- Test input as success ----
◆Alphabet ONLY
[plain: lower] [cipher: upper] > yoshiko
char[]: yoshiko

◆Alphabet ONLY
[plain: lower] [cipher: upper] > END
char[]: END

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ＡＢ
char[]: ＡＢ

//---- Test input as error ----
◆Alphabet ONLY
[plain: lower] [cipher: upper] > abc123
<!> Please input all alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ab cd
<!> Please input all alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > AbcDEf
<!> Please input all alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > あ
<!> Please input alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ａ
<!> Cannot input the Surrogate Character like 'Ａ', 'ａ'.
<!> Please input alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > Ｂ
<!> Cannot input the Surrogate Character like 'Ａ', 'ａ'.
<!> Please input alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] >

 */