/**
 * @title cShrapSub / introduction / ConcatString.java
 * @reference 山田祥寛 『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第３章 演算子 / p80 / List 3-1, 3-2
 *          String結合時の
 *          「+」演算子と StringBuilder, Stream 処理速度比較
 * @see VisualStudio: Csharp2021/introduction/ConcatString.cs
 * @author shika
 * @date 2021-07-13
 */
package cSharpSub.introduction;

import java.util.stream.Stream;

public class ConcatString {

    @SuppressWarnings("unused")
    public static void main(String[] args) {
        final int TIMES = 10000;
        long start = System.currentTimeMillis();
        //---- 「+」演算子 ----
//        String result = "";
//        for(int i = 0; i < TIMES; i++) {
//            result += "いろは";
//        }

//        //---- Stream.generate() ----
//        String result = Stream.generate(() -> "いろは")
//            .limit(TIMES)
//            .collect(Collectors.joining());

        //---- StringBuilder ----
        final var bld = new StringBuilder(30000);
//        for(int i = 0; i < TIMES; i++) {
//            bld.append("いろは");
//        }
//        String result = bld.toString();

        Stream.generate(() -> "いろは")
            .limit(TIMES)
            .forEach(bld::append);
        String result = bld.toString();

        long end = System.currentTimeMillis();
        long timeSpan = end - start;
        System.out.println("timeSpan: " + timeSpan);
    }//main()

}//class

/*
//---- 「+」演算子 ----
timeSpan: 125

//---- Stream.generate() ----
timeSpan: 23

//---- StringBuilder + for ----
timeSpan: 15

//---- StringBuilder + Stream.generate() ----
timeSpan: 15

*/