public class OldPhonePad
{
    public static string Convert(string input)
    {
        if (input.EndsWith("#"))
            input = input.Substring(0, input.Length - 1);

        var result = new StringBuilder();
        char prevChar = '\0';
        int pressCount = 0;

        var keypad = new Dictionary<char, string>
        {
            { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" },
            { '5', "JKL" }, { '6', "MNO" }, { '7', "PQRS" },
            { '8', "TUV" }, { '9', "WXYZ" }, { '0', " " }
        };

        foreach (char c in input)
        {
            if (c == ' ')
                ConfirmLetter(ref prevChar, ref pressCount, result, keypad);
            else if (c == '*')
                HandleBackspace(ref prevChar, ref pressCount, result, keypad);
            else if (char.IsDigit(c))
                HandleDigit(c, ref prevChar, ref pressCount, result, keypad);
        }

        ConfirmLetter(ref prevChar, ref pressCount, result, keypad);
        return result.ToString();
    }

    private static void ConfirmLetter(ref char prevChar, ref int pressCount, StringBuilder result, Dictionary<char, string> keypad)
    {
        if (prevChar != '\0')
        {
            string letters = keypad[prevChar];
            int index = (pressCount - 1) % letters.Length;
            result.Append(letters[index]);
            prevChar = '\0';
            pressCount = 0;
        }
    }

    private static void HandleBackspace(ref char prevChar, ref int pressCount, StringBuilder result, Dictionary<char, string> keypad)
    {
        if (prevChar != '\0')
            ConfirmLetter(ref prevChar, ref pressCount, result, keypad);

        if (result.Length > 0)
            result.Remove(result.Length - 1, 1);
    }

    private static void HandleDigit(char c, ref char prevChar, ref int pressCount, StringBuilder result, Dictionary<char, string> keypad)
    {
        if (c == prevChar)
            pressCount++;
        else
        {
            ConfirmLetter(ref prevChar, ref pressCount, result, keypad);
            prevChar = c;
            pressCount = 1;
        }
    }
}
