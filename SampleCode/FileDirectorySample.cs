/**
 * @title CsharpBegin / SampleCode / FileDirectorySample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ File / p197 / List 5-44 ～
 *   ◆System.IO.FileInfo
 *   new FileInfo(string filePath);
 *   string fileInfo.Name
 *   bool fileInfo.Exists
 *   string fileInfo.DirectoryName
 *   bool fileInfo.IsReadOnly
 *   DateTime fileInfo.LastAccessTime
 *   DateTime fileInfo.LastWriteTime
 *   long fileInfo.Length
 *   FileInfo fileInfo.CopyTo(string forFileName, bool overwrite);
 *   void fileInfo.MoveTo(string forFileName)
 *   void fileInfo.Delete();
 *   
 *   ◆System.IO.DirectoryInfo
 *   new DirectoryInfo(string dir);
 *   string dirInfo.Name     //そのディレクトリのみ
 *   string dirInfo.FullName //ルートからの全ディレクトリ
 *   bool dirInfo.Exists
 *   DirectoryInfo dirInfo.Parent
 *   DirectoryInfo dirInfo.Root
 *   DateTime dirInfo.CreationTime
 *   DateTime dirInfo.LastAccessTime
 *   DateTime dirInfo.LastWriteTime
 *   DirectoryInfo[] dirInfo.GetDirectories(); サブディレクトリ一覧を取得
 *   DirectoryInfo[] dirInfo.GetDirectories(string search, SeachOption);
 *       seach: "Chap*", "*"など
 *       SearchOpton.AllDirectories 直下だけでなく、配下の全ディレクトリを検索
 *   void dirInfo.Create()
 *   DirectoryInfo dirInfo.CreateSubdirectory(string name);
 *   void dirInfo.MoveTo(string forFileName);
 *   void dirInfo.Delete([bool]) 
 *       //false(既定値): 配下にファイル/ディレクトリが存在する場合 IOException
 *       //true: 配下のファイル/ディレクトリごと削除
 *       
 *   ◆static File / Directoryクラス
 *   
 * @author shika
 * @date 2021-09-24
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class FileDirectorySample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\";
            string fileName1 = @"iroha.txt";

            var fileInfo = new FileInfo(dir + fileName1);
            Console.WriteLine(fileInfo.Name);
            Console.WriteLine(fileInfo.Exists);
            Console.WriteLine(fileInfo.DirectoryName);
            Console.WriteLine(fileInfo.IsReadOnly);
            Console.WriteLine(fileInfo.LastAccessTime);
            Console.WriteLine(fileInfo.LastWriteTime);
            Console.WriteLine(fileInfo.Length);

            FileInfo copyInfo = fileInfo.CopyTo(dir + "irohaCopy.txt", true);
            //copyInfo.MoveTo(dir + "irohaRename.txt");
            //copyInfo.Delete();

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Console.WriteLine(dirInfo.Name);
            Console.WriteLine(dirInfo.Exists);
            Console.WriteLine(dirInfo.Parent);
            Console.WriteLine(dirInfo.Root);
            Console.WriteLine(dirInfo.CreationTime);
            Console.WriteLine(dirInfo.LastAccessTime);
            Console.WriteLine(dirInfo.LastWriteTime);
           
            DirectoryInfo dirSub = dirInfo.CreateSubdirectory("Sub");
            DirectoryInfo[] dirAry = dirInfo.GetDirectories();
            foreach(DirectoryInfo dirInfoBit in dirAry)
            {
                Console.WriteLine(dirInfoBit.FullName);
            }
            dirSub.Delete();
        }//Main()
    }//class
}

/*
iroha.txt
True
C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data
False
2021/09/23 18:27:28
2021/09/23 17:52:50
112
Data
True
CsharpBegin
C:\
2021/09/23 17:11:12
2021/09/24 20:31:54
2021/09/24 20:13:34
C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\Sub
 */