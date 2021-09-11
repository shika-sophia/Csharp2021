/**
 * @title CsharpBegin / SampleCode / DisposeSample
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章　オブジェクト指向 基本 / p275
 *          ◆Dispose(): usingブロックを抜けると呼び出されるメソッド
 *            GC.SuppressFinalize(object);
 *       
 * @author shika
 * @date 2021-09-11
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class DisposeSample : IDisposable
    {
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //マネージドリソースの解放処理
            }

            //アンマネージドリソースの解放処理
            disposed = true;
        }//Dispose(bool)

        //デストラクタ
        ~DisposeSample()
        {
            Dispose(false);
        }
    }//class
}
