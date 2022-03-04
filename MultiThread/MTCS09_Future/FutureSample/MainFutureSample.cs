/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / FutureSample / MainFutureSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第９章 Future / p296 / List 9-1 ～ 9-5
 *         戻り値のある非同期実行プログラムを Threadクラスを用いて実装
 *         (非同期実行の専用クラス )
 *         ([Java] Callable<T> / [C#] Task<T>は別フォルダ)
 *
 *content || Future ||
 *        ＊Client = Main
 *          Hostに Request()を依頼、戻り値 VirtualData
 *        ＊Host
 *          || Thread per Message ||
 *          Request()を受けると new Threadを生成し、RealDataの生成開始
 *          RealDataの生成には時間が掛かるので、
 *          戻り値は VirtualDataを即座に返し、Mainに制御を戻す。
 *        ＊VirtualData = AbsDataMT09
 *          FutureData, RealDataを同一視
 *        ＊Future 
 *          RealDataの「引換券」として Hostから Mainに発行される戻り値
 *          || Balking || RealDataが完成するまではキャンセル
 *          
 *        ＊RealData
 *          実際のデータ。Request()されてから生成まで時間が掛かるので、
 *          new Thread内で生成。
 */
#region -> FutureSample / Class Chart
/*
 *@class MainFutureSample
 *       //
 *       ◆Main()
 *       new HostMT09()
 *       ---- Request ----
 *       AbsDataMT09 data1 = host.RequestData(int count, char c)
 *       ---- Another Job ----
 *       ---- Result ----
 *       string data1.GetResult()
 *
 *@class HostMT09
 *       //
 *       + AbsDataMT09 RequestData(int count, char c)
 *       { new FutureData() //仮の戻り値
 *         new Thread (() => 
 *         { RealData realData = new RealData(int count, char c)
 *           future.SetRealData(realData); }
 *       }
 *              
 *@class AbsDataMT09
 *       abstract string GetResult()
 *       
 *@class FutureData : AbsDataMT09
 *       / - ◇RealData realData;
 *         - bool readyData; /
 *       + synchronized GetResult()
 *       + synchronized SetRealData(RealData)
 *       
 *@class RealData : AbsDataMT09
 *       / - readOnly string result; /
 *       + RealData(int count, char c)
 *       { this.result // cから生成 }
 *       + string GetResult() { return result; }
 */
#endregion
/*
 *@author shika 
 *@date 2022-03-04 
*/
using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureSample
{
    class MainFutureSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main() BEGIN");
            HostMT09 host = new HostMT09();

            //---- Request ----
            AbsDataMT09 data1 = host.RequestData(10, 'A');
            AbsDataMT09 data2 = host.RequestData(20, 'B');
            AbsDataMT09 data3 = host.RequestData(30, 'C');

            //---- Another job ---
            Console.WriteLine("Main() AnotherJob BEGIN");
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException) { }
            Console.WriteLine("Main() AnotherJob END");

            //---- Get Result ----
            Console.WriteLine($"data1 = {data1.GetResult()}");
            Console.WriteLine($"data2 = {data2.GetResult()}");
            Console.WriteLine($"data3 = {data3.GetResult()}");

            Console.WriteLine("Main() END");
        }//Main() 
    }//class 
}

/*
Main() BEGIN
  RequestData(10, A) BEGIN
  RequestData(10, A) END    <= RequestData()は すぐに終了(戻る)
  RequestData(20, B) BEGIN
    making RealData(10, A) BEGIN <= RealDataを作成開始
  RequestData(20, B) END
  RequestData(30, C) BEGIN
  RequestData(30, C) END
Main() AnotherJob BEGIN     <= Mainで 別作業開始
    making RealData(20, B) BEGIN
    making RealData(30, C) BEGIN
    making RealData(10, A) END <= data1 作成完了
Main() AnotherJob END       <= Mainで 別作業終了
data1 = AAAAAAAAAA          
    making RealData(20, B) END
data2 = BBBBBBBBBBBBBBBBBBBB   <= data2 作成完了まで待機
    making RealData(30, C) END
data3 = CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
Main() END
 */