namespace StrandSort;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> input = new List<int> { 10, 5, 30, 40, 2, 4, 6 };

        Console.WriteLine("Original List:");
        Console.WriteLine(string.Join(" ", input));

        List<int> sorted = StrandSort(input);

        Console.WriteLine("\nSorted List:");
        Console.WriteLine(string.Join(" ", sorted));
    }

    public static List<int> StrandSort(List<int> input)
    {
        // Result list to store the sorted output
        List<int> result = new List<int>();

        while (input.Count > 0)
        {
            // Create a new strand (sorted subsequence)
            List<int> strand = new List<int>();
            strand.Add(input[0]);
            input.RemoveAt(0);

            // Pull elements from the input to form a sorted strand
            for (int i = 0; i < input.Count;)
            {
                if (input[i] >= strand[^1]) // Use ^1 to get the last element
                {
                    strand.Add(input[i]);
                    input.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            // Merge the strand into the result
            result = MergeSortedLists(result, strand);
        }

        return result;
    }

    // Helper function to merge two sorted lists
    private static List<int> MergeSortedLists(List<int> list1, List<int> list2)
    {
        List<int> merged = new List<int>();
        int i = 0, j = 0;

        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] <= list2[j])
            {
                merged.Add(list1[i]);
                i++;
            }
            else
            {
                merged.Add(list2[j]);
                j++;
            }
        }

        // Add any remaining elements
        while (i < list1.Count)
        {
            merged.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            merged.Add(list2[j]);
            j++;
        }

        return merged;
    }
}
