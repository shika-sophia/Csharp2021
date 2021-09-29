/**
 * @title CsharpBegin / A00_Template / MainExecute.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content MainExecute
 *   VS仕様で static Main()は１つのみなので、
 *   各クラスは internal Main()とコメントアウトで切替して利用中。
 *   
 *   DirectoryInfoで プロジェクト内のファイルを検索し、
 *   最新更新ファイルをインスタンス化。
 *   internal Main()を呼び出して実行するプログラム。
 *       
 * @refernce ◆Microsoft Document / Type.GetMethod メソッド
 *   https://docs.microsoft.com/ja-jp/dotnet/api/system.type.getmethod?view=net-5.0#System_Type_GetMethod_System_String_System_Int32_System_Reflection_BindingFlags_System_Reflection_Binder_System_Reflection_CallingConventions_System_Type___System_Reflection_ParameterModifier___
 *   
 *   public System.Reflection.MethodInfo
 *   GetMethod (string name, [int genericParameterCount,]
 *     System.Reflection.BindingFlags bindingAttr,
 *     System.Reflection.Binder? binder,
 *     [System.Reflection.CallingConventions callConvention,]
 *     Type[] types,
 *     System.Reflection.ParameterModifier[]? modifiers);
 *   
 * @author shika
 * @date 2021-09-28
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
            StringBuilder bld = new StringBuilder();
            int fileCount = 0;

            foreach(DirectoryInfo info in dirAry)
            {
                bld.Append("◆" + info + "\n");

                if(info.Name.Equals("SampleCode") || info.Name.Contains("Template"))
                {
                    FileInfo[] fileAry = info.GetFiles();
                    foreach (FileInfo file in fileAry)
                    {
                        bld.Append($"  └ [{fileCount}] {file} \n");
                        fileCount++;

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
            Console.WriteLine("lastFile: " + lastFile.Name);
            Console.WriteLine();

            if (lastFile.Name.Contains(nameof(MainExecute)))
            {
                Console.WriteLine(bld.ToString());
                Console.WriteLine("実行できません。");
                Console.WriteLine("実行するFileを選んでください。");
            }
            //本来は else句に配置
            string lastDir = MakeLastDir(lastFile);
            string useClass = lastDir + lastFile.Name.Replace(".cs", "");
            Type exeClass = Type.GetType(useClass);
            Console.WriteLine(exeClass);

            object instance = Activator.CreateInstance(exeClass);
            Console.WriteLine(instance.ToString());
            
            MethodInfo main = exeClass.GetMethod(
                "Main", BindingFlags.NonPublic, null, 
                new[] { typeof(string[]) }, new ParameterModifier[] { });
            Console.WriteLine(main.ToString());
            main.Invoke(instance, args);
        }//Main()

        private static string MakeLastDir(FileInfo lastFile)
        {
            string lastDir = lastFile.DirectoryName;
            lastDir = lastDir.Substring(lastDir.LastIndexOf("CsharpBegin"))
                .Replace("\\",".") + ".";
            
            return lastDir;
        }//MakeLastDir
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
lastFile: C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\A00-Template\MainExecute.cs
lastFile: MainExecute.cs

◆A00-Template
  └ [0] DateTimeTemplate.cs
  └ [1] MainExecute.cs
  └ [2] MainTemplate.cs
  └ [3] RegexTemplate.cs
◆bin
◆Data
◆obj
◆Properties
◆SampleCode
  └ [4] BigIntegerSample.cs
  └ [5] ComparerSample.cs
  └ [6] ConcatString.cs
  └ [7] ConstructorSample.cs
  └ [8] DictionarySample.cs
  └ [9] DisposeSample.cs
  └ [10] FileDirectorySample.cs
  └ [11] GoToSample.cs
  └ [12] HelloName.cs
  └ [13] LinkedListSample.cs
  └ [14] ListSample.cs
  └ [15] MathSample.cs
  └ [16] MulitiplyMatrix.cs
  └ [17] PreprocesserDirectiveSample.cs
  └ [18] QueueSample.cs
  └ [19] SetSample.cs
  └ [20] SingletonSample.cs
  └ [21] SortedDictionarySample.cs
  └ [22] SortedSetSample.cs
  └ [23] StackSample.cs
  └ [24] StreamWriterReaderSample.cs
  └ [25] StringFormatSample.cs
  └ [26] StringSample.cs
  └ [27] StringSearchSample.cs
  └ [28] StringTreatSample.cs
◆Debug
◆Release
◆Debug
◆Release
◆TempPE

実行できません。
実行するFileを選んでください。
CsharpBegin.A00_Template.MainExecute

【考察】exeClassで System.NullReferenceExceptionが発生。
path違いで ClassNotFoundの可能性もある。
=> GetType(namespace + fileName)で成功。絶対パスではなく、
usingで使う クラスの完全修飾名なので、区切り文字は「.」
    Type.GetType(
        "CsharpBegin.A00_Template." +
        lastFile.Name.Replace(".cs", ""));

【考察】main.Invoke(instance, args);
System.NullReferenceException: 
    オブジェクト参照がオブジェクト インスタンスに設定されていません。
対象オブジェクト mainが nullの様子。
GetMethod()は publicのメソッドのみを抽出するので、
internal Main()は抽出できず、nullとなる。

そこで、GetMethod()引数、BindingFlags.NonPiblicを利用するも、
引数 Binderが抽象クラスのため扱えず nullを代入。
結果は上記と同様。
 */
