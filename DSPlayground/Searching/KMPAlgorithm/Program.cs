namespace KMPAlgorithm;

internal class Program
{
    static void Main(string[] args)
    {
        string text = "ABABDABACDABABCABAB";
        string pattern = "ABABCABAB";

        Console.WriteLine("KMP Algorithm: Finding pattern in text");
        KMPSearch(text, pattern);
    }

    // Function to build the LPS array
    private static int[] ComputeLPSArray(string pattern)
    {
        int length = 0; // Length of the previous longest prefix suffix
        int i = 1; // Current position in the pattern
        int[] lps = new int[pattern.Length];
        lps[0] = 0; // LPS[0] is always 0

        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                lps[i] = length;
                i++;
            }
            else
            {
                if (length != 0)
                {
                    length = lps[length - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }

        return lps;
    }

    // KMP Search Function
    public static void KMPSearch(string text, string pattern)
    {
        int[] lps = ComputeLPSArray(pattern);
        int i = 0; // Index for text
        int j = 0; // Index for pattern

        while (i < text.Length)
        {
            if (pattern[j] == text[i])
            {
                i++;
                j++;
            }

            if (j == pattern.Length)
            {
                Console.WriteLine($"Pattern found at index {i - j}");
                j = lps[j - 1];
            }
            else if (i < text.Length && pattern[j] != text[i])
            {
                if (j != 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
