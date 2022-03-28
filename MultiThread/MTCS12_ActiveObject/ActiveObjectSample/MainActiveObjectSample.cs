/** 
 *@title CsharpBegin / MultiThread / MTCS12_ActiveObject / ActiveObjectSample / MainActiveObjectSample.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第12章 Active Object / サンプル１ / p392 / List 12-1 ～ 12-15
 *
 *
 *@class MainActiveObjectSample
 *@class ActiveObjectFactory
 *@class AbsActiveObjectMT12
 *         └ ProxyMT12 : AbsActiveObjectMT12
 *         └ ServerMT12 : AbsActiveObjectMT12
 *@class AbsMethodRequest
 *         └ MakeStringRequest : AbsMethodRequest
 *         └ DisplayStringRequest : AbsMethodRequest
 *@class AbsResultMT12<T>
 *         └ FutureResult<T> : AbsResultMT12<T>
 *         └ RealResult<T> : AbsResultMT12<T>
 * 
 *@author shika 
 *@date 2022-03-27 
*/
using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample 
{ 
    class MainActiveObjectSample 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            AbsActiveObjectMT12 activeObj = 
                ActiveObjectFactory.CreateActiveObject();

            var maker1 = new MakerThreadMT12("Alice", activeObj);
            var maker2 = new MakerThreadMT12("Alice", activeObj);
            var display = new DisplayThreadMT12("Chris", activeObj);

            var thMaker1 = new Thread(maker1.Run);
            thMaker1.Name = maker1.GetName();
            thMaker1.Start();

            var thMaker2 = new Thread(maker2.Run);
            thMaker2.Name = maker2.GetName();
            thMaker2.Start();

            var thDisplay = new Thread(display.Run);
            thDisplay.Name = display.GetName();
            thDisplay.Start();

        }//Main() 
 
    }//class 
} 
