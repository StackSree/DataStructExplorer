namespace BoyerMooreSearch;

internal class Program
{
    private static int ALPHABET_SIZE = 256; // Number of possible characters (Extended ASCII)
    static void Main(string[] args)
    {
        string text = "ABAAABCDABAAABCABAAABCD";
        string pattern = "ABCD";

        Console.WriteLine($"Text: \"{text}\"");
        Console.WriteLine($"Pattern: \"{pattern}\"");
        Console.WriteLine("Searching for pattern using Boyer-Moore Algorithm...");

        Search(text, pattern);
    }

    // Boyer-Moore search function
    public static void Search(string text, string pattern)
    {
        int textLength = text.Length;
        int patternLength = pattern.Length;

        if (patternLength > textLength)
        {
            Console.WriteLine("Pattern is longer than text. No match found.");
            return;
        }

        int[] badCharTable = PreprocessBadCharacter(pattern);
        int shift = 0;

        while (shift <= (textLength - patternLength))
        {
            int j = patternLength - 1;

            // Compare the pattern with the text from right to left
            while (j >= 0 && pattern[j] == text[shift + j])
                j--;

            // If pattern is found
            if (j < 0)
            {
                Console.WriteLine($"Pattern found at index {shift}");
                shift += (shift + patternLength < textLength) ? patternLength - badCharTable[text[shift + patternLength]] : 1;
            }
            else
            {
                // Shift pattern based on the bad character heuristic
                shift += Math.Max(1, j - badCharTable[text[shift + j]]);
            }
        }        
    }

    // Preprocesses the pattern to create the bad character heuristic table
    private static int[] PreprocessBadCharacter(string pattern)
    {
        int[] badChar = new int[ALPHABET_SIZE];

        // Initialize all occurrences as -1
        for (int i = 0; i < ALPHABET_SIZE; i++)
            badChar[i] = -1;

        // Fill in the last occurrence of each character in the pattern
        for (int i = 0; i < pattern.Length; i++)
            badChar[(int)pattern[i]] = i;

        return badChar;
    }

}
