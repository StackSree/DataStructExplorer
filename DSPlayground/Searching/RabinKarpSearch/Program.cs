namespace RabinKarpSearch;

internal class Program
{
    static readonly int Prime = 101; // A prime number for hashing
    static void Main(string[] args)
    {
        string text = "ababcabcabababd";
        string pattern = "ababd";

        Console.WriteLine($"Text: \"{text}\"");
        Console.WriteLine($"Pattern: \"{pattern}\"");
        Console.WriteLine("Searching for pattern in text using Rabin-Karp Algorithm...");

        Search(text, pattern);
    }

    public static void Search(string text, string pattern)
    {
        int textLength = text.Length;
        int patternLength = pattern.Length;

        if (patternLength > textLength)
        {
            Console.WriteLine("Pattern is longer than text. No match found.");
            return;
        }

        // Calculate the hash of the pattern and the first window of the text
        long patternHash = CalculateHash(pattern, patternLength);
        long textHash = CalculateHash(text, patternLength);

        for (int i = 0; i <= textLength - patternLength; i++)
        {
            // If the hash values match, confirm by comparing the characters
            if (patternHash == textHash && CheckEqual(text, i, pattern))
            {
                Console.WriteLine($"Pattern found at index {i}");
            }

            // Slide the window: Update the hash value
            if (i < textLength - patternLength)
            {
                textHash = RecalculateHash(text, i, patternLength, textHash);
            }
        }
    }

    // Calculate the hash value for a string
    private static long CalculateHash(string str, int length)
    {
        long hash = 0;

        for (int i = 0; i < length; i++)
        {
            hash += str[i] * (long)Math.Pow(Prime, i);
        }

        return hash;
    }

    // Recalculate the hash by sliding the window
    private static long RecalculateHash(string text, int oldIndex, int patternLength, long oldHash)
    {
        // Remove the old character and add the new one
        long newHash = oldHash - text[oldIndex];
        newHash /= Prime;
        newHash += text[oldIndex + patternLength] * (long)Math.Pow(Prime, patternLength - 1);

        return newHash;
    }

    // Compare characters to confirm a match
    private static bool CheckEqual(string text, int start, string pattern)
    {
        for (int i = 0; i < pattern.Length; i++)
        {
            if (text[start + i] != pattern[i])
                return false;
        }

        return true;
    }
}
