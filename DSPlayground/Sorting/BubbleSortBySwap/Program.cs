namespace BubbleSortBySwap ;

internal static class BubbleSort
{
    private static void Main()
    {
        int[] numbers = { 100, 9, 7, 12, 67, 78, 89 };

        Console.Write("Original array:");
        PrintArray(numbers);

        BubbleSortingBySwap(numbers);

        Console.Write("Sorted array:");
        PrintArray(numbers);
    }

    private static void BubbleSortingBySwap(int[] numbers)
    {
        var n = numbers.Length;

        for (int i = 0; i < n - 1; i++)
        {
            // Flag to optimize and reduce unnecessary iterations
            bool swapped = false;

            for (int j = 0; j < n - 1 - i; j++) // Adjust loop to avoid sorted elements
            {
                if (numbers[j] > numbers[j + 1])
                {
                    // Swap elements
                    var temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;

                    swapped = true; // Set flag only when a swap occurs
                }
            }

            // If no elements were swapped, the array is sorted
            if (!swapped)
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

