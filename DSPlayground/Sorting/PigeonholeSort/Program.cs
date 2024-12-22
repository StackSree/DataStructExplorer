namespace PigeonholeSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 8, 3, 2, 7, 4, 6, 8, 5, 3 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        PigeonholeSortMain(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void PigeonholeSortMain(int[] array)
    {
        if (array.Length == 0) return;

        // Find the minimum and maximum values in the array
        int min = array[0];
        int max = array[0];
        foreach (int num in array)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        // Calculate the range of the values
        int range = max - min + 1;

        // Create pigeonholes (buckets)
        List<int>[] pigeonholes = new List<int>[range];
        for (int i = 0; i < range; i++)
        {
            pigeonholes[i] = new List<int>();
        }

        // Place each element in its corresponding pigeonhole
        foreach (int num in array)
        {
            pigeonholes[num - min].Add(num);
        }

        // Collect sorted elements from the pigeonholes
        int index = 0;
        for (int i = 0; i < range; i++)
        {
            foreach (int num in pigeonholes[i])
            {
                array[index++] = num;
            }
        }
    }
}
