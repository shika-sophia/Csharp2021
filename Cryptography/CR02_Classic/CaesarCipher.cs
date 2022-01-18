/** 
 *@title CsharpBegin / Cryptography / CaesarCipher.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content 2.1 Caesar Cipher シーザー暗号 / p22 
 *         [羅] Julius Caesar: ユリウス・カエサル
 *         [英] plain text:  平文 (暗号化していない普通のテキスト)
 *         [英] cipher text: 暗号文
 *         [英] encrypt: 暗号化する
 *         [英] decrypt: 復号する
 *         [英] crypt analysis: 暗号解読
 *         
 *@algorithm アルファベットを同じ数ずつ ずらす
 *          〔All alphabets shift by the same numbers.〕
 *@key       ずらす数 (範囲 [0 - 25])
 *          〔shift number in range[0 - 25]〕
 *
 *@analize ◆Brute-Force Attack: 力づくの解読
 *         = exhausive search: 全数探索, 総当たり法, しらみつぶし法
 *         
 *@keyspace 26 cases:
 *          The key has possible-range [0 - 25]
 *
 *@author shika 
 *@date 2022-01-18 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.CR02_Classic
{ 
    class CaesarCipher 
    {
        private string plain;
        private string cipher;
        private int shiftNum;
        private const char lowerInit = 'a';
        
        public CaesarCipher() : this(-99) { }
        public CaesarCipher(int shiftNum)
        {
            if(shiftNum == -99)
            {
                ;
            }
            else if(shiftNum < 0 || shiftNum >= 26)
            {
                throw new ArgumentOutOfRangeException(
                    "<!> shiftNum of CaesarCipher(int shiftNum) should entry in range [0 - 25].");
            }

            this.shiftNum = shiftNum;
        }

        public string Encrypt(string plain)
        {
            this.plain = plain.ToLower();
            char[] plainAry = plain.ToCharArray();
            char[] cipherAry = new char[plainAry.Length];

            for(int i = 0; i < plainAry.Length; i++)
            {
                char c = (char) (plainAry[i] + shiftNum);

                if(lowerInit + 26 < c)
                {
                    c = (char) (((c - lowerInit) % 26) + lowerInit);
                }

                cipherAry[i] = c;
            }//for

            this.cipher = String.Join("", cipherAry).ToUpper();
            return cipher;
        }//Encrypt()

        public string Decrypt()
        {
            if(cipher == null)
            {
                throw new ArgumentException(
                    "<!> Decrypt(string cipher) need any string argument.");
            }

            return Decrypt(this.cipher);
        }//Decrypt()

        public string Decrypt(string cipher)
        {
            char[] cipherAry = cipher.ToLower().ToCharArray();
            char[] plainAry = new char[cipherAry.Length];

            for (int i = 0; i < cipherAry.Length; i++)
            {
                char c = (char) (cipherAry[i] - shiftNum);

                if(c < lowerInit)
                {
                    c = (char)(c + 26);
                }

                plainAry[i] = c;
            }//for

            return String.Join("", plainAry);
        }//Decrypt(string)

        public string BruteForth(string cipher)
        {            
            var bld = new StringBuilder();
            int originNum = shiftNum;

            bld.Append($"◆Brute-Forth({cipher})\n");
            for(int i = 0; i < 26; i++)
            {
                shiftNum = i;
                bld.Append($"〔key: {shiftNum,2}〕");
                bld.Append($"{cipher} => ");

                string rePrain = Decrypt(cipher);
                bld.Append($"{rePrain}\n");
            }//for
            shiftNum = originNum;

            return bld.ToString();
        }//BruteForth()

        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            const int shiftNum = 3;
            var here = new CaesarCipher(shiftNum);

            //string plain = "yoshiko";
            string plain = "azure";
            string cipher = here.Encrypt(plain);
            string rePlain = here.Decrypt();

            Console.WriteLine($"Plain Text  : {plain}");
            Console.WriteLine($"Cipher Text : {cipher}");
            Console.WriteLine($"RePlain Text: {rePlain}");
            Console.WriteLine($"Shift Number: {shiftNum}");
            Console.WriteLine();
            Console.WriteLine(here.BruteForth(cipher));
        }//Main() 
    }//class 
}

/*
Plain Text  : yoshiko
Cipher Text : BRVKLNR
RePlain Text: yoshiko
Shift Number: 3

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

Plain Text  : azure
Cipher Text : DCXUH
RePlain Text: azure
Shift Number: 3

◆Brute-Forth(DCXUH)
〔key:  0〕DCXUH => dcxuh
〔key:  1〕DCXUH => cbwtg
〔key:  2〕DCXUH => bavsf
〔key:  3〕DCXUH => azure
〔key:  4〕DCXUH => zytqd
〔key:  5〕DCXUH => yxspc
〔key:  6〕DCXUH => xwrob
〔key:  7〕DCXUH => wvqna
〔key:  8〕DCXUH => vupmz
〔key:  9〕DCXUH => utoly
〔key: 10〕DCXUH => tsnkx
〔key: 11〕DCXUH => srmjw
〔key: 12〕DCXUH => rqliv
〔key: 13〕DCXUH => qpkhu
〔key: 14〕DCXUH => pojgt
〔key: 15〕DCXUH => onifs
〔key: 16〕DCXUH => nmher
〔key: 17〕DCXUH => mlgdq
〔key: 18〕DCXUH => lkfcp
〔key: 19〕DCXUH => kjebo
〔key: 20〕DCXUH => jidan
〔key: 21〕DCXUH => ihczm
〔key: 22〕DCXUH => hgbyl
〔key: 23〕DCXUH => gfaxk
〔key: 24〕DCXUH => fezwj
〔key: 25〕DCXUH => edyvi
 */