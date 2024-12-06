
namespace BubbleSort;

internal static class BubbleSort
{
    private static void Main()
    {
        int[] numbers = { 100, 9, 7, 12, 67, 78, 89 };

        Console.Write("Original array:");
        PrintArray(numbers);

        BubbleSorting(numbers);

        Console.Write("Sorted array:");
        PrintArray(numbers);
    }

    private static void BubbleSorting(int[] numbers)
    {
       var n = numbers.Length;
        
        for (int i = 0; i < n-1; i++)
        { 
            // flag to optimise and reduce un necessary iteration
            var swapped = false;

            for (var j = 0; j < n-1; j++)
            {
                swapped = true;
                if (numbers[j] > numbers[j+1])
                {
                    (numbers[j], numbers[j+1]) = (numbers[j+1], numbers[j]);
                }
            }

            if (swapped)
            {
                break;
            }
        }
    }

    private static void PrintArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write(number + ",");
        }
        Console.WriteLine();
    }
}
