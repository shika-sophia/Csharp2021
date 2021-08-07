/**
 * @title cSharpSub / introduction / MultiplyMatrix.java
 * @reference 山田祥寛 『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第４章 制御構文 / 九九表を表示(java版)
 * @author shika
 * @date 2021-07-14
 */
package cSharpSub.introduction;

import java.util.stream.IntStream;

public class MultiplyMatrix {
    private static int count;

    public static void main(String[] args) {
        //---- nested 'for' version ----
        for(int i = 1; i <= 9; i++) {
            for(int j = 1; j <= 9; j++) {
                System.out.printf("%2d ", i * j);
            }//for j

            System.out.println(); //改行
        }//for i
        System.out.println();

        //---- IntStream.flatMap() version ----
        IntStream.rangeClosed(1, 9)
            .flatMap(i ->
                IntStream.rangeClosed(1, 9)
                    .map(j -> i * j))
            .forEach(i -> {
                System.out.printf("%2d ", i);

                count++;
                if(count % 9 == 0) {
                    System.out.println();
                }
            });
    }//main()

}//class

/*
//---- nested 'for' version ----
 1  2  3  4  5  6  7  8  9
 2  4  6  8 10 12 14 16 18
 3  6  9 12 15 18 21 24 27
 4  8 12 16 20 24 28 32 36
 5 10 15 20 25 30 35 40 45
 6 12 18 24 30 36 42 48 54
 7 14 21 28 35 42 49 56 63
 8 16 24 32 40 48 56 64 72
 9 18 27 36 45 54 63 72 81

//---- IntStream.flatMap() version ----
 1  2  3  4  5  6  7  8  9
 2  4  6  8 10 12 14 16 18
 3  6  9 12 15 18 21 24 27
 4  8 12 16 20 24 28 32 36
 5 10 15 20 25 30 35 40 45
 6 12 18 24 30 36 42 48 54
 7 14 21 28 35 42 49 56 63
 8 16 24 32 40 48 56 64 72
 9 18 27 36 45 54 63 72 81

*/