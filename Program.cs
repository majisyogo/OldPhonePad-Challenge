using System;

class Program
{
    static void Main()
    {
        // サンプル入力（#付き）
        string input1 = "44 444 0 444 777 666 66 0 7777 666 333 8 9 2 777 33#";
        string input2 = "66 444 222 33 0 8 666 0 6 33 33 8 0 999 666 88#";
        string input3 = "333 777 666 6 0 7777 44 666 4 666 0 6 2 5 444 6 2#";

        Console.WriteLine(OldPhonePad.Convert(input1)); // HI IRON SOFTWARE
        Console.WriteLine(OldPhonePad.Convert(input2)); // NICE TO MEET YOU
        Console.WriteLine(OldPhonePad.Convert(input3)); // FROM SHOGO MAJIMA
    }
}
