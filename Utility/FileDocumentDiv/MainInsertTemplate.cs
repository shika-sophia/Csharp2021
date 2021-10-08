using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.FileDocumentDiv
{
    class MainInsertTemplate
    {
        //static void Main(string[] args)
        //{
        //    new InsertDocument("").InsertExe();
        //}
    }//class
}

/*
System.IO.IOException:  別のプロセスで使用されているため、
プロセスはファイル 'C:\Users\sophia\source\repos\CsharpBegin
\CsharpBegin\Utility\FileDocumentDiv\MainInsertTemplate.cs' 
にアクセスできません。

【考察】
VSで開いている状態なので、アクセス不可なのか。
以前、Data\iroha.txtでは Reader/Writerができたので、
これはないはず。

 */
