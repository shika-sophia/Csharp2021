/**
 *@title CsharpBegin / Utility / ScanDiv / ConfirmScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content [ Y / N ]で答える確認質問の適正判定
 *  ◆System.Console
 *  ConsoleKeyInfo Console.ReadKey();
 *  ConsoleKey consoleKeyInfo.Key; //下記【参考】
 *  char consoleKeyInfo.KeyChar;
 * 
 *@author shika 
 *@date 2021-10-18 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.ScanDiv
{
    class ConfirmScan
    {
        public bool QuestConfirm(string quest)
        {
            reQuest:
            Console.Write($"{quest} [ Y / N ]: ");
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Console.WriteLine();

            bool isConfirm = false;
            switch (inputKey.KeyChar)
            {
                case 'Y':
                case 'Ｙ':
                case 'y':
                case 'ｙ':
                    isConfirm = true;
                    break;
                case 'N':
                case 'Ｎ':
                case 'n':
                case 'ｎ':
                    isConfirm = false;
                    break;
                default:
                    Console.WriteLine($" {inputKey.KeyChar} は不正な入力です。");
                    Console.WriteLine("[ Y / N ]で入力してください。");
                    Console.WriteLine();
                    goto reQuest;
            }//switch

            return isConfirm;
        }//QuestConfirm()

        //static void Main(string[] args)
        public void Main(string[] args)
        {            
            var here = new ConfirmScan();
            bool isConfirm = here.QuestConfirm("よろしいですか？");
            Console.WriteLine($"isConfirm: {isConfirm}");
        }//Main()
    }//class
}

/*
//====== Result Main() =====
よろしいですか？ [ Y / N ]: y
isConfirm: True

よろしいですか？ [ Y / N ]: Ｎ
isConfirm: False

よろしいですか？ [ Y / N ]: h
hは不正な入力です。
[ Y / N ]で入力してください。

よろしいですか？ [ Y / N ]: 0
0は不正な入力です。
[ Y / N ]で入力してください。

よろしいですか？ [ Y / N ]: (「↑」key)
 は不正な入力です。
[ Y / N ]で入力してください。

よろしいですか？ [ Y / N ]: Ｙ
isConfirm: True

//====== enum ConsoleKey ======
【参考】enum ConsoleKey
#region アセンブリ mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll
#endregion

namespace System
{
    //
    // 概要:
    //     コンソールの標準キーを指定します。
    public enum ConsoleKey
    {
        //
        // 概要:
        //     BackSpace キー。
        Backspace = 8,
        //
        // 概要:
        //     Tab キー。
        Tab = 9,
        //
        // 概要:
        //     Clear キー。
        Clear = 12,
        //
        // 概要:
        //     Enter キー。
        Enter = 13,
        //
        // 概要:
        //     Pause キー。
        Pause = 19,
        //
        // 概要:
        //     Esc キー。
        Escape = 27,
        //
        // 概要:
        //     Space キー。
        Spacebar = 32,
        //
        // 概要:
        //     Page Up キー。
        PageUp = 33,
        //
        // 概要:
        //     Page Down キー。
        PageDown = 34,
        //
        // 概要:
        //     End キー。
        End = 35,
        //
        // 概要:
        //     Home キー。
        Home = 36,
        //
        // 概要:
        //     ←キー。
        LeftArrow = 37,
        //
        // 概要:
        //     ↑キー。
        UpArrow = 38,
        //
        // 概要:
        //     →キー。
        RightArrow = 39,
        //
        // 概要:
        //     ↓キー。
        DownArrow = 40,
        //
        // 概要:
        //     Select キー。
        Select = 41,
        //
        // 概要:
        //     Print キー。
        Print = 42,
        //
        // 概要:
        //     Execute キー。
        Execute = 43,
        //
        // 概要:
        //     Print Screen キー。
        PrintScreen = 44,
        //
        // 概要:
        //     Insert キー。
        Insert = 45,
        //
        // 概要:
        //     Delete キー。
        Delete = 46,
        //
        // 概要:
        //     Help キー。
        Help = 47,
        //
        // 概要:
        //     0 キー。
        D0 = 48,
        //
        // 概要:
        //     1 キー。
        D1 = 49,
        //
        // 概要:
        //     2 キー。
        D2 = 50,
        //
        // 概要:
        //     3 キー。
        D3 = 51,
        //
        // 概要:
        //     4 キー。
        D4 = 52,
        //
        // 概要:
        //     5 キー。
        D5 = 53,
        //
        // 概要:
        //     6 キー。
        D6 = 54,
        //
        // 概要:
        //     7 キー。
        D7 = 55,
        //
        // 概要:
        //     8 キー。
        D8 = 56,
        //
        // 概要:
        //     9 キー。
        D9 = 57,
        //
        // 概要:
        //     A キー。
        A = 65,
        //
        // 概要:
        //     B キー。
        B = 66,
        //
        // 概要:
        //     C キー。
        C = 67,
        //
        // 概要:
        //     D キー。
        D = 68,
        //
        // 概要:
        //     E キー。
        E = 69,
        //
        // 概要:
        //     F キー。
        F = 70,
        //
        // 概要:
        //     G キー。
        G = 71,
        //
        // 概要:
        //     H キー。
        H = 72,
        //
        // 概要:
        //     I キー。
        I = 73,
        //
        // 概要:
        //     J キー。
        J = 74,
        //
        // 概要:
        //     K キー。
        K = 75,
        //
        // 概要:
        //     L キー。
        L = 76,
        //
        // 概要:
        //     M キー。
        M = 77,
        //
        // 概要:
        //     N キー。
        N = 78,
        //
        // 概要:
        //     O キー。
        O = 79,
        //
        // 概要:
        //     P キー。
        P = 80,
        //
        // 概要:
        //     Q キー。
        Q = 81,
        //
        // 概要:
        //     R キー。
        R = 82,
        //
        // 概要:
        //     S キー。
        S = 83,
        //
        // 概要:
        //     T キー。
        T = 84,
        //
        // 概要:
        //     U キー。
        U = 85,
        //
        // 概要:
        //     V キー。
        V = 86,
        //
        // 概要:
        //     W キー。
        W = 87,
        //
        // 概要:
        //     X キー。
        X = 88,
        //
        // 概要:
        //     Y キー。
        Y = 89,
        //
        // 概要:
        //     Z キー。
        Z = 90,
        //
        // 概要:
        //     左 Windows ロゴ キー (Microsoft Natural Keyboard)。
        LeftWindows = 91,
        //
        // 概要:
        //     右 Windows ロゴ キー (Microsoft Natural Keyboard)。
        RightWindows = 92,
        //
        // 概要:
        //     アプリケーション キー (Microsoft Natural Keyboard)。
        Applications = 93,
        //
        // 概要:
        //     コンピューターのスリープ キー。
        Sleep = 95,
        //
        // 概要:
        //     0 キー (テンキー)。
        NumPad0 = 96,
        //
        // 概要:
        //     1 キー (テンキー)。
        NumPad1 = 97,
        //
        // 概要:
        //     2 キー (テンキー)。
        NumPad2 = 98,
        //
        // 概要:
        //     3 キー (テンキー)。
        NumPad3 = 99,
        //
        // 概要:
        //     4 キー (テンキー)。
        NumPad4 = 100,
        //
        // 概要:
        //     5 キー (テンキー)。
        NumPad5 = 101,
        //
        // 概要:
        //     6 キー (テンキー)。
        NumPad6 = 102,
        //
        // 概要:
        //     7 キー (テンキー)。
        NumPad7 = 103,
        //
        // 概要:
        //     8 キー (テンキー)。
        NumPad8 = 104,
        //
        // 概要:
        //     9 キー (テンキー)。
        NumPad9 = 105,
        //
        // 概要:
        //     乗算キー (テンキーの乗算記号キー)。
        Multiply = 106,
        //
        // 概要:
        //     加算キー (テンキーの加算記号キー)。
        Add = 107,
        //
        // 概要:
        //     区切り記号キー。
        Separator = 108,
        //
        // 概要:
        //     減算キー (テンキーの減算記号キー)。
        Subtract = 109,
        //
        // 概要:
        //     小数点キー (テンキーの小数点記号キー)。
        Decimal = 110,
        //
        // 概要:
        //     除算キー (テンキーの除算記号キー)。
        Divide = 111,
        //
        // 概要:
        //     F1 キー。
        F1 = 112,
        //
        // 概要:
        //     F2 キー。
        F2 = 113,
        //
        // 概要:
        //     F3 キー。
        F3 = 114,
        //
        // 概要:
        //     F4 キー。
        F4 = 115,
        //
        // 概要:
        //     F5 キー。
        F5 = 116,
        //
        // 概要:
        //     F6 キー。
        F6 = 117,
        //
        // 概要:
        //     F7 キー。
        F7 = 118,
        //
        // 概要:
        //     F8 キー。
        F8 = 119,
        //
        // 概要:
        //     F9 キー。
        F9 = 120,
        //
        // 概要:
        //     F10 キー。
        F10 = 121,
        //
        // 概要:
        //     F11 キー。
        F11 = 122,
        //
        // 概要:
        //     F12 キー。
        F12 = 123,
        //
        // 概要:
        //     F13 キー。
        F13 = 124,
        //
        // 概要:
        //     F14 キー。
        F14 = 125,
        //
        // 概要:
        //     F15 キー。
        F15 = 126,
        //
        // 概要:
        //     F16 キー。
        F16 = 127,
        //
        // 概要:
        //     F17 キー。
        F17 = 128,
        //
        // 概要:
        //     F18 キー。
        F18 = 129,
        //
        // 概要:
        //     F19 キー。
        F19 = 130,
        //
        // 概要:
        //     F20 キー。
        F20 = 131,
        //
        // 概要:
        //     F21 キー。
        F21 = 132,
        //
        // 概要:
        //     F22 キー。
        F22 = 133,
        //
        // 概要:
        //     F23 キー。
        F23 = 134,
        //
        // 概要:
        //     F24 キー。
        F24 = 135,
        //
        // 概要:
        //     ブラウザーの戻るキー (Windows 2000 以降)。
        BrowserBack = 166,
        //
        // 概要:
        //     ブラウザーの進むキー (Windows 2000 以降)。
        BrowserForward = 167,
        //
        // 概要:
        //     ブラウザーの更新キー (Windows 2000 以降)。
        BrowserRefresh = 168,
        //
        // 概要:
        //     ブラウザーの中止キー (Windows 2000 以降)。
        BrowserStop = 169,
        //
        // 概要:
        //     ブラウザーの検索キー (Windows 2000 以降)。
        BrowserSearch = 170,
        //
        // 概要:
        //     ブラウザーのお気に入りキー (Windows 2000 以降)。
        BrowserFavorites = 171,
        //
        // 概要:
        //     ブラウザーのホーム キー (Windows 2000 以降)。
        BrowserHome = 172,
        //
        // 概要:
        //     音量ミュート キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        VolumeMute = 173,
        //
        // 概要:
        //     音量 - キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        VolumeDown = 174,
        //
        // 概要:
        //     音量 + キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        VolumeUp = 175,
        //
        // 概要:
        //     メディア: 次のトラック キー (Windows 2000 以降)。
        MediaNext = 176,
        //
        // 概要:
        //     メディア: 前のトラック キー (Windows 2000 以降)。
        MediaPrevious = 177,
        //
        // 概要:
        //     メディア: 停止キー (Windows 2000 以降)。
        MediaStop = 178,
        //
        // 概要:
        //     メディア: 再生/一時停止キー (Windows 2000 以降)。
        MediaPlay = 179,
        //
        // 概要:
        //     メールの起動キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        LaunchMail = 180,
        //
        // 概要:
        //     メディアの選択キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        LaunchMediaSelect = 181,
        //
        // 概要:
        //     アプリケーションの起動 1 キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        LaunchApp1 = 182,
        //
        // 概要:
        //     アプリケーションの起動 2 キー (Microsoft Natural Keyboard、Windows 2000 以降)。
        LaunchApp2 = 183,
        //
        // 概要:
        //     OEM 1 キー (OEM 固有)。
        Oem1 = 186,
        //
        // 概要:
        //     国または地域別キーボード上の OEM プラス キー (Windows 2000 以降)。
        OemPlus = 187,
        //
        // 概要:
        //     国または地域別キーボード上の OEM コンマ キー (Windows 2000 以降)。
        OemComma = 188,
        //
        // 概要:
        //     国または地域別キーボード上の OEM マイナス キー (Windows 2000 以降)。
        OemMinus = 189,
        //
        // 概要:
        //     国または地域別キーボード上の OEM ピリオド キー (Windows 2000 以降)。
        OemPeriod = 190,
        //
        // 概要:
        //     OEM 2 キー (OEM 固有)。
        Oem2 = 191,
        //
        // 概要:
        //     OEM 3 キー (OEM 固有)。
        Oem3 = 192,
        //
        // 概要:
        //     OEM 4 キー (OEM 固有)。
        Oem4 = 219,
        //
        // 概要:
        //     OEM 5 キー (OEM 固有)。
        Oem5 = 220,
        //
        // 概要:
        //     OEM 6 キー (OEM 固有)。
        Oem6 = 221,
        //
        // 概要:
        //     OEM 7 キー (OEM 固有)。
        Oem7 = 222,
        //
        // 概要:
        //     OEM 8 キー (OEM 固有)。
        Oem8 = 223,
        //
        // 概要:
        //     OEM 102 キー (OEM 固有)。
        Oem102 = 226,
        //
        // 概要:
        //     ME PROCESS キー。
        Process = 229,
        //
        // 概要:
        //     Packet キー (キーストロークで Unicode 文字を渡すために使用)。
        Packet = 231,
        //
        // 概要:
        //     Attn キー。
        Attention = 246,
        //
        // 概要:
        //     CRSEL (Cursor Select) キー。
        CrSel = 247,
        //
        // 概要:
        //     Exsel (Extend Selection) キー。
        ExSel = 248,
        //
        // 概要:
        //     Erase Eof キー。
        EraseEndOfFile = 249,
        //
        // 概要:
        //     Play キー。
        Play = 250,
        //
        // 概要:
        //     Zoom キー。
        Zoom = 251,
        //
        // 概要:
        //     将来使用するために予約されている定数。
        NoName = 252,
        //
        // 概要:
        //     PA1 キー。
        Pa1 = 253,
        //
        // 概要:
        //     Clear キー (OEM 固有)。
        OemClear = 254
    }
}
 */