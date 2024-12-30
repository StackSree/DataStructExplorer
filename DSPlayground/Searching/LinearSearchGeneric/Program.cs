namespace LinearSearchGeneric;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 10, 20, 5, 7, 30, 15 };

        int min = LinearSearch<int>.FindMin(array, 1, 4);
        Console.WriteLine($"Min value in range [1, 4]: {min}");

        int max = LinearSearch<int>.FindMax(array, 1, 4);
        Console.WriteLine($"Max value in range [1, 4]: {max}");

        int sum = LinearSearch<int>.Sum(array, 1, 4);
        Console.WriteLine($"Sum of values in range [1, 4]: {sum}");
    }
}

static class LinearSearch<T> where T : IComparable<T>
{   
    public static T FindMin(IEnumerable<T> array, int start, int end)
    {
        T min = default(T);
        bool isInitialized = false;

        int index = 0;
        foreach (var item in array)
        {
            if (index >= start && index <= end)
            {
                if (!isInitialized)
                {
                    min = item;
                    isInitialized = true;
                }
                else if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }
            index++;
        }

        return min;
    }

    public static T FindMax(IEnumerable<T> array, int start, int end)
    {
        T max = default(T);
        bool isInitialized = false;

        int index = 0;
        foreach (var item in array)
        {
            if (index >= start && index <= end)
            {
                if (!isInitialized)
                {
                    max = item;
                    isInitialized = true;
                }
                else if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            index++;
        }

        return max;
    }

    public static dynamic Sum(int[] array, int start, int end)
    {
        dynamic sum = 0;

        int index = 0;
        foreach (var item in array)
        {
            if (index >= start && index <= end)
                sum += item;

            index++;
        }

        return sum;
    }
}
