/**
 * @title CsharpBegin / A00-Template / MainExecute.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content MainExecute
 *   VS仕様で static Main()は１つのみなので、
 *   各クラスは internal Main()とコメントアウトで切替して利用中。
 *   
 *   DirectoryInfoで プロジェクト内のファイルを検索し、
 *   最新更新ファイルをインスタンス化。
 *   internal Main()を呼び出して実行するプログラム。
 *       
 * @author shika
 * @date 2021-09-25
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.A00_Template
{
    class MainExecute
    {
        static void Main(string[] args)
        //internal void Main(string[] args)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\";
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            DirectoryInfo[] dirAry = dirInfo.GetDirectories("*", SearchOption.AllDirectories);
            DateTime lastTime = new DateTime(1, 1, 1, 0, 0, 0);
            FileInfo lastFile = null;

            foreach(DirectoryInfo info in dirAry)
            {
                Console.WriteLine("◆" + info);
                if(info.Name.Equals("SampleCode") || info.Name.Contains("Template"))
                {
                    FileInfo[] fileAry = info.GetFiles();
                    foreach (FileInfo file in fileAry)
                    {
                        Console.WriteLine("  └ " + file);

                        DateTime tempLastTime = file.LastWriteTime;
                        if (lastTime <= tempLastTime)
                        {
                            lastTime = tempLastTime;
                            lastFile = file;
                        }
                    }//foreach fileAry
                }//if
            }//foreach dirAry

            Console.WriteLine("lastFile: " + lastFile.FullName);
            Type exeClass = Type.GetType(lastFile.Name);

            //【註】exeClassで System.NullReferenceExceptionが発生
            //Console.WriteLine(exeClass.ToString());
            //object instance = Activator.CreateInstance(exeClass);

            //MethodInfo main = exeClass.GetMethod("Main", new[] { typeof(string[]) });
            //main.Invoke(instance, new object[] { args });
        }//Main()
        
    }//class
}

/*
◆//using System.Diagnostics;
    StackTrace st = new StackTrace();
    Console.WriteLine(st.ToString());
    Console.WriteLine(st.GetType());

    //Class.Main(args); //internal Main()を呼出
＊st.ToString()
場所 CsharpBegin.A00_Template.
MainExecute.MainTemplate.Main(String[] args)

＊st.GetType()
System.Diagnostics.StackTrace

//---- DirectoyInfo.GetDirectories() ----
◆A00-Template
  └ DateTimeTemplate.cs
  └ MainExecute.cs
  └ MainTemplate.cs
  └ RegexTemplate.cs
◆bin
◆Data
◆obj
◆Properties
◆SampleCode
  └ BigIntegerSample.cs
  └ ComparerSample.cs
  └ ConcatString.cs
  └ ConstructorSample.cs
  └ DictionarySample.cs
  └ DisposeSample.cs
  └ FileDirectorySample.cs
  └ GoToSample.cs
  └ HelloName.cs
  └ LinkedListSample.cs
  └ ListSample.cs
  └ MathSample.cs
  └ MulitiplyMatrix.cs
  └ PreprocesserDirectiveSample.cs
  └ QueueSample.cs
  └ SetSample.cs
  └ SingletonSample.cs
  └ SortedDictionarySample.cs
  └ SortedSetSample.cs
  └ StackSample.cs
  └ StreamWriterReaderSample.cs
  └ StringFormatSample.cs
  └ StringSample.cs
  └ StringSearchSample.cs
  └ StringTreatSample.cs
◆Debug
◆Release
◆Debug
◆Release
◆TempPE

lastFile:
C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\
SampleCode\FileDirectorySample.cs
 */
