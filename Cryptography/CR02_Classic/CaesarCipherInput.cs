/** 
 *@title CsharpBegin / Cryptography / CR02_Classic / CaesarCipherInput.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content CaesarCipherInput
 *@based   CaesarCipher
 *@modify ==== Modificaton Point ONLY ====
 *        AskTextCRで ユーザー入力 -> char[]
 *        
 *        Encrypt(string) -> Encrypt(char[])
 *        Decrypt(string) -> Decrypt(char[])
 *        
 *        lower -> Encrypt(char[])
 *        upper -> Decrypt(char[])
 *        
 *@modify input shiftNum also
 *@modify shiftNum == -99 -> CaesarCipher.BruteForth()
 *        
 *@NOTE 全角アルファベットだと、暗号化, 復号化に
 *      記号文字が入るため、AskTextCR.csのほうで入力不可に修正。
 *
 *@see ../AskTextCR.cs
 *@see CaesarCipher.cs
 *@see Utility / ScanDiv / IntScan.cs
 *@author shika 
 *@date 2022-01-19 
*/
using CsharpBegin.Utility.ScanDiv;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.CR02_Classic 
{ 
    class CaesarCipherInput 
    { 
        private char[] plainAry; 
        private char[] cipherAry; 
        private int shiftNum; 
        private const char lowerInit = 'a'; //= 97 ,'ａ' = 65345
        private const char upperInit = 'A'; //= 65 ,'Ａ' = 65313

        public CaesarCipherInput() : this(-99) { }
        public CaesarCipherInput(int shiftNum)
        {
            if (shiftNum == -99)
            {
                ;
            }
            else if (shiftNum < 0 || shiftNum >= 26)
            {
                throw new ArgumentOutOfRangeException(
                    "<!> shiftNum of CaesarCipher(int shiftNum) should entry in range [0 - 25].");
            }
            
            this.shiftNum = shiftNum; 
        }//constructor
 
        public char[] Encrypt(char[] plainAry) 
        { 
            this.plainAry = plainAry; 
            this.cipherAry = new char[plainAry.Length]; 
 
            for (int i = 0; i < plainAry.Length; i++) 
            { 
                char c = (char) (plainAry[i] + shiftNum); 
 
                if (lowerInit + 25 < c) 
                { 
                    c = (char) (c - 26); 
                } 
 
                cipherAry[i] = c; 
            }//for 
 
            return cipherAry; 
        }//Encrypt(char[]) 
 
        public char[] Decrypt() 
        { 
            if (cipherAry == null) 
            { 
                throw new ArgumentException( 
                    "<!> Decrypt(char[] cipherAry) need any string argument."); 
            } 
 
            return Decrypt(this.cipherAry); 
        }//Decrypt() 
 
        public char[] Decrypt(char[] cipherAry) 
        { 
            this.cipherAry = cipherAry; 
            this.plainAry = new char[cipherAry.Length]; 
 
            for (int i = 0; i < cipherAry.Length; i++) 
            { 
                char c = (char) (cipherAry[i] - shiftNum); 
 
                if (c < upperInit) 
                { 
                    c = (char) (c + 26); 
                } 
 
                plainAry[i] = c; 
            }//for 
 
            return plainAry; 
        }//Decrypt(string) 

        private string ToString(char[] charAry)
        {
            return String.Join("", charAry);
        }

        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            var ask = new AskTextCR();
            char[] inputAry = ask.ReadText(
                "◆Alphabet ONLY \n[plain: lower] [cipher: upper] >");
            reKey:
            var shiftNum = new IntScan(0, 25).JudgeInt("◆Shift Number [-99: unknown] > ");
            var here = new CaesarCipherInput(shiftNum);

            if (inputAry.All<char>(c => Char.IsLower(c)))
            {
                if(shiftNum == -99)
                {
                    goto reKey;
                }

                here.Encrypt(inputAry);
            }
            else
            {
                if (shiftNum == -99)
                {
                    string brute = new CaesarCipher(-99)
                        .BruteForth(here.ToString(inputAry));
                    Console.WriteLine(brute);
                    goto end;
                }
                else
                {
                    here.Decrypt(inputAry);
                }
            }

            Console.WriteLine(
                $"Input Text : {here.ToString(inputAry)}");
            Console.WriteLine(
                $"Plain Text : {here.ToString(here.plainAry).ToLower()}");
            Console.WriteLine(
                $"Cipher Text: {here.ToString(here.cipherAry).ToUpper()}");
        end:;
        }//Main()
    }//class 
}

