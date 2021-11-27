/** 
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap08.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第８章 オブジェクト指向 / p341, p366, p380
 *@subject 練習問題 8-1 カプセル化, 8-2 継承, ポリモーフィズム
 *@subject 章末問題
 *
 *@author shika 
 *@date 2021-11-27 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-27 (土) 
 *@time: 04:00 ～ 04:19 (19分) 
 *@rate: 100.00％ (○ 17 問 / 全 17 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Exercise.SelfLearnCS 
{ 
    class SelfLearnChap08 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
}
/* 
2021-11-27 (土)
==== Exercise Result ==== 
◆〔1〕第８章 オブジェクト指向 / 練習問題 8-1 カプセル化 
○ (1) アクセス修飾子: クラスやメンバーにアクセスできる権限を制限して、 
○ (2) お互いの依存関係をなくしておくのは、変更時などの保守性や可読性にとって重要。 
○ (3) カプセル化: 必要のない限り、外部には公開せずに、それが必要なメンバー内で共有すればいいという考え方。 
○ (4) 特にフィールド/プロパティは、クラスの状態を左右するので、 
○ (5) 外部には公開せず、また値の取得 getは公開しても、 
○ (6) 値の変更 setは　privateにしておく。 
○ (7) クラス間の依存関係を必要最小限にすることで、保守性、変更時の修正が容易になる。
    => 【フィールド/プロパティの利点】
    *   クラス内で値を共有できる。
    *   読み書きの制御が可能。
    *   フィールド値を設定する際に、検証可。
    *   フィールド値を取得する際に、加工可。

◆〔2〕8-2 継承 
○ (1) メソッドのオーバーライド: virtual, override, sealed 
○ (2) メソッドの隠蔽: new 
○ (3) 隠蔽は new修飾子によって、同名同シグニチャのメンバーを再定義することだが、 
○ (4) 継承関係がないので、対象オブジェクトによって、呼び出すメソッドを自動的に切り替えるという 
○ (5) ポリモーフィズムの利点を活かせないので、隠蔽newは利用すべきではない。
    => 【隠蔽とオーバーライド】
    *   隠蔽は派生クラスで new するだけで済む。
    *   隠蔽は、ほぼ全てのメンバーで可。
    *   隠蔽でポリモーフィズムの性質は無効になる。
    *   オーバーライドは virtual, overrideで、あらかじめ想定していないとできない。
    *   オーバーライドは メソッド、プロパティ、インデクサーのみ
    *   
○ (6) 2. BusinessMan : Man / StudentMan : Manのとき 
○ (7) Man = new BusinessMan ○ 
○ (8) BusinessMan bm = (BusinessMan) man; ○ 
○ (9) StrudentMan sm = (StudentMan) man; △実行時に例外 
○ (10) StudentMan sm2 = (StudentMan) bm; ×コンパイルエラー/継承関係がない 
*/
/*==== Appendix ==== 
 *@date: 2021-11-27 (土) 
 *@time: 04:00 ～ 04:19 (19分) 
 *@rate: 100.00％ (○ 17 問 / 全 17 問) 
*/
/*
◆〔4〕４
◇Answer: [-99: QuestEnd] [-88: Return]
(1) -99
<!> 終了機能は利用できません。
(1) -88
<!> Return機能は利用できません。
(1) ３続き 「~」はデストラクタ、削除する。
(2) Intro()内 $" {Name} {Age}"
(3) ４．this.
(4) virtual
(5) : MyClass
(6) : base(value)
(7) override
(8) GetValue()
(9) { base.value.ToString("F1") }
(10) -99
<?> Answer(9)で終了します。
終了 よろしいですか？ [ Y / N ]: y

==== Judge Correct ====
◇正誤入力: [0: ○ ] [1: × ] [-88: Return]
◆〔1〕章末問題 １
(1) × sub -> superの呼出は base.Xxxx()を利用。: 0
(2) × virtualのないものを newすることは可: 0
(3) × sealedは最初から可。virtualとの併用は矛盾するので不可。: 1
 => ○: 再定義したくなければ virtualをつけなければいい。
(4) × is演算子の説明。/ asはキャストする型を示す 演算子。: 0
(5) × sub : super, Iinterface1, Iinterface2は可。: 0

◆〔2〕２
(1) 拡張メソッド: 0
(2) public static ToTitleCase(this string str){: 0

◆〔3〕３
(3)    return str.Substring(0,1).ToUpper + str.Substring(1); }: 1
 => ○: str.Substring(1).ToLower()

◆〔4〕４
(1) Name -> Name { get; private set; };: 0
(2) public int _age; -> private int _age;: 0
(3) Age.set{ }内、int value不要: 0
    => setも private set{ }

(4) if内 valueは readonly 暗黙オブジェクト?: 1
 => ○: valueは、プロパティに渡された値を格納する予約変数。
       readonlyは ウソ。


(5) _age = 0;でいい。: 1
 => valueに代入可なので題意と通りでいい

◆〔5〕５
    => コンストラクタに戻り値不可 void削除
(1) ３続き 「~」はデストラクタ、削除する。: 0
(2) Intro()内 $" {Name} {Age}": 0

(3) ４．this.: 0
(4) virtual: 0
(5) : MyClass: 0
(6) : base(value): 0
(7) override: 0
(8) GetValue(): 0
(9) { base.value.ToString("F1") }: 1
 => ○: { base,GetValue() }

◆〔5〕５
◇Answer: [-99: QuestEnd] [-88: Return]
 => interface内に public 不可
    *  interface内に abstract 不可
(1) implemants -> javaの表記、「:」でいい :0
(2) Hamster内の Name不要: 1 
    => ○ public 
    *  protected クラスを継承している場合のみ
(3) Move override不要 : 0
    => interfaceの実装なので

(4) Main()内 i.Name = "サクラ";
    => Name = "サクラ";
*/
/*
【考察】途中でコレクションの indexオーバーで例外発生
２つ分、Returnしたのが原因かも。
○×付ける際の、段落のまとまりもおかしい。
=> 要バグ対応。

 */
