/** 
 *@title CsharpBegin / LocalHost / HttpListenerSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference Web『プログラミングC#』, 2014
 *           ローカルで使うWebサーバーを立てる
 *           https://yryr.me/programming/local-http-server.html
 *           => @see HttpListenerReference.txt
 *           
 *@content HttpListenerSample
 *
 *@see HttpListenerReference.txt
 *@author shika 
 *@date 2022-02-24 
*/
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.LocalHost 
{ 
    class HttpListenerSample 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            //---- C# Web Server ----
            var listener = new HttpListener();
            listener.Prefixes.Add("https://localhost:8888/");
            listener.Start();

            //---- Request, Response ----
            HttpListenerResponse res = null;
            try
            {
                while (true)
                {
                    IAsyncResult result = listener.BeginGetContext(
                        (asyncResult) =>
                        {
                            HttpListener listenerAsync =
                                (HttpListener) asyncResult.AsyncState;
                            HttpListenerContext context =
                                listenerAsync.EndGetContext(asyncResult);
                            HttpListenerRequest req = context.Request;
                            res = context.Response;

                            Console.WriteLine($"Request URL: {req.RawUrl}");
                            
                        }, listener);

                    result.AsyncWaitHandle.WaitOne(500);
                    if(result != null)
                    {
                        break;
                    }
                }//while loop
            }
            finally
            {
                listener.Stop();
                //res.Close();
            }

            //---- File Output ----
            string filePath = @"C:\index.html";

            using(Stream stream = 
                new FileStream(filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
            {
                
                byte[] buffer = new byte[4096];

                for(int count = -1; 
                    (count = stream.Read(buffer, 0, buffer.Length)) != 0; )
                {
                    res.OutputStream.Write(buffer, 0, count);
                }//for
            }//using


        }//Main() 
    }//class 
} 
