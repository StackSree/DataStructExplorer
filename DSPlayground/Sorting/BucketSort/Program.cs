namespace BucketSort;

internal class Program
{
    static void Main(string[] args)
    {
        float[] array = { 0.42f, 0.32f, 0.23f, 0.52f, 0.25f, 0.47f, 0.51f };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(", ", array));

        Sort(array);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", array));
    }

    public static void Sort(float[] array)
    {
        int n = array.Length;
        if (n <= 0)
            return;

        // 1. Create empty buckets
        List<float>[] buckets = new List<float>[n];
        for (int i = 0; i < n; i++)
        {
            buckets[i] = new List<float>();
        }

        // 2. Distribute elements into buckets
        for (int i = 0; i < n; i++)
        {
            int bucketIndex = (int)(array[i] * n); // Scale value to range
            buckets[bucketIndex].Add(array[i]);
        }

        // 3. Sort individual buckets
        for (int i = 0; i < n; i++)
        {
            buckets[i].Sort();
        }

        // 4. Concatenate buckets back into the array
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (float value in buckets[i])
            {
                array[index++] = value;
            }
        }
    }
}
