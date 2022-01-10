/** 
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock / ReadWrite / MainReadWrite.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MainReadWrite
 * 
 *@author shika 
 *@date 2022-01-10 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite 
{ 
    class MainReadWrite 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            AbsReadWrite lockRW = new ReadWriteLock();
            var data = new DataMT06(bufferSize: 10, lockRW);

            var readerAry = new ReadThreadMT06[6];
            for (int i = 0; i < readerAry.Length; i++)
            {
                readerAry[i] = new ReadThreadMT06($"reader{i}", data);
                new Thread(readerAry[i].Run).Start();
            }//for

            var writer1 = new WriteThreadMT06(data, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            var writer2 = new WriteThreadMT06(data, "abcdefghijklmnopqrstuvwxtz");
            new Thread(writer1.Run).Start();
            new Thread(writer2.Run).Start();
        }//Main() 

        
    }//class 
} 