/*
◆Alphabet ONLY
[plain: lower] [cipher: upper] > yoshiko
Input Text : yoshiko
Plain Text : yoshiko
Cipher Text: BRVKLNR

◆Alphabet ONLY
[plain: lower] [cipher: upper] > azure
Input Text : azure
Plain Text : azure
Cipher Text: DCXUH

◆Alphabet ONLY
[plain: lower] [cipher: upper] > BRVKLNR
Input Text : BRVKLNR
Plain Text : yoshiko
Cipher Text: BRVKLNR

◆Alphabet ONLY
[plain: lower] [cipher: upper] > DCXUH
Input Text : DCXUH
Plain Text : azure
Cipher Text: DCXUH

//---- Test input Surrogate ----
◆Alphabet ONLY
[plain: lower] [cipher: upper] > ｙｏｓｈｉｋｏ
Input Text : ｙｏｓｈｉｋｏ
Plain Text : ｙｏｓｈｉｋｏ
Cipher Text: ＢＸ＼ＱＲＴＸ

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ＢＸ＼ＱＲＴＸ
<!> Please input alphabets with all lower or all upper.

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ａｚｕｒｅ
Input Text : ａｚｕｒｅ
Plain Text : ａｚｕｒｅ
Cipher Text: ＪＣ＾［Ｎ

◆Alphabet ONLY
[plain: lower] [cipher: upper] > ＡＺＵＲＥ
Input Text : ＡＺＵＲＥ
Plain Text : ＞ｗｒｏｂ
Cipher Text: ＡＺＵＲＥ

//---- Modified Test input as cannot Surrogate ----
◆Alphabet ONLY
[plain: lower] [cipher: upper] > Ｂ
<!> It cannot input the Surrogate Character like 'Ａ', 'ａ'.
<!> Please input alphabets with all lower or all upper.

//---- Mosified Test input also ShiftNum ----
◆Alphabet ONLY
[plain: lower] [cipher: upper] > yoshiko
◆Shift Number > : 3
Input Text : yoshiko
Plain Text : yoshiko
Cipher Text: BRVKLNR

◆Alphabet ONLY
[plain: lower] [cipher: upper] > yoshiko
◆Shift Number [-99: unknown] > : -99
◆Shift Number [-99: unknown] > : 3
Input Text : yoshiko
Plain Text : yoshiko
Cipher Text: BRVKLNR

◆Alphabet ONLY
[plain: lower] [cipher: upper] > BRVKLNR
◆Shift Number [-99: unknown] > : -99
◆Brute-Forth(BRVKLNR)
〔key:  0〕BRVKLNR => brvklnr
〔key:  1〕BRVKLNR => aqujkmq
〔key:  2〕BRVKLNR => zptijlp
〔key:  3〕BRVKLNR => yoshiko
〔key:  4〕BRVKLNR => xnrghjn
〔key:  5〕BRVKLNR => wmqfgim
〔key:  6〕BRVKLNR => vlpefhl
〔key:  7〕BRVKLNR => ukodegk
〔key:  8〕BRVKLNR => tjncdfj
〔key:  9〕BRVKLNR => simbcei
〔key: 10〕BRVKLNR => rhlabdh
〔key: 11〕BRVKLNR => qgkzacg
〔key: 12〕BRVKLNR => pfjyzbf
〔key: 13〕BRVKLNR => oeixyae
〔key: 14〕BRVKLNR => ndhwxzd
〔key: 15〕BRVKLNR => mcgvwyc
〔key: 16〕BRVKLNR => lbfuvxb
〔key: 17〕BRVKLNR => kaetuwa
〔key: 18〕BRVKLNR => jzdstvz
〔key: 19〕BRVKLNR => iycrsuy
〔key: 20〕BRVKLNR => hxbqrtx
〔key: 21〕BRVKLNR => gwapqsw
〔key: 22〕BRVKLNR => fvzoprv
〔key: 23〕BRVKLNR => euynoqu
〔key: 24〕BRVKLNR => dtxmnpt
〔key: 25〕BRVKLNR => cswlmos

◆Shift Number [-99: unknown] > : 2
Input Text : yoshiko
Plain Text : yoshiko
Cipher Text: {QUJKMQ

【考察】shiftNum == 2 のとき
アルファベットのシフトに不具合発生
if(LowerInit + 26 < c) => +25 に修正して解決
 */
