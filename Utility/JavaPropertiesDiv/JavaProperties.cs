/** 
 *@title CsharpBegin / Utility / JavaPropertiesDiv / JavaProperties.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference DJ 山田祥寛『独習 Java [新版] 』 翔泳社, 2019 
 *@content JavaProperties
 *         [Java] Propertiesクラスと同様の動作を [C#]で自己定義
 *
 *@subject 〔DJ 172〕[Java] java.util.Properties extends Hashtable<K,V>
 *          void load(InputStream)
 *          void load(Reader)
 *          void loadFreomXML(InputStream)
 *          void store(OutputStream, string header)
 *          void list(PrintStream / PrintWriter)
 *          String getProperty(string key [, string default])
 *          void   setProperty(string key, string value)
 *          
 *@subject [C#] CsharpBegin / Utility / JavaPropertiesDiv / JavaProperties.cs
 *         (thisクラスを自己定義)
 *         / - Dictionary<string,string> dic
 *           - char[] separateAry /
 *         + JavaProperties() //separator = '='
 *         + JavaProperties(char[] separateAry) 
 *         + void SetDictionary(string key, string value)
 *         + string GetValue(string key)
 *         + void Reset()
 *         + string ToStringAll(string header)
 *         + string SeekFile()
 *         + string SeekDirectory(out string fileName)
 *         + void Store(string dir, string fileName, string header)
 *         + void Load(string dir, string fileName)
 *                  
 *@author shika 
 *@date 2022-04-10 
*/

using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.IO; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Utility.JavaPropertiesDiv 
{ 
    public class JavaProperties 
    { 
        private Dictionary<string,string> dic; 
        private char[] separateAry; 
 
        public JavaProperties() 
        { 
            this.dic = new Dictionary<string, string>(); 
            this.separateAry = new char[] { '=' }; 
        } 
 
        public JavaProperties(char[] separateAry) : this() 
        { 
            this.separateAry = separateAry; 
        } 
 
        public void SetDictionary(string key, string value) 
        { 
            dic.Add(key, value); 
        } 
 
        public string GetValue(string key) 
        { 
            if (dic.TryGetValue(key ,out string value)) 
            { 
                return value; 
            } 
            else 
            { 
                throw new ArgumentException( 
                    $"<!> [{key}] Not Found in the dictionary."); 
            } 
        }//GetValue() 
 
        public string ToStringAll(string header) 
        { 
            var bld = new StringBuilder(dic.Count * 20); 
            bld.Append($"# {header}\n"); 
 
            foreach(KeyValuePair<string,string> pair in dic) 
            { 
                bld.Append($"{pair.Key} = {pair.Value}\n"); 
            }//foreach 
 
            return bld.ToString(); 
        }//ToStringAll() 

        public string SeekFile()
        {
            StackTrace trace = new StackTrace(true);
            StackFrame frame = trace.GetFrame(trace.FrameCount - 1); //static Main()          
            return frame.GetFileName();
        }//SeekFile() 

        public string SeekDirectory(out string fileName)
        {
            string thisFileName = SeekFile();
            string dir = thisFileName.Substring(0, thisFileName.LastIndexOf("\\"));
                
            fileName = thisFileName
                .Substring(thisFileName.LastIndexOf("\\") + 1); //先頭の「\」を除去

            return dir;
        }
        public void Load(string dir, string fileName) 
        {
            string path = $"{dir}\\{fileName}";
            try 
            { 
                using (var reader = new StreamReader(path)) 
                { 
                    while (!reader.EndOfStream) 
                    { 
                        string line = reader.ReadLine();

                        if (line.StartsWith("#") || String.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        if (TryDevideKeyValue(line, out string key, out string value)) 
                        {                     
                            SetDictionary(key, value); 
                        } 
                        else 
                        { 
                            throw new InvalidDataException( 
                                $"<!> [{fileName}] is invalid data as property form."); 
                        } 
                    }//while 
                     
                    reader.Close(); 
                }//usimg 
            } 
            catch (IOException e) 
            { 
                Console.WriteLine(e.Message); 
            } 
        } 
 
        private bool TryDevideKeyValue( 
            string line, out string key, out string value) 
        {            
            string[] devided = line.Split(
                separateAry, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine($"devided.Length = {devided.Length}");
            if (devided.Length == 2) 
            { 
                key = devided[0]; 
                value = devided[1]; 
                return true; 
            } 
 
            key = ""; 
            value = ""; 
            return false; 
        }//TryDevideKeyValue() 
 
        public void Store(string dir, string fileName, string header) 
        {
            string path = $"{dir}\\{fileName}";
            try 
            { 
                using(var fs = new FileStream(path, FileMode.Create)) 
                using(var writer = new StreamWriter(fs)) 
                {  
                    string content = ToStringAll(header); 
                    writer.WriteLine(content); 
 
                    writer.Close(); 
                }//using  
            } 
            catch (IOException e) 
            { 
                Console.WriteLine(e.Message); 
            } 
        }//Store() 

        private void Reset()
        {
            dic.Clear();
        }

        //==== Test Main() ====
        //static void Main(string[] args) 
        ////public void Main(string[] args) 
        //{
        //    var here = new JavaProperties();
        //
        //    //==== Test SetDictionary(), GetValue(), ToStringAll() ====
        //    here.SetDictionary("Alice", "Alaska");
        //    here.SetDictionary("Bobby", "Brazil");
        //    Console.WriteLine($"Alice = {here.GetValue("Alice")}");
        //    Console.WriteLine(here.ToStringAll("Test Main()"));

        //    //==== Test SeekFile(), SeekDirectory() ====
        //    string thisFileName = here.SeekFile();
        //    string dir = SeekDirectory(out string fileName);
        //
        //    //==== Teat Store() ====
        //    string saveFileName = "saveSample.txt";          
        //    here.Store(dir, saveFileName, saveFileName);

        //    //==== Test Reset(), Load() ====
        //    here.Reset();
        //    string loadFileName = "loadSample.txt";
        //    here.Load(dir, loadFileName);
        //    Console.WriteLine(here.ToStringAll(loadFileName));
        //}//Main() 
    }//class 
}

/*
Alice = Alaska

# Test Main()
Alice = Alaska
Bobby = Brazil

//==== Test SeekFile(), SeekDirectory() ====
dir = C:\Users\xxxxx\source\repos\CsharpBegin\CsharpBegin\Utility\JavaPropertiesDiv
fileName = JavaProperties.cs

# saveJavaProperties.txt
Alice = Alaska
Bobby = Brazil

# loadSample.txt
JP  =  Japan
US  =  United States of Amerika
UK  =  United Kingdom
UR  =  Ukraine
RS  =  Russia 
 */
