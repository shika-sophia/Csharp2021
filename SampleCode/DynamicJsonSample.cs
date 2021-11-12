/** 
 *@title CsharpBegin / SampleCode / DynamicJsonSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 11.3.3 dynamic JSON / p558 / List 11-20
 *@subject JSON: JavaScript Object Notation
 *         JSON形式のデータを解析。
 *         本来は静的データ(= 固定データ)ではなく、
 *         WebClientなどで取得した JSONデータを引数として解析する。
 *
 *         ◆Codeplex.Data.DynamicJsonクラス
 *         dynamic DynamicJson.Parse(string json)
 *         
 *         ＊値の取得
 *         dynamic json = DynamicJson.Parse(string json);
 *         文字列: json.xxxx (xxxx: key文字列)
 *         数値  : json["xxxx"] (xxxx: key文字列)
 *         変数値: json.xxxx.vvvv (xxxx: key文字列, vvvv: 変数名)
 *         配列  : jason[int index] 
 *         
 *         ＊メソッド
 *         bool json.IsDefined(string key)
 *           keyが存在しないと例外発生するので if文でチェック
 *         
 *@prepare ◆DynamicJsonライブラリをインストール
 *         https://github.com/neuecc/DynamicJson
 *         PM> Install-Package DynamicJson
 *         => プロジェクト直下のパッケージとして入り、
 *            packages.configも追加。
 *         
 *@author shika 
 *@date 2021-11-12 
*/
using Codeplex.Data;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class DynamicJsonSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            dynamic json = DynamicJson.Parse(
                @"{""title"": ""速習C#"",
                   ""min-price"": 1000,
                   ""sample"": {""dl"": true},
                   ""author"": [""山田太郎"", ""鈴木次郎""]"
            );

            Console.WriteLine($"Title: {json.title}");
            Console.WriteLine($"Price: {json[@"min-price"]}");
            Console.WriteLine($"dl値 : {json.sample.dl}");
            Console.WriteLine($"Author: {json.author[1]}");
            //Console.WriteLine($"Book: {json.book}");
            //ハンドルされていない例外:
            //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
            //'Codeplex.Data.DynamicJson' に 'book' の定義がありません

            if (json.IsDefined("book"))
            {
                Console.WriteLine($"Book: {json.book}");
            }
            else
            {
                Console.WriteLine(@"Book: <!> JSONに Key:""book""がありません。");
            }
        }//Main() 
    }//class 
}

/*
【実行結果】
Title: 速習C#
Price: 1000
dl値 : True
Author: 鈴木次郎
Book: <!> JSONに Key:"book"がありません。

【参考】NuGetによるインストール時のログ
PM> Install-Package DynamicJson

'.NETFramework,Version=v4.8' を対象とするプロジェクト 'CsharpBegin' に関して、
パッケージ 'DynamicJson.1.2.0' の依存関係情報の収集を試行しています
依存関係情報の収集に 8 ms かかりました
DependencyBehavior 'Lowest' でパッケージ 'DynamicJson.1.2.0' の依存関係の解決を試行しています
依存関係情報の解決に 0 ms かかりました
パッケージ 'DynamicJson.1.2.0' をインストールするアクションを解決しています
パッケージ 'DynamicJson.1.2.0' をインストールするアクションが解決されました
'nuget.org' からパッケージ 'DynamicJson 1.2.0' を取得しています。
  GET https://api.nuget.org/v3-flatcontainer/dynamicjson/1.2.0/dynamicjson.1.2.0.nupkg
  OK https://api.nuget.org/v3-flatcontainer/dynamicjson/1.2.0/dynamicjson.1.2.0.nupkg 78 ミリ秒
コンテンツ ハッシュ ZJNGswa6RqEq+5VdYY5aciiOoG0nLhlpW3XvFJ3/3kdCc+6b3lCwHPay+t/n5zgisX4iqccPq8taxwXahuUc1w== の
https://api.nuget.org/v3/index.json から DynamicJson 1.2.0 がインストールされました。
パッケージ 'DynamicJson.1.2.0' を
フォルダー 'C:\Users\sophia\source\repos\CsharpBegin\packages' に追加しています
パッケージ 'DynamicJson.1.2.0' を
フォルダー 'C:\Users\sophia\source\repos\CsharpBegin\packages' に追加しました
パッケージ 'DynamicJson.1.2.0' を 'packages.config' に追加しました
'DynamicJson 1.2.0' が CsharpBegin に正常にインストールされました
NuGet の操作の実行に 1.06 sec かかりました
経過した時間: 00:00:02.6759864
PM> 

 */