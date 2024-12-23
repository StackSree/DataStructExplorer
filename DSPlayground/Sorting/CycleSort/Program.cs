namespace CycleSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 8, 3, 9, 10, 10, 2, 4, 6, 5 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        CycleSortArray(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void CycleSortArray(int[] array)
    {
        int n = array.Length;

        // Traverse the array elements and put them in the correct position
        for (int cycleStart = 0; cycleStart <= n - 2; cycleStart++)
        {
            int item = array[cycleStart];

            // Find the position where we put the element
            int pos = cycleStart;
            for (int i = cycleStart + 1; i < n; i++)
            {
                if (array[i] < item)
                {
                    pos++;
                }
            }

            // If the item is already in the correct position, skip
            if (pos == cycleStart)
            {
                continue;
            }

            // Skip duplicates
            while (item == array[pos])
            {
                pos++;
            }

            // Put the item to the correct position
            if (pos != cycleStart)
            {
                int temp = array[pos];
                array[pos] = item;
                item = temp;
            }

            // Rotate the rest of the cycle
            while (pos != cycleStart)
            {
                pos = cycleStart;

                for (int i = cycleStart + 1; i < n; i++)
                {
                    if (array[i] < item)
                    {
                        pos++;
                    }
                }

                while (item == array[pos])
                {
                    pos++;
                }

                if (item != array[pos])
                {
                    int temp = array[pos];
                    array[pos] = item;
                    item = temp;
                }
            }
        }
    }
}
