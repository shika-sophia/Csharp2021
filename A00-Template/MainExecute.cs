using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
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
