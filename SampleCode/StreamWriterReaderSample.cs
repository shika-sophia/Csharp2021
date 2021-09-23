/**
 * @title CsharpBegin / SampleCode / StreamWriterReaderSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ File / p187 / List 5-41 ～
 *   ◆using(オブジェクト生成式){ }
 *   ◆System.IO.StreamWriter
 *   new StreamWriter(
 *       string path, [bool append, [Encoding, [int bufferSize]]]);
 *           Encoding Encoding.UTF-8  //default値(省略時の既定値)
 *           Encoding Encoding.GetEncoding(string); 
 *           Encoding new UTF8Encoding() //BOMなしのUTF-8
 *           
 *   void virtual streamWriter.WriteLine(T)
 *   void File.WriteAllLines(string path, string[])
 *   
 *   ◆System.IO.StreamReader
 *   new StreamReader(
 *       string path, [Encoding, [bool bom, [int bufferSize]]]);
 *   void streamReader.ReadToEnd()
 *   bool streamReader.EndOfStream //while文
 *   void streamReader.ReadLine()  //while文内
 *   
 * @author shika
 * @date 2021-09-23
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class StreamWriterReaderSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\";
            string fileName1 = @"sample.log";
            string fileName2 = @"iroha.txt";

            //---- streamWiter.WriteLine() ----
            using (var writer = new StreamWriter(dir + fileName1, append: true)) 
            {
                writer.WriteLine(DateTime.Now.ToString());
            }//using writer

            //---- File.WriteAllLines() ----
            string[] inputAry = new[] { "2017/12/31/ 23:59:59", "2018/01/01/ 06:15:32" };
            //File.WriteAllLines(dir + fileName1, inputAry);

            //---- streamReader ----
            using(var reader = new StreamReader(dir + fileName2, Encoding.GetEncoding("Shift-JIS")))
            {
                //---- EndOfStream, ReadLine() ----
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }//while
                Console.WriteLine();
            
                //---- ReadToEnd() ----
                Console.WriteLine(reader.ReadToEnd());
            }//using reader

        }//Main()
    }//class
}

/*
//---- streamWiter.WriteLine() ----
2021/09/23 17:39:32
2021/09/23 17:39:57

//---- File.WriteAllLines() ----
【註】引数 appendがなく、上書きされる。
2017/12/31/ 23:59:59
2018/01/01/ 06:15:32

//---- streamReader ----
いろはにほへと
ちりぬるを
わかよたれそ
つねならむ
うゐのおくやま
けふこえて
あさきゆめみし
ゑひもせす

【註】１回読み込むと reader.EndOfStream -> trueとなり、
２回目以降を重複して読み込むことはない。

読み取り専用のため reader.EndOfStream = false;は不可。
 */
